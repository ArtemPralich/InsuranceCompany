import { Component } from '@angular/core';
import { AuthService } from 'src/app/service/AuthService';

@Component({
  selector: 'app-room-admin',
  templateUrl: './room-admin.component.html',
  styleUrls: ['./room-admin.component.css']
})
export class RoomAdminComponent {
  constructor(public auth: AuthService){
      
  }
  
  logout(): void {
    this.auth.logout();
  }
}
