import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  downloadCV(){
    let link= document.createElement("a");
    link.download = "CV William Ruiz.pdf";
    link.href = "assets/documents/CV William Ruiz.pdf"
    link.click();

  }
}
