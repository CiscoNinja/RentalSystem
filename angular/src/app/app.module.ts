import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientJsonpModule } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';
import { HomeComponent } from '@app/home/home.component';
import { AboutComponent } from '@app/about/about.component';
import {DropdownModule} from 'primeng/dropdown';
import { CardModule, } from 'primeng/card';
import {ListboxModule} from 'primeng/listbox';
import {TableModule} from 'primeng/table';
import {MultiSelectModule} from 'primeng/multiselect';
import {SplitterModule} from 'primeng/splitter';
import {DividerModule} from 'primeng/divider';
import {InputNumberModule} from 'primeng/inputnumber';
import {CheckboxModule} from 'primeng/checkbox';
import {RadioButtonModule} from 'primeng/radiobutton';
import {ChartModule} from 'primeng/chart';
import {ConfirmPopupModule} from 'primeng/confirmpopup';
import {ConfirmationService} from 'primeng/api';
import {OverlayPanelModule} from 'primeng/overlaypanel';
import { TagModule } from 'primeng/tag';
// import {BrowserModule} from '@angular/platform-browser';
// import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {CalendarModule} from 'primeng/calendar';
import {TabViewModule} from 'primeng/tabview';
// tenants
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';
// roles
import { RolesComponent } from '@app/roles/roles.component';
import { CreateRoleDialogComponent } from './roles/create-role/create-role-dialog.component';
import { EditRoleDialogComponent } from './roles/edit-role/edit-role-dialog.component';
// users
import { UsersComponent } from '@app/users/users.component';
import { CreateUserDialogComponent } from '@app/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/users/edit-user/edit-user-dialog.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ResetPasswordDialogComponent } from './users/reset-password/reset-password.component';
// layout
import { HeaderComponent } from './layout/header.component';
import { HeaderLeftNavbarComponent } from './layout/header-left-navbar.component';
import { HeaderLanguageMenuComponent } from './layout/header-language-menu.component';
import { HeaderUserMenuComponent } from './layout/header-user-menu.component';
import { FooterComponent } from './layout/footer.component';
import { SidebarComponent } from './layout/sidebar.component';
import { SidebarLogoComponent } from './layout/sidebar-logo.component';
import { SidebarUserPanelComponent } from './layout/sidebar-user-panel.component';
import { SidebarMenuComponent } from './layout/sidebar-menu.component';
// facilities
import { FacilitysComponent } from '@app/facility/facilitys.component';
import { CreateFacilityDialogComponent } from './facility/create-facility/create-facility-dialog.component';
import { EditFacilityDialogComponent } from './facility/edit-facility/edit-facility-dialog.component';
// clients
import { ClientsComponent } from '@app/clients/clients.component';
import { CreateClientDialogComponent } from './clients/create-client/create-client-dialog.component';
import { EditClientDialogComponent } from './clients/edit-client/edit-client-dialog.component';
// bookings
import { BookingsComponent } from '@app/bookings/bookings.component';
import { CreateBookingDialogComponent } from './bookings/create-booking/create-booking-dialog.component';
import { BookComponent } from './bookings/create-booking/book.component';
import { EditBookingDialogComponent } from './bookings/edit-booking/edit-booking-dialog.component';
// miscellaneouss
import { MiscellaneoussComponent } from '@app/miscellaneouss/miscellaneouss.component';
import { CreateMiscellaneousDialogComponent } from './miscellaneouss/create-miscellaneous/create-miscellaneous-dialog.component';
import { EditMiscellaneousDialogComponent } from './miscellaneouss/edit-miscellaneous/edit-miscellaneous-dialog.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    // tenants
    TenantsComponent,
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    RolesComponent,
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // facilities
    FacilitysComponent,
    CreateFacilityDialogComponent,
    EditFacilityDialogComponent,
    // clients
    ClientsComponent,
    CreateClientDialogComponent,
    EditClientDialogComponent,
    // miscellaneous
    MiscellaneoussComponent,
    CreateMiscellaneousDialogComponent,
    EditMiscellaneousDialogComponent,
    // bookings
    BookingsComponent,
    CreateBookingDialogComponent,
    EditBookingDialogComponent,
    BookComponent,
    // users
    UsersComponent,
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ChangePasswordComponent,
    ResetPasswordDialogComponent,
    // layout
    HeaderComponent,
    HeaderLeftNavbarComponent,
    HeaderLanguageMenuComponent,
    HeaderUserMenuComponent,
    FooterComponent,
    SidebarComponent,
    SidebarLogoComponent,
    SidebarUserPanelComponent,
    SidebarMenuComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule,
    ModalModule.forChild(),
    BsDropdownModule,
    CollapseModule,
    TabsModule,
    AppRoutingModule,
    ServiceProxyModule,
    SharedModule,
    NgxPaginationModule,
    TabViewModule,
    DropdownModule,
    ListboxModule,
    TableModule,
    MultiSelectModule,
    SplitterModule,
    DividerModule,
    InputNumberModule,
    CheckboxModule,
    RadioButtonModule,
    ChartModule,
    ConfirmPopupModule,
    OverlayPanelModule,
    TagModule,
    // BrowserModule,
    // BrowserAnimationsModule,
    CardModule,
    CalendarModule,
  ],
  providers: [
    ConfirmationService
  ],
  entryComponents: [
    // tenants
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // clients
    CreateClientDialogComponent,
    EditClientDialogComponent,
    // facilities
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ResetPasswordDialogComponent,
    // bookings
    CreateBookingDialogComponent,
    EditBookingDialogComponent,
    BookComponent,
    // miscellaneous
    CreateMiscellaneousDialogComponent,
    EditMiscellaneousDialogComponent,
  ],
})
export class AppModule {}
