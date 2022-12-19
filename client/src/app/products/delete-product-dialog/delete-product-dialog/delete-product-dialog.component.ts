import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { MainService } from 'src/app/_services/main.service';

@Component({
  selector: 'app-delete-product-dialog',
  templateUrl: './delete-product-dialog.component.html',
  styleUrls: ['./delete-product-dialog.component.css'],
})
export class DeleteProductDialogComponent implements OnInit {
  constructor(
    @Inject(MAT_DIALOG_DATA) public product: any,
    private mainService: MainService,
    private dialogRef: MatDialogRef<DeleteProductDialogComponent>,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  deleteProduct(id: number) {
    this.mainService.deleteProduct(id).subscribe(
      (result) => {
        this.toastr.success('Proizvod je uspješno obrisan');
        this.dialogRef.close();
      },
      (err) => {
        console.log(err);
        if (err.status === 200) {
          this.toastr.success('Proizvod je uspješno obrisan');
          this.dialogRef.close();
        }
      }
    );
  }
}
