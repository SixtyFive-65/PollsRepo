import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewPollsComponent } from './components/view-polls/view-polls.component';
import { CreatePollComponent } from './components/create-poll/create-poll.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthGuard } from './auth.guard'; // Create this AuthGuard

const routes: Routes = [
  { path: '', component: ViewPollsComponent },
  { path: 'create-poll', component: CreatePollComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
