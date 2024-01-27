import { Component, OnInit } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import {Observable} from "rxjs";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit{

  constructor(private http: HttpClient){}

  ngOnInit(): void {}

  //test get
  onClick():void{
    this.http.get("https://localhost:7124/Odds/test").subscribe(data => console.log(data));
  }

  //test post
  onClick2():void{
    let data = {x: "qwe", y: "123"};
    this.http.post("https://localhost:7124/Odds/test", data).subscribe(data => console.log(data));
  }
}
