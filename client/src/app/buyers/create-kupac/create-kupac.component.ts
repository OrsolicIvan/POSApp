import { MatPaginator } from '@angular/material/paginator';
import { IKupac, Kupac } from '../../_models/kupac';
import {
  Component,
  OnInit,
  AfterViewInit,
  ViewChild,
  HostListener,
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MainService } from 'src/app/_services/main.service';
import { MatDialog } from '@angular/material/dialog';
import { DeleteKupacDialogComponent } from './delete-kupac-dialog/delete-kupac-dialog.component';
import { EditKupacComponent } from './edit-kupac/edit-kupac.component';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-create-kupac',
  templateUrl: './create-kupac.component.html',
  styleUrls: ['./create-kupac.component.css'],
})
export class CreateKupacComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['naziv', 'mjesto', 'adresa', 'opcije'];
  dataSource: MatTableDataSource<Kupac>;
  model: any = {};
  bsModalRef: BsModalRef;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  uploadForm: FormGroup;
  kupci: IKupac[];

  constructor(
    private mainService: MainService,
    private dialog: MatDialog,
    private modalService: BsModalService
  ) {
    this.dataSource = new MatTableDataSource(this.kupci);
  }

  ngOnInit(): void {
    this.loadKupci();
  }

  openDialog(id: number) {
    let dialogRef = this.dialog.open(DeleteKupacDialogComponent, {
      width: '400px',
      height: '200px',
      data: { id },
    });
    dialogRef.afterClosed().subscribe((res) => {
      this.loadKupci();
    });
  }

  loadKupci() {
    this.mainService.getKupci().subscribe((Kupac) => {
      this.kupci = Kupac;
      this.dataSource.data = this.kupci;
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  openUpdateDialog(kupac: IKupac) {
    let dialogRef = this.dialog.open(EditKupacComponent, {
      width: '600px',
      height: '500px',
      data: { kupac },
    });
    dialogRef.afterClosed().subscribe((res) => {
      this.loadKupci();
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  @HostListener('window:keydown.+') otvori() {
    this.dialog.closeAll();
    let dialogRef = this.dialog.open(EditKupacComponent, {
      width: '600px',
      height: '500px',
      data: { kupac: this.kupci },
    });
    dialogRef.afterClosed().subscribe((res) => {
      this.loadKupci();
    });
  }
}
