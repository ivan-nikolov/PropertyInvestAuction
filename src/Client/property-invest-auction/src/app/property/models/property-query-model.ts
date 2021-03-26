export interface PropertyQueryModel {
    [key: string]: string | number | boolean,
    description: string,
    categoryId: string,
    addressId: string,
    neighborhoodId: string,
    cityId: string,
    countryId: string,
    page: number,
    pageSize: number,
}