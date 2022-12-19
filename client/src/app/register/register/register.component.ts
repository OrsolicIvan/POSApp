import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup;
  model: any = {}
  constructor(public accountService: AccountService, private fb: FormBuilder,
     private router: Router) { }
     member = true;
     reminder = false;
     ngOnInit(): void {
       this.initializeForm();
       this.switchUrl()
     }
   
     initializeForm() {
       this.registerForm = new FormGroup({
         username: new FormControl(this.model.username, Validators.required),
         email: new FormControl(this.model.email, Validators.required),
         password: new FormControl(this.model.password, [Validators.required, Validators.minLength(4), Validators.maxLength(8)])
       })
     }   

     register() {
       this.accountService.register(this.model).subscribe(response => {
         window.setTimeout(function () { location.reload() }, 500)
         this.router.navigateByUrl('/create-kupac')
       }, error => {
      })
     }
     
     switchUrl() {
       const user: User = JSON.parse(localStorage.getItem('user'));
       if (user) {
         this.router.navigateByUrl('/home')
       }
     }
   }


