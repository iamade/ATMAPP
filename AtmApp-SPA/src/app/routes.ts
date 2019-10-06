import { AtmFleetComponent } from './atm-fleet/atm-fleet.component';
import { AuthGuard } from './_guards/auth.guard';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import {Routes} from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CardsComponent } from './cards/cards.component';
import { RegisterComponent } from './register/register.component';
import { FaultLogComponent } from './fault-log/fault-log.component';

export const appRoutes: Routes = [
            { path: 'login', component: LoginComponent},
            {
                path: '',
                runGuardsAndResolvers: 'always',
                canActivate: [AuthGuard],
                children: [
                    
                    { path: 'home', component: HomeComponent},
                    { path: 'register', component: RegisterComponent},
                    { path: 'nav', component: NavComponent},
                    { path: 'atm-fleet', component: AtmFleetComponent},
                    { path: 'cards', component: CardsComponent},
                    { path: 'fault-log', component: FaultLogComponent},
                    
                ]
            },
            { path: '**', redirectTo: 'login', pathMatch: 'full'},
        ];