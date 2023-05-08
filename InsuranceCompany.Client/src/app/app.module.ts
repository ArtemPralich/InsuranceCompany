import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list'
import { MatButtonModule } from '@angular/material/button';
import { LoginComponent } from './pages/login/login.component';
import { MainComponent } from './pages/main/main.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { AuthService } from './service/AuthService';
import { ClientService } from './service/ClientService';
import { DocumentService } from './service/DocumentService';
import { InsuranceRequestService } from './service/InsuranceRequestService';
import { InsuranceRateService } from './service/InsuranceRateService';
import { SurveyService } from './service/SurveyService';
import { HttpClientModule } from '@angular/common/http';
import { InsuranceListComponent } from './pages/insurance-list/insurance-list.component';
import { MatTableModule } from '@angular/material/table'
import { MatPaginatorModule } from '@angular/material/paginator'; 
import {MatDialogModule} from '@angular/material/dialog';
import {MatSelectModule} from '@angular/material/select';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { FormGroup, FormControl } from '@angular/forms';
import { DialogElementsExampleDialog } from './pages/insurance-list/insurance-list.component';
import { InsuranceComponent } from './pages/insurance/insurance.component';
import { MatStepperModule } from '@angular/material/stepper';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { InsuranceClientInfoComponent } from './pages/insurance-pages/insurance-client-info/insurance-client-info.component';
import { InsuranceSuraveysComponent } from './pages/insurance-pages/insurance-suraveys/insurance-suraveys.component';
import { MatNativeDateModule } from '@angular/material/core';
import { InsuredPersonsComponent } from './pages/insurance-pages/insured-persons/insured-persons.component';
import { InsuranceBankDataComponent } from './pages/insurance-pages/insurance-bank-data/insurance-bank-data.component';
import { InsuranceDocumentsComponent } from './pages/insurance-pages/insurance-documents/insurance-documents.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { RequestComponent } from './pages/request/request.component';
import {MatTreeModule} from '@angular/material/tree';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatRadioModule} from '@angular/material/radio';
import { NgxEditorModule } from 'ngx-editor';
import { DocumentTemplatesComponent } from './pages/document-templates/document-templates.component';
import { RoomClientComponent } from './pages/room-client/room-client.component';
import { ToastrService } from 'ngx-toastr';
import { ToastrModule } from 'ngx-toastr';
import { DialogCreateQuestionPopup, DialogCreateSurveyPopup, SurveyEditorComponent, DialogCreateAnswerPopup } from './pages/survey-editor/survey-editor.component';
import { QuestionTypeService } from './service/QuestionTypeService';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MainComponent,
    NotFoundComponent,
    InsuranceListComponent,
    DialogElementsExampleDialog,
    InsuranceComponent,
    InsuranceClientInfoComponent,
    InsuranceSuraveysComponent,
    InsuredPersonsComponent,
    InsuranceBankDataComponent,
    InsuranceDocumentsComponent,
    RegistrationComponent,
    DocumentTemplatesComponent,
    RegistrationComponent,
    RequestComponent,
    RoomClientComponent,
    SurveyEditorComponent,
    DialogCreateQuestionPopup,
    DialogCreateSurveyPopup,
    DialogCreateAnswerPopup,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule, 
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatIconModule,
    MatListModule,
    MatTableModule,
    MatButtonModule,
    HttpClientModule,
    MatPaginatorModule,
    MatDialogModule,
    MatSelectModule,
    MatAutocompleteModule,
    MatCheckboxModule,
    MatStepperModule,
    MatTabsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTreeModule,
    MatExpansionModule,
    MatRadioModule,
    NgxEditorModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    AuthService,
    ClientService,
    InsuranceRequestService,
    InsuranceRateService,
    DocumentService,
    SurveyService,
  ],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class AppModule { }
