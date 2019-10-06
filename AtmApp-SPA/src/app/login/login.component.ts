import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
model: any = {};
registerMode = false;

  constructor(private authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Login is successful');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/home']);
    });
   }

   registerToggle(){
     this.registerMode = true;
   }

   register() {
            this.router.navigate(['/register']);
     }

     cancelRegisterMode(registerMode: boolean) {
       this.registerMode = registerMode;
     }
   }



