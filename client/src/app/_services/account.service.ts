import { HttpClient } from '@angular/common/http';
import { Injectable, Output } from "@angular/core";
import { User } from '../_models/user'
import { map, ReplaySubject } from "rxjs";
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})

export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1)
  currentUser$ = this.currentUserSource.asObservable();
  user: User[];
  
  constructor(private httpClient: HttpClient, private router: Router){}

  login(model: any){
    return this.httpClient.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response
        if (user) {
          console.log(user)
          this.currentUserSource.next(user);
          localStorage.setItem('user', JSON.stringify(user));
          this.setCurrentUser(user);
        }
      })
    )
  }

  setCurrentUser(user: User){
    user.roles = [];
    const roles = this.getDecodedToken(user.token).role;
    Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
    console.log(user);
  }

  getId(user:User){
    if(user) {
      const id = this.getDecodedToken(user.token).nameid;
      return id;
    }
  }

  getUsername(user: User){
    if (user){
    const username = this.getDecodedToken(user.token).uniquename;  
    return username;
    }
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  register(model: any){
    return this.httpClient.post<User>(this.baseUrl + 'account/registerMember' , model).pipe(
      map((user: User) => {
        if (user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
          this.setCurrentUser(user);
        }
      })
    )
  }

  getDecodedToken(token) {
    return JSON.parse(atob(token.split('.')[1]));
  }

  isLoggedIn() {
    if (this.user) {
      return true;
    }
  }

}