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

import { AuthGuard } from './guards/auth.guard';
import { AgentAuthGuard } from './guards/agentAuth.guard';
import { AdminAuthGuard } from './guards/adminAuth.guard';
const routes: Routes = [
  { path: '', component: MainComponent},
  { path: 'login', component: LoginComponent},
  { path: 'insurances', component: InsuranceListComponent},
  { path: 'insurance/:id', component: InsuranceComponent},
  { path: 'documents', component: DocumentTemplatesComponent, canActivate: [AdminAuthGuard]},
  { path: 'registration', component: RegistrationComponent},
  { path: 'not-found', component: NotFoundComponent},
  { path: 'not-access', component: NotAccessComponent},
  { path: 'registration-employee', component: RegistationEmployeeComponent},
  { path: 'request', component: RequestComponent, canActivate: [AuthGuard]},
  { path: 'room-client', component: RoomClientComponent, canActivate: [AuthGuard]},
  { path: 'survey-editor', component: SurveyEditorComponent, canActivate: [AdminAuthGuard]},
  { path: '**', component: NotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
