import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public settings: Settings
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Settings>("https://localhost:44395/" + 'weatherforecast/get-settings').subscribe(result => {
      this.settings = result;
    }, error => console.error(error));
  }
  }

export class Settings {
  enviromentSettings: EnviromentSettings
    }

export class EnviromentSettings {
  name: string; 
    }
