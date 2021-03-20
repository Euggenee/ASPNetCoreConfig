import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-check-in',
  templateUrl: './check-in.component.html',
  styleUrls: ['./check-in.component.css']
})
export class CheckInComponent implements OnInit {


  private baseUrl: string;
  invalidSingIn: boolean;
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  this.baseUrl = baseUrl;
  }
  ngOnInit() {
  }
  checkIn(form: NgForm) {
    const payload = form.value;
    this.http.post("https://localhost:44395/" + 'privatedata/post-user', payload).subscribe(result => {
      this.router.navigate(['/login'])
    },
      (error) => {
        this.invalidSingIn= true;
      }
    );
  }
}
