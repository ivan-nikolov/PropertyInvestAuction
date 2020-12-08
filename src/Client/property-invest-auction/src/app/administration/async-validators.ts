import { FormControl, FormGroup } from "@angular/forms";
import { timer } from "rxjs";
import { switchMap, map } from "rxjs/operators";
import { LocationService } from "./services/location.service";

export const countryAsyncValidator = 
  (locationService: LocationService, time: number = 500) => {
    return (input: FormControl) => {
      return timer(time).pipe(
        switchMap(() => locationService.checkCountryName(input.value)),
        map(res => {
          return res ? {nameTaken: true} : null
        })
      );
    };
  };

  export const cityAsyncValidator = 
  (locationService: LocationService, time: number = 500) => {
    return (input: FormControl) => {
      const countryId = input?.parent?.get('countryId')?.value;
      return timer(time).pipe(
        switchMap(() =>
        locationService.checkCityName(countryId, input.value)
         ),
        map(res => {
          console.log(res);
          return res ? {nameTaken: true} : null
        })
      );
    };
  };

  export const neighborhoodAsyncValidator = 
  (locationService: LocationService, time: number = 500) => {
    return (input: FormControl) => {
      const cityId = input?.parent?.get('cityId')?.value;
      console.log(input.value, cityId);
      return timer(time).pipe(
        switchMap(() =>
        locationService.checkNeighborhoodName(cityId, input.value)
         ),
        map(res => {
          console.log(res);
          return res ? {nameTaken: true} : null
        })
      );
    };
  };