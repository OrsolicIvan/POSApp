import { jedinicaMjere } from './../_models/jedinicaMjere';
import { UpdateProizvodClass, ZaglavljeRacuna } from './../_models/product';
import { Kupac, UpdateKupacClass } from './../_models/kupac';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Proizvod } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class MainService {
  baseUrl = environment.apiUrl;
  upKupFormData: UpdateKupacClass = new UpdateKupacClass();
  upProdFormData: UpdateProizvodClass = new UpdateProizvodClass();
  constructor(private http: HttpClient,) { }
  getKupci() {
    return this.http.get<Kupac[]>(
      this.baseUrl + `Kupac`,
    );
  }
  postKupac(kupacForm: any) {
    return this.http.post(
      this.baseUrl + `Kupac`,
      kupacForm
    );
  }
  deleteKupac(id: number) {
    return this.http.delete(this.baseUrl + `Kupac/Delete/` + id);
  }
  updateKupac() {
    console.log(this.upKupFormData);
    return this.http.put(
      this.baseUrl + `Kupac/Update/` ,
      this.upKupFormData
    );
  }
  getProducts() {
    return this.http.get<Proizvod[]>(
      this.baseUrl + `Proizvod`,
    );
  }
  getUnits() {
    return this.http.get<jedinicaMjere[]>(
      this.baseUrl + `Jedinica`,
    );
  }
  postProduct(proizvodForm: any) {
    return this.http.post(
      this.baseUrl + `Proizvod`,
      proizvodForm
    );
  }
  deleteProduct(id: number) {
    return this.http.delete(this.baseUrl + `Proizvod/Delete/` + id);
  }
  deleteRacun(id: number) {
    return this.http.delete(this.baseUrl + `Racun/Delete/` + id);
  }
  updateProduct() {
    return this.http.put(
      this.baseUrl + `Proizvod` ,
      this.upProdFormData
    );
  }
  postRacun(uploadRacunForm:any){
    return this.http.post(
      this.baseUrl + `Racun`,
      uploadRacunForm
    );
  }
  getRacuni(){
    return this.http.get<ZaglavljeRacuna[]>(
      this.baseUrl + `Racun`
    );
  }
}
