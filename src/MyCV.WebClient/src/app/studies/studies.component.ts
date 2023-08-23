import { Component } from '@angular/core';
import { ApiService } from './services/api.service';

@Component({
  selector: 'app-studies',
  templateUrl: './studies.component.html',
  styleUrls: ['./studies.component.css']
})
export class StudiesComponent {
  data: any[]=[];

  constructor(private apiService: ApiService){}

  ngOnInit():void{
    this.SetData();
  }

  SetData(){
    this.apiService.getdata().subscribe(data => {
      this.data = data;
      console.log(this.data);
    })
  }
}
