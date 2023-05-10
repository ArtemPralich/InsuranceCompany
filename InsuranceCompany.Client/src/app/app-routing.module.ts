import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InsuranceListComponent } from './pages/insurance-list/insurance-list.component';
import { InsuranceComponent } from './pages/insurance/insurance.component';
import { LoginComponent } from './pages/login/login.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { MainComponent } from './pages/main/main.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { DocumentTemplatesComponent } from './pages/document-templates/document-templates.component';
import { RequestComponent } from './pages/request/request.component';
import { RoomClientComponent } from './pages/room-client/room-client.component';
import { SurveyEditorComponent } from './pages/survey-editor/survey-editor.component';
import { NotAccessComponent } from './pages/not-access/not-access.component';
import { RegistationEmployeeComponent } from './pages/registation-employee/registation-employee.component';

const routes: Routes = [
  { path: '', component: MainComponent},
  { path: 'login', component: LoginComponent},
  { path: 'insurances', component: InsuranceListComponent},
  { path: 'insurance/:id', component: InsuranceComponent,},
  { path: 'documents', component: DocumentTemplatesComponent},
  { path: 'registration', component: RegistrationComponent},
  { path: 'request', component: RequestComponent},
  { path: 'room-client', component: RoomClientComponent},
  { path: 'survey-editor', component: SurveyEditorComponent},
  { path: 'not-found', component: NotFoundComponent},
  { path: 'not-access', component: NotAccessComponent},
  { path: 'registration-employee', component: RegistationEmployeeComponent},
  { path: '**', component: NotFoundComponent},];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
