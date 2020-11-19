namespace PropertyInvestAuction.Services.Mapping
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;
    using AutoMapper.Configuration;

    public class AutoMapperConfig
    {
        private static bool initialized;

        public static IMapper MapperInstance { get; set; }

        public static void RegisterMappings(params Assembly[] assemblies)
        {
            if (initialized)
            {
                return;
            }

            initialized = true;

            var types = assemblies.SelectMany(a => a.GetExportedTypes()).ToList();

            var config = new MapperConfigurationExpression();
            config.CreateProfile("ReflectionProfile",
                configuration =>
                {
                    //IMapFrom<>
                    foreach (var map in GetFromMaps(types))
                    {
                        configuration.CreateMap(map.Source, map.Destination);
                    }

                    //IMapTo<>
                    foreach (var map in GetToMaps(types))
                    {
                        configuration.CreateMap(map.Source, map.Destination);
                    }

                    //IHaveCustomMappings
                    foreach (var map in GetCustomMappings(types))
                    {
                        map.CreateMappings(configuration);
                    }
                });
        }

        private static IEnumerable<TypesMap> GetFromMaps(IEnumerable<Type> types)
            => types
            .SelectMany(t => t.GetTypeInfo()
                .GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                    && !t.IsAbstract && !t.IsInterface)
                .Select(tm => new TypesMap
                {
                    Source = tm.GetTypeInfo().GetGenericArguments()[0],
                    Destination = t
                })
            );

        private static IEnumerable<TypesMap> GetToMaps(IEnumerable<Type> types)
            => types
            .SelectMany(t => t.GetTypeInfo()
                .GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)
                    && !t.IsAbstract && !t.IsInterface)
                .Select(tm => new TypesMap
                {
                    Source = tm.GetTypeInfo().GetGenericArguments()[0],
                    Destination = t
                })
            );

        private static IEnumerable<IHaveCustomMappings> GetCustomMappings(IEnumerable<Type> types)
            => types
            .SelectMany(t => t.GetTypeInfo()
                .GetInterfaces()
                .Where(i => typeof(IHaveCustomMappings).GetTypeInfo().IsAssignableFrom(t)
                    && !t.IsAbstract
                    && !t.IsInterface)
                .Select(tm => (IHaveCustomMappings)Activator.CreateInstance(t))
            );

        private class TypesMap
        {
            public Type Source { get; set; }

            public Type Destination { get; set; }
        }
    }
}
