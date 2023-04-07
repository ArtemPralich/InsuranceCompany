import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InsuranceListComponent } from './pages/insurance-list/insurance-list.component';
import { InsuranceComponent } from './pages/insurance/insurance.component';
import { LoginComponent } from './pages/login/login.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { MainComponent } from './pages/main/main.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';

const routes: Routes = [
  { path: '', component: MainComponent},
  { path: 'login', component: LoginComponent},
  { path: 'insurances', component: InsuranceListComponent},
  { path: 'insurance/:id', component: InsuranceComponent,},
  { path: 'registration', component: RegistrationComponent},
  { path: '**', component: NotFoundComponent},];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
