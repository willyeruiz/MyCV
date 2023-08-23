import { Component } from '@angular/core';
import { ApiService } from './services/api.service';

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.css']
})
export class SkillsComponent {
  data: any[]=[];

  constructor(private apiService: ApiService){}

  ngOnInit():void{
    this.SetData();
  }

  SetData(){
    this.apiService.getdata().subscribe(data => {
      this.data = data;
    })
  }
}
