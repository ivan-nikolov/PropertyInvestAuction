import { Neighborhood } from "./neighborhood";

export interface City {
    id: string,
    name: string,
    neighborhoods: Neighborhood[],
}