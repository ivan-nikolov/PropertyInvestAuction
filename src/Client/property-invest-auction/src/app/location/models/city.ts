import { Neighborhood } from "./neighborhood";

export interface City {
    id: string,
    name: string,
    countryId: string,
    neighborhoods: Neighborhood[],
}