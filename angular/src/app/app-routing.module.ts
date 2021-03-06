import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { FacilitysComponent } from './facility/facilitys.component';
import { ClientsComponent } from './clients/clients.component';
import { BookingsComponent } from './bookings/bookings.component';
import { BookComponent } from './bookings/create-booking/book.component';
import { MiscellaneoussComponent } from './miscellaneouss/miscellaneouss.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'facility', component: FacilitysComponent, data: { permission: 'Pages.Facilities' }, canActivate: [AppRouteGuard] },
                    { path: 'miscellaneous', component: MiscellaneoussComponent, data: { permission: 'Pages.Miscellaneous' }, canActivate: [AppRouteGuard] },
                    { path: 'clients', component: ClientsComponent, data: { permission: 'Pages.Clients' }, canActivate: [AppRouteGuard] },
                    { path: 'bookings', component: BookingsComponent, data: { permission: 'Pages.Bookings' }, canActivate: [AppRouteGuard] },
                    { path: 'bookings/book', component: BookComponent, data: { permission: 'Pages.Bookings' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent, canActivate: [AppRouteGuard] },
                    { path: 'update-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard] }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
