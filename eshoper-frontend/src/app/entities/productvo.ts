import { PromotionType } from "./promotion-type";

export class ProductVo {
    constructor(
    id: string,
    productDescription: string,
    promotionType: PromotionType,
    price: number,
    imageUrl: string){}
}