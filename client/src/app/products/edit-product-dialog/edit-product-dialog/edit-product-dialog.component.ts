import { IProizvod, Proizvod } from './../../../_models/product';
import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { MainService } from 'src/app/_services/main.service';
import { IjedinicaMjere } from 'src/app/_models/jedinicaMjere';

@Component({
  selector: 'app-edit-product-dialog',
  templateUrl: './edit-product-dialog.component.html',
  styleUrls: ['./edit-product-dialog.component.css']
})
export class EditProductDialogComponent implements OnInit {
  units: IjedinicaMjere[];
  unit: IjedinicaMjere;
  upProd: any={};
  model: any = {};
  updateForm: FormGroup;
  selectedMjera: IjedinicaMjere;
  uploadForm: FormGroup;
  constructor(private mainService:MainService,private toastr: ToastrService,@Inject(MAT_DIALOG_DATA) public product,private dialogRef: MatDialogRef<EditProductDialogComponent>) { }
  
  ngOnInit(): void {
    this.initializeForm();
    this.initializeForm2();
    this.loadUnits();
    
  }
  loadUnits() {
    this.mainService.getUnits().subscribe((jedinicaMjere) => {
      this.units = jedinicaMjere;
    });
  }
  initializeForm2() {
    this.uploadForm = new FormGroup({
      naziv: new FormControl(this.model.naziv, [Validators.maxLength(50),Validators.required]),
      cijena: new FormControl(this.model.cijena,[Validators.maxLength(50),Validators.required]),
      stanje: new FormControl(this.model.stanje,[Validators.maxLength(50),Validators.required]),
      jedinicaId: new FormControl(this.model.jedinicaMjere, [Validators.required]),
    });
 
  }
  
  initializeForm() {
    this.updateForm = new FormGroup({
      id : new FormControl(this.upProd.id),
      naziv: new FormControl(this.upProd.naziv, [Validators.maxLength(50),Validators.required]),
      cijena: new FormControl(this.upProd.cijena, [Validators.maxLength(50),Validators.required]),
      stanje: new FormControl(this.upProd.stanje, [Validators.maxLength(50),Validators.required]),
      jedinicaId: new FormControl(this.upProd.jedinicaMjere, [Validators.required]),
    });
    this.updateForm.controls['id'].setValue(this.product.product.id);
    this.updateForm.controls['naziv'].setValue(this.product.product.naziv);
    this.updateForm.controls['cijena'].setValue(this.product.product.cijena);
    this.updateForm.controls['stanje'].setValue(this.product.product.stanje);
    this.updateForm.controls['jedinicaId'].setValue(this.product.product.jedinicaId);
  }

  updateProduct() {
    this.mainService.upProdFormData = this.updateForm.value;
    this.mainService.updateProduct().subscribe(
      (res) => {
        this.toastr.success('Proizvod je uspješno izmijenjen');
        this.dialogRef.close(this.uploadForm.value);
        this.uploadForm.reset();
      },
      (err) => {
        console.log(err);
        
      }
    );
  }
 
  postProduct() {
    this.model = this.uploadForm.value;
    this.mainService.postProduct(this.model).subscribe(
      (res) => {
        this.toastr.success('Proizvod je uspješno dodan');
        this.dialogRef.close(this.uploadForm.value);
        this.uploadForm.reset();
      },
      (err) => {
        console.log(err);
      }
    );
  }
  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }
}
