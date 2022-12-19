import { MainService } from './../../../_services/main.service';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-delete-kupac-dialog',
  templateUrl: './delete-kupac-dialog.component.html',
  styleUrls: ['./delete-kupac-dialog.component.css'],
})
export class DeleteKupacDialogComponent implements OnInit {
  constructor(
    @Inject(MAT_DIALOG_DATA) public kupac: any,
    private mainService: MainService,
    private toastr: ToastrService,
    private dialogRef: MatDialogRef<DeleteKupacDialogComponent>
  ) {}

  ngOnInit(): void {}

  deleteKupac(id: number) {
    this.mainService.deleteKupac(id).subscribe(
      (result) => {
        this.toastr.success('Kupac je uspješno obrisan');
        this.dialogRef.close();
      },
      (err) => {
        console.log(err);
        if (err.status === 200) {
          this.toastr.success('Kupac je uspješno obrisan');
          this.dialogRef.close();
        }
      }
    );
  }
}
