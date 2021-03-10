import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-private-data',
  templateUrl: './private-data.component.html',
  styleUrls: ['./private-data.component.css']
})
export class PrivateDataComponent implements OnInit {

  public  privateDataset: Array<string>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseURL: string) {
    http.get<Array<string>>(baseURL + "privatedata").subscribe(result => {
      this.privateDataset = result;
    },
      error => {

        console.log("privatedata says" + error)
      });
  }

  ngOnInit() {
  }

}
