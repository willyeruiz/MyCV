import { Component } from '@angular/core';
import { ApiService } from './services/api.service';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {

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