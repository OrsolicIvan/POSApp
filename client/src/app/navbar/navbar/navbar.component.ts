import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AccountService } from 'src/app/_services/account.service';
import { Router } from '@angular/router';
import { GetUser, User } from 'src/app/_models/user';
import { UserManagementServiceService } from 'src/app/_services/user-management-service.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})

export class NavbarComponent implements OnInit {
  user: GetUser;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

   
  constructor(private breakpointObserver: BreakpointObserver, public accountService: AccountService, public router: Router,
    private umService: UserManagementServiceService) {}

  ngOnInit(): void {
  
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/')
    window.setTimeout(function () { location.reload() }, 500)
  }
}


