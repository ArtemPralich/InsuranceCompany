import { Component } from '@angular/core';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent {
  condition: boolean=true;
     
  toggle(){
      this.condition=!this.condition;
  }
}
