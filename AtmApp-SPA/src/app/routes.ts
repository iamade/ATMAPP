import { AuthGuard } from './_guards/auth.guard';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import {Routes} from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CardsComponent } from './cards/cards.component';
import { RegisterComponent } from './register/register.component';

export const appRoutes: Routes = [
            { path: 'login', component: LoginComponent},
            {
                path: '',
                runGuardsAndResolvers: 'always',
                canActivate: [AuthGuard],
                children: [
                    { path: 'home', component: HomeComponent},
                    { path: 'nav', component: NavComponent},
                    { path: 'cards', component: CardsComponent},
                    { path: 'register', component: RegisterComponent},
                ]
            },
            { path: '**', redirectTo: 'login', pathMatch: 'full'},
        ];