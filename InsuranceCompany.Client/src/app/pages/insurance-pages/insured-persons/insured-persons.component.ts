import { Component, Input } from '@angular/core';
import { Client } from 'src/app/models/Client';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { InsuredPerson } from 'src/app/models/InsuredPerson';

@Component({
  selector: 'app-insured-persons',
  templateUrl: './insured-persons.component.html',
  styleUrls: ['./insured-persons.component.css']
})
export class InsuredPersonsComponent {
  
  @Input() insuranceRequest:  InsuranceRequest;
  panelOpenState = false;

  addInsuredPerson(){
    var newPerson =new InsuredPerson('');
    newPerson.client = new Client();
    this.insuranceRequest.insuredPersons.push(newPerson);
  }

  delete(person: InsuredPerson){
    const index = this.insuranceRequest.insuredPersons.indexOf(person);
    if (index !== -1) {
      this.insuranceRequest.insuredPersons.splice(index, 1);
    }
    
  }
}
