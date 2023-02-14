import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css'],
})
export class AboutComponent {
  responseFromServer$!: Observable<StatusResponseModel>;
  constructor(private client: HttpClient) {}

  getStatus() {
    this.responseFromServer$ = this.client.get<StatusResponseModel>(
      'http://localhost:1337/'
    );
  }
}

type StatusResponseModel = {
  message: string;
  contact: string;
};
