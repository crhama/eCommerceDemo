import { PromotionType } from "./promotion-type";

export class ProductViewModel
{
    id: number;
    productCode: string;
    productDescription: string;
    productPrice: number;
    brandId: number;
    categoryId: number;
    promotionType: PromotionType;
    isSliderItem: boolean;
    isFeatureItem: boolean;
    isRecommendedItem: boolean;
}