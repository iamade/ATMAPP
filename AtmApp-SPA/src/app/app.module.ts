import { AuthService } from './_services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { LoginComponent } from './login/login.component';
import { NavComponent } from './nav/nav.component';
import { CardsComponent } from './cards/cards.component';


@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      LoginComponent,
      NavComponent,
      CardsComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
