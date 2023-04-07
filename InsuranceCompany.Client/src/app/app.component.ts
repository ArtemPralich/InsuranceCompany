import { Component, ElementRef } from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {
  hide = true;
  title = 'InsuranceCompany.Client';
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
}
