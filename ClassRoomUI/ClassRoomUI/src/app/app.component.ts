import { Component, OnInit } from '@angular/core';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  private URL = './assets/dictionary.json';

constructor(){
}

  ngOnInit(): void {
    fetch('./assets/dictionary.json').then(res => res.json())
    .then(console.log); // do something with data

  }
}
