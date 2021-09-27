import { Base } from 'src/app/models/Base';
export class Product extends Base{
    Name: string;
    Description: string;
    Identificator: string;
    Price: number;
    Stock: number;
    isEnabled: boolean;
    hasSizes: boolean;
    PriceDiscount: number;
    OnTopInMainPage: boolean;
    isNewProduct: boolean;
    Model: string;
    SharedId: string;
    PresentOnMenu: boolean;
}
