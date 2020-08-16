import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar.component';

import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { ErrorInterceptionProvider } from '../_services/error.interceptor';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsersComponent } from './users/users.component';
import { TrashComponent } from './trash/trash.component';
import { LeaveComponent } from './leave/leave.component';
import { NotificationComponent } from './notification/notification.component';
import { ProfileComponent } from './profile/profile.component';
import { ActivityComponent } from './activity/activity.component';
import { AuthGuard } from '../_guard/auth.guard';

@NgModule({
  declarations: [
    AppComponent,
      HomeComponent,
      LoginComponent,
      NavbarComponent,
      DashboardComponent,
      UsersComponent,
      TrashComponent,
      LeaveComponent,
      NotificationComponent,
      ProfileComponent,
      ActivityComponent
   ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    AlertifyService,
    AuthService,
    ErrorInterceptionProvider
    // AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
