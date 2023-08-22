import { Component } from '@angular/core';
import { ApiService } from './services/api.service';
@Component({
  selector: 'app-experiences',
  templateUrl: './experiences.component.html',
  styleUrls: ['./experiences.component.css']
})
export class ExperiencesComponent {

  data: any[] =[];

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
