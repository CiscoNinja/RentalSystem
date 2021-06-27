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
  PaymentModeEnum,
  ClientDto,
  ClientDtoListResultDto,
  FacilityDto,
  MiscellaneousDto,
  FacilityDtoListResultDto,
  MiscellaneousDtoListResultDto
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';
import { SelectItem } from 'primeng/api';

@Component({
  templateUrl: 'create-booking-dialog.component.html'
})
export class CreateBookingDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  booking = new BookingDto();
  checkedFacilitiesMap: { [key: string]: boolean } = {};
  checkedMiscellaneoussMap: { [key: string]: boolean } = {};
  defaultFacilityCheckedStatus = true;
  defaultMiscellaneousCheckedStatus = true;
  paymentModeEnums: string[];
  paymentModeEnum = PaymentModeEnum;
  clients: ClientDto[] = [];
  miscelleneouss: MiscellaneousDto[] = [];
  facilities: FacilityDto[] = [];
  items: SelectItem[];
  item: string;
  selectedClient: any;

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
      .getClients()
      .subscribe((result: ClientDtoListResultDto) => {
        this.clients = result.items;
      });

      this._bookingService
      .getFacilities()
      .subscribe((result: FacilityDtoListResultDto) => {
        this.facilities = result.items;
      });

      this._bookingService
      .getMiscellaneous()
      .subscribe((result: MiscellaneousDtoListResultDto) => {
        this.miscelleneouss = result.items;
      });

    this.paymentModeEnums = Object.keys(this.paymentModeEnum).filter(f => isNaN(Number(f)));

  }

  setInitialMiscellaneousStatus(): void {
    _map(this.miscelleneouss, (item) => {
      this.checkedMiscellaneoussMap[item.name] = this.isMiscellaneousChecked(
        item.name
      );
    });
  }

  isMiscellaneousChecked(miscllaneousName: string): boolean {
    // just return default facility checked status
    // it's better to use a setting
    return this.defaultMiscellaneousCheckedStatus;
  }

  onMiscllaneousChange(miscellaneous: MiscellaneousDto, $event) {
    this.checkedMiscellaneoussMap[miscellaneous.name] = $event.target.checked;
  }

  getCheckedMiscellaneouss(): string[] {
    const miscellaneous: string[] = [];
    _forEach(this.checkedMiscellaneoussMap, function (value, key) {
      if (value) {
        miscellaneous.push(key);
      }
    });
    return miscellaneous;
  }

  setInitialFacilitiesStatus(): void {
    _map(this.facilities, (item) => {
      this.checkedFacilitiesMap[item.name] = this.isFacilityChecked(
        item.name
      );
    });
  }

  isFacilityChecked(facilityName: string): boolean {
    // just return default facility checked status
    // it's better to use a setting
    return this.defaultFacilityCheckedStatus;
  }

  onFaciltyChange(facility: FacilityDto, $event) {
    this.checkedFacilitiesMap[facility.name] = $event.target.checked;
  }

  getCheckedFaclilities(): string[] {
    const facilities: string[] = [];
    _forEach(this.checkedFacilitiesMap, function (value, key) {
      if (value) {
        facilities.push(key);
      }
    });
    return facilities;
  }


  save(): void {
    this.saving = true;

    const booking = new CreateUpdateBookingDto();
    // booking.facilities = this.getCheckedFaclilities();
    // booking.miscellaneous = this.getCheckedMiscellaneouss();
    booking.init(this.booking);
    
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
