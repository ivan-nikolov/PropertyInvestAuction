import { Address } from './address';
import { Photo } from './photo';

export interface Property {
    id: string,
    description: string,
    addressId: string,
    address: Address,
    categoryId: string,
    categoryName: string,
    photos: Photo[],
}