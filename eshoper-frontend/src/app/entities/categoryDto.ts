export class CategoryDto{
    id:string;
    categoryName: string;
    parentCategoryId: string;
    categoryCode: string;
    childrenCategory: CategoryDto[]
}