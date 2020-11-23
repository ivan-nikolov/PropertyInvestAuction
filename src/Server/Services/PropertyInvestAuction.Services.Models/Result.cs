namespace PropertyInvestAuction.Services.Models
{
    public class Result<T>
    {
        public Result()
        {
        }

        public Result(T model)
        {
            this.Model = model;
            this.Succeeded = true;
        }

        public bool Succeeded { get; private set; }

        public bool Failure => !this.Succeeded;

        public T Model { get; private set; }

        public string[] Errors { get; private set; }

        public static implicit operator Result<T>(bool succeeded)
            => new Result<T> { Succeeded = succeeded };

        public static implicit operator Result<T>(string[] error)
            => new Result<T>
            {
                Succeeded = false,
                Errors = error
            };

        public static implicit operator string[](Result<T> instance)
            => instance.Errors;

        public static implicit operator Result<T>(T model) 
            => new Result<T>(model);

        public static implicit operator T(Result<T> instance)
            => instance.Model;
    }
}
