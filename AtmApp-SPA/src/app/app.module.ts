import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AuthService } from './_services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { DataTablesModule } from 'angular-datatables';
import { JwtModule } from '@auth0/angular-jwt';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AlertsModule } from 'angular-alert-module';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NavComponent } from './nav/nav.component';
import { CardsComponent } from './cards/cards.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { appRoutes } from './routes';
import { AtmFleetComponent } from './atm-fleet/atm-fleet.component';
import { FaultLogComponent } from './fault-log/fault-log.component';
import { AtmfleetEditComponent } from './atmfleet-edit/atmfleet-edit.component';
import { AtmFleetResolver } from './_resolvers/atmfleet.resolver';


export function tokenGetter() {
   return localStorage.getItem('token');
}


@NgModule({
   declarations: [
      AppComponent,
      LoginComponent,
      NavComponent,
      CardsComponent,
      HomeComponent,
      RegisterComponent,
      AtmFleetComponent,
      RegisterComponent,
      FaultLogComponent,
      AtmfleetEditComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      DataTablesModule,
      NgbModule,
      AlertsModule.forRoot(),
      TabsModule.forRoot(),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AtmFleetResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
