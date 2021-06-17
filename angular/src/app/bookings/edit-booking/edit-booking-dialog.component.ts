import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  BookingServiceProxy,
  BookingDto,
  PermissionDto,
  CreateUpdateBookingDto,
  FlatPermissionDto,
  Address
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-booking-dialog.component.html'
})
export class EditBookingDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
  booking = new CreateUpdateBookingDto();
  permissions: FlatPermissionDto[];
  grantedPermissionNames: string[];
  checkedPermissionsMap: { [key: string]: boolean } = {};
  address = new Address();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _bookingService: BookingServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._bookingService
      .get(this.id)
      .subscribe((result: CreateUpdateBookingDto) => {
        this.booking = result;
        this.address = result.address;
      });
  }

  setInitialPermissionsStatus(): void {
    _map(this.permissions, (item) => {
      this.checkedPermissionsMap[item.name] = this.isPermissionChecked(
        item.name
      );
    });
  }

  isPermissionChecked(permissionName: string): boolean {
    return _includes(this.grantedPermissionNames, permissionName);
  }

  onPermissionChange(permission: PermissionDto, $event) {
    this.checkedPermissionsMap[permission.name] = $event.target.checked;
  }

  getCheckedPermissions(): string[] {
    const permissions: string[] = [];
    _forEach(this.checkedPermissionsMap, function (value, key) {
      if (value) {
        permissions.push(key);
      }
    });
    return permissions;
  }

  save(): void {
    this.saving = true;

    const booking = new BookingDto();
    this.booking.address = this.address;
    booking.init(this.booking);

    this._bookingService
      .update(booking)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
