import { AccountService } from './../../../_services/account.service';
import { StavkaRacuna } from './../../../_models/product';
import {
  Component,
  ElementRef,
  Inject,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { DateFormat } from '../../point-of-sale/custom-date-pipe/custom-date-pipe.component';
import jsPDF from 'jspdf';
import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
pdfMake.vfs = pdfFonts.pdfMake.vfs;
import htmlToPdfmake from 'html-to-pdfmake';
import { CustomDatePipe } from '../../point-of-sale/custom-date-pipe/custom-date-pipe.component';
@Component({
  selector: 'app-print-bill-dialog',
  templateUrl: './print-bill-dialog.component.html',
  styleUrls: ['./print-bill-dialog.component.css'],
})
export class PrintBillDialogComponent implements OnInit {
  total: number;
  totalPopust: number;
  totalBezPopusta: number;
  dataSource: MatTableDataSource<any>;
  constructor(@Inject(MAT_DIALOG_DATA) public racun: any,public accountService:AccountService) {
    this.dataSource = new MatTableDataSource(this.racun);
  }
  ngOnInit(): void {
    console.log(this.racun);
    this.total = 0;
    this.totalPopust = 0;
    for (let j = 0; j < this.racun.racun.stavkeRacuna.length; j++) {
      this.total = this.total + this.racun.racun.stavkeRacuna[j].vrijednost;
      this.totalPopust = this.totalPopust + this.racun.racun.stavkeRacuna[j].iznosPopusta;
    }
    this.totalBezPopusta = this.total + this.totalPopust;
  }
  @ViewChild('pdfTable') pdfTable: ElementRef;
  //PDF genrate button click function
  public downloadAsPDF() {
    const doc = new jsPDF();
    //get table html
    const pdfTable = this.pdfTable.nativeElement;
    //html to pdf format
    var html = htmlToPdfmake(pdfTable.innerHTML);

    const documentDefinition = { content: html };
    pdfMake.createPdf(documentDefinition).open();
  }
}
