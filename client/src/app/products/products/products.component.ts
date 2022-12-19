import {
  AfterViewInit,
  Component,
  HostListener,
  OnInit,
  ViewChild,
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { IjedinicaMjere } from 'src/app/_models/jedinicaMjere';
import { IProizvod, Proizvod } from 'src/app/_models/product';
import { MainService } from 'src/app/_services/main.service';
import { DeleteProductDialogComponent } from '../delete-product-dialog/delete-product-dialog/delete-product-dialog.component';
import { EditProductDialogComponent } from '../edit-product-dialog/edit-product-dialog/edit-product-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'sifra',
    'naziv',
    'jedinicaMjere',
    'cijena',
    'stanje',
    'opcije',
    'opcije2',
  ];
  dataSource: MatTableDataSource<Proizvod>;
  bsModalRef: BsModalRef;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  products: IProizvod[];
  searchText = '';
  units: IjedinicaMjere[];

  constructor(
    private mainService: MainService,
    private dialog: MatDialog,
    private modalService: BsModalService
  ) {
    this.dataSource = new MatTableDataSource(this.products);
  }

  ngOnInit(): void {
    this.loadProducts();
    this.loadUnits();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  loadProducts() {
    this.mainService.getProducts().subscribe((Product) => {
      this.products = Product;
      this.dataSource.data = this.products;
    });
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  loadUnits() {
    this.mainService.getUnits().subscribe((jedinicaMjere) => {
      this.units = jedinicaMjere;
    });
  }

  openDialog(id: number) {
    let dialogRef = this.dialog.open(DeleteProductDialogComponent, {
      width: '400px',
      height: '220px',
      data: { id },
    });
    dialogRef.afterClosed().subscribe((res) => {
      this.loadProducts();
    });
  }
  openUpdateDialog(product: IProizvod) {
    let dialogRef = this.dialog.open(EditProductDialogComponent, {
      width: '600px',
      height: '560px',
      data: { product },
    });
    dialogRef.afterClosed().subscribe((res) => {
      this.loadProducts();
    });
  }

  @HostListener('window:keydown.+') otvori() {
    this.dialog.closeAll();
    let dialogRef = this.dialog.open(EditProductDialogComponent, {
      width: '600px',
      height: '550px',
      data: { product: this.products },
    });
    dialogRef.afterClosed().subscribe((res) => {
      this.loadProducts();
    });
  }
}
