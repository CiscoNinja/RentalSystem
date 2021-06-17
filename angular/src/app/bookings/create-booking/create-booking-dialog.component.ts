import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  BookingServiceProxy,
  BookingDto,
  PermissionDto,
  CreateUpdateBookingDto,
  PermissionDtoListResultDto,
  Address,
  PaymentModeEnum
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  templateUrl: 'create-booking-dialog.component.html'
})
export class CreateBookingDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  booking = new BookingDto();
  permissions: PermissionDto[] = [];
  checkedPermissionsMap: { [key: string]: boolean } = {};
  defaultPermissionCheckedStatus = true;
  paymentModeEnums: string[];
  paymentModeEnum = PaymentModeEnum;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _bookingService: BookingServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    // this._bookingService
    //   .getAllPermissions()
    //   .subscribe((result: PermissionDtoListResultDto) => {
    //     this.permissions = result.items;
    //     this.setInitialPermissionsStatus();
    //   });
    this.paymentModeEnums = Object.keys(this.paymentModeEnum).filter(f => isNaN(Number(f)));

  }

  setInitialPermissionsStatus(): void {
    _map(this.permissions, (item) => {
      this.checkedPermissionsMap[item.name] = this.isPermissionChecked(
        item.name
      );
    });
  }

  isPermissionChecked(permissionName: string): boolean {
    // just return default permission checked status
    // it's better to use a setting
    return this.defaultPermissionCheckedStatus;
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

    const booking = new CreateUpdateBookingDto();
    this.booking.address = this.address;
    booking.init(this.booking);
    // booking.grantedPermissions = this.getCheckedPermissions();

    this._bookingService
      .create(booking)
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
