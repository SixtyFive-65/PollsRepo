import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ViewPollsComponent } from './components/view-polls/view-polls.component';
import { CreatePollComponent } from './components/create-poll/create-poll.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { ReactiveFormsModule } from '@angular/forms';
import { VotePollComponent  } from './components/vote-poll/vote-poll.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ViewPollsComponent,
    CreatePollComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    ContactUsComponent,
    VotePollComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    provideClientHydration(),
    provideHttpClient(withFetch()) 

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
