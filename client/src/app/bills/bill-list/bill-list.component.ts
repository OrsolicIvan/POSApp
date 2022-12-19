import { ZaglavljeRacuna } from './../../_models/product';
import { MainService } from 'src/app/_services/main.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DeleteBillDialogComponent } from './delete-bill-dialog/delete-bill-dialog.component';
import { PrintBillDialogComponent } from './print-bill-dialog/print-bill-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-bill-list',
  templateUrl: './bill-list.component.html',
  styleUrls: ['./bill-list.component.css'],
})
export class BillListComponent implements OnInit {
  constructor(private mainService: MainService, private dialog: MatDialog) {
    this.loadRacuni();
    this.dataSource = new MatTableDataSource(this.zaglavljeRacuna);
  }
  zaglavljeRacuna: ZaglavljeRacuna[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<ZaglavljeRacuna>;
  selectedRacun: any;
  displayedColumns: string[] = ['broj', 'datum', 'ime', 'ukupno', 'akcije'];
  ngOnInit(): void {
    this.loadRacuni();
  }
  loadRacuni() {
    this.mainService.getRacuni().subscribe((ZaglavljeRacuna) => {
      this.zaglavljeRacuna = ZaglavljeRacuna;
      this.dataSource.data = this.zaglavljeRacuna;
    });
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  onRacunChange(racun) {
    this.selectedRacun = console.log(this.selectedRacun);
  }
  openDialog(id: number) {
    let dialogRef = this.dialog.open(DeleteBillDialogComponent, {
      width: '400px',
      height: '220px',
      data: { id },
    });
    dialogRef.afterClosed().subscribe((res) => {
      this.loadRacuni();
    });
  }
  openPrintDialog(racun: ZaglavljeRacuna) {
    this.dialog.open(PrintBillDialogComponent, {
      width: '1000px',
      height: '800px',
      data: { racun },
    });
  }
}
