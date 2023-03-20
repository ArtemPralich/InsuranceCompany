import { Component } from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {
  title = 'InsuranceCompany.Client';
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
}
