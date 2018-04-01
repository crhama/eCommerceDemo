import { PromotionType } from "./promotion-type";

export class ProductDto {
    constructor(
    id: string,
    productDescription: string,
    promotionType: PromotionType,
    price: number,
    imageUrl: string){}
}