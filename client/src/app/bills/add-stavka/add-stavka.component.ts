import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ViewChild, ElementRef } from '@angular/core';
@Component({
  selector: 'app-add-stavka',
  templateUrl: './add-stavka.component.html',
  styleUrls: ['./add-stavka.component.css'],
})
export class AddStavkaComponent implements OnInit {
  @ViewChild('proizvod') proizvod: ElementRef;
  @ViewChild('kolicina') kolicina: ElementRef;
  @ViewChild('popust') popust: ElementRef;
  ngAfterViewInit() {
    setTimeout(()=>this.proizvod.nativeElement.focus(),1);
  }

  selectedProizvod: any = {};
  selected: any;
  addStavkaForm: FormGroup;
  maxKolicina: number = 1;
  constructor(
    @Inject(MAT_DIALOG_DATA) public product,
    private dialogRef: MatDialogRef<AddStavkaComponent>
  ) {}
  model1: any = {};
  ngOnInit(): void {
    this.initializeForm();
  }
  changeSelectedPr($event) {
    this.selected = $event.value;
    this.maxKolicina = this.selectedProizvod.stanje;
  }
  changeToKolicina($event) {
    setTimeout(()=>this.kolicina.nativeElement.focus(),1);
  }
  changeToPopust($event) {
    setTimeout(()=>this.popust.nativeElement.focus(),1);
  }
  initializeForm() {
    this.addStavkaForm = new FormGroup({
      naziv: new FormControl(this.model1.naziv),
      kolicina: new FormControl(this.model1.kolicina, Validators.required),
      cijena: new FormControl(this.model1.cijena),
      popust: new FormControl(this.model1.popust, Validators.required),
      iznosPopusta: new FormControl(this.model1.iznosPopusta),
      vrijednost: new FormControl(this.model1.vrijednost),
      proizvodId: new FormControl(this.model1.proizvodId),
      jedinicaMjere: new FormControl(this.model1.jedinicaMjere)
    });
  }
  addProizvod() {
    this.addStavkaForm.controls['cijena'].setValue(
      this.selectedProizvod.cijena
    );
    this.addStavkaForm.controls['jedinicaMjere'].setValue( this.selectedProizvod.jedinicaMjere.naziv);
    this.addStavkaForm.controls['naziv'].setValue(this.selectedProizvod.naziv);
    this.addStavkaForm.controls['proizvodId'].setValue(
      this.selectedProizvod.id
    );
    this.addStavkaForm.controls['popust'].setValue(
      this.addStavkaForm.controls['popust'].value
    );
    this.addStavkaForm.controls['iznosPopusta'].setValue(
      (this.addStavkaForm.controls['popust'].value / 100) *
        this.addStavkaForm.controls['cijena'].value *
        this.addStavkaForm.controls['kolicina'].value
    );
    this.addStavkaForm.controls['vrijednost'].setValue(
      this.addStavkaForm.controls['cijena'].value *
        this.addStavkaForm.controls['kolicina'].value -
        this.addStavkaForm.controls['iznosPopusta'].value
    );
    this.dialogRef.close(this.addStavkaForm.value);
  }
}
