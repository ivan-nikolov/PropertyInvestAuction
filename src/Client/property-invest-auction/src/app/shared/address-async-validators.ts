import { FormControl } from "@angular/forms";
import { map, switchMap } from "rxjs/operators";
import { AddressService } from "./address.service";
import { timer } from 'rxjs';

export const addressAsyncValidator = 
(addressService: AddressService, time: number = 500) => {
  return (input: FormControl) => {
    return timer(time).pipe(
      switchMap(() => addressService.validateId(input.value)),
      map(res => {
        return res ? {exists: true} : null
      })
    );
  };
};