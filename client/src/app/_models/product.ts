

import { DecimalPipe } from "@angular/common";
import { NumberValueAccessor } from "@angular/forms";
import { jedinicaMjere } from "./jedinicaMjere";
import { IKupac, Kupac } from "./kupac";
import { GetUser } from "./user";

export class Proizvod {
    id: number = 0;
    sifra: number = 0;
    naziv: string = "";
    jedinicaMjere: jedinicaMjere;
    jedinicaId: number = 0;
    cijena: number = 0;
    stanje: number = 0;
}
export interface IProizvod {
    id: number;
    sifra: number;
    naziv: string;
    jedinicaMjere: jedinicaMjere;
    jedinicaId: number;
    cijena: number;
    stanje: number;
}
export class UpdateProizvodClass{
    id: number = 0;
    naziv: string = "";
    cijena: number = 0;
    stanje: number = 0;
    jedinicaId: number = 0;
}
export interface IStavkaRacuna{
    id: number;
    sifra: number;
    naziv: string;
    jedinicaMjere: string;
    kolicina?: number;
    cijena: number;
    popust?: number;
    iznosPopusta?: number;
    vrijednost?:number;
    proizvodId?: number;
    proizvod?: IProizvod;
}
export interface IZaglavljeRacuna{
    datum: Date;
    kupacId: number;
    kupac: IKupac;
    napomena: string;
    stavkeRacuna:IStavkaRacuna[];
    ukupno: number;
}
export class ZaglavljeRacuna {
    datum: Date = new Date();
    kupacId: number = 0;
    kupac: Kupac ;
    napomena: string = "";
    stavkeRacuna: StavkaRacuna[]
    ukupno: number = 0;
    userId: number = 0;
    user: GetUser 
}
export class StavkaRacuna{
    id: number = 0;
    sifra: number = 0;
    naziv: string = "";
    jedinicaMjere: string = "";
    kolicina: number = 0;
    cijena: number = 0;
    popust: number = 0;
    iznosPopusta: number = 0;
    vrijednost: number = 0;
    proizvodId: number = 0;
    proizvod: Proizvod;
}