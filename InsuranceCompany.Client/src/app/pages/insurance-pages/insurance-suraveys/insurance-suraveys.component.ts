import {FlatTreeControl} from '@angular/cdk/tree';
import {Component, Input} from '@angular/core';
import {MatTreeFlatDataSource, MatTreeFlattener} from '@angular/material/tree';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { InsuranceTypeSurvey } from 'src/app/models/InsuranceTypeSurvey';

@Component({
  selector: 'app-insurance-suraveys',
  templateUrl: './insurance-suraveys.component.html',
  styleUrls: ['./insurance-suraveys.component.css']
})
export class InsuranceSuraveysComponent {
  @Input() insuranceRequest:  InsuranceRequest;
  panelOpenState = false;
}