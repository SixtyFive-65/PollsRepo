import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewPollsComponent } from './components/view-polls/view-polls.component';
import { CreatePollComponent } from './components/create-poll/create-poll.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthGuard } from './auth.guard'; // Create this AuthGuard
import { HomeComponent } from './components/home/home.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'view-polls', component: ViewPollsComponent },
  { path: 'create-poll', component: CreatePollComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'contact-us', component: ContactUsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
