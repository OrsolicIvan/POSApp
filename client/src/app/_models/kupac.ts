export class Kupac {
    id: number = 0;
    sifra: number = 0;
    naziv: string = "";
    adresa:string = "";
    mjesto:string = "";
}
export interface IKupac {
    id: number;
    sifra: number;
    naziv: string;
    adresa:string;
    mjesto:string;
}
export class UpdateKupacClass{
    id: number = 0;
    naziv: string = "";
    adresa:string = "";
    mjesto:string = "";
}