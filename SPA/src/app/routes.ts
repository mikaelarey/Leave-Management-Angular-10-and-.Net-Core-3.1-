import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ActivityComponent } from './activity/activity.component';
import { HomeComponent } from './home/home.component';
import { LeaveComponent } from './leave/leave.component';
import { NotificationComponent } from './notification/notification.component';
import { ProfileComponent} from './profile/profile.component';
import { TrashComponent } from './trash/trash.component';
import { UsersComponent } from './users/users.component';
import { AuthGuard } from 'src/_guard/auth.guard';

export const appRoutes: Routes = [

    { path: 'activity', component: ActivityComponent },
    { path: '', component: DashboardComponent },
    { path: 'leave', component: LeaveComponent },
    { path: 'notification', component: NotificationComponent },
    { path: 'profile', component: ProfileComponent },
    { path: 'trash', component: TrashComponent },
    { path: 'users', component: UsersComponent }

    // { path: '**', redirectTo: '', pathMatch: 'full'}
];
