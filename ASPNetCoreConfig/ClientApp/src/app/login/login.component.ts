import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private baseUrl: string;
  invalidLogin: boolean;
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  ngOnInit() {
  }
  login(form: NgForm) {
    const payload = form.value;
    this.http.post(this.baseUrl + 'auth/login', payload).subscribe(result => {
      const token = (<any>result).token
      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
      this.router.navigate(['/private-data'])
    },
      (error) => {
        this.invalidLogin = true;
      }
    );

  }
}
