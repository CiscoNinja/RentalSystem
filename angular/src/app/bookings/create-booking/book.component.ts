import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { finalize } from 'rxjs/operators';
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
import { SelectItem, SelectItemGroup } from 'primeng/api';
import { Table } from 'primeng/table';

@Component({
  templateUrl: 'book.component.html',
  styleUrls: ['invoice.css', 'print.css']
})
export class BookComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  booking = new BookingDto();
  checkedFacilitiesMap: { [key: string]: boolean } = {};
  checkedMiscellaneoussMap: { [key: string]: boolean } = {};
  defaultFacilityCheckedStatus = false;
  defaultMiscellaneousCheckedStatus = false;
  paymentModeEnums: string[];
  paymentModeEnum = PaymentModeEnum;
  clients: ClientDto[] = [];
  miscelleneouss: MiscellaneousDto[] = [];
  facilities: FacilityDto[] = [];

  // PrimeNG 
  items: SelectItem[];
  item: string;
  // selectedClient: any;
  countries: any[];
  groupedCities: SelectItemGroup[];
  selectedCountries: any[];
  thisDay = new Date();
  misscellTotal: number = 0;
  facilityTotal: number = 0;
  facilityPlusMiscel: number = 0;

  selectedFacilities: FacilityDto[] = [];
  selectedMiscels: MiscellaneousDto[] = [];
  selectedClient: ClientDto = new ClientDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _bookingService: BookingServiceProxy,
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

    this.countries = [
      { name: 'Australia', code: 'AU' },
      { name: 'Brazil', code: 'BR' },
      { name: 'China', code: 'CN' },
      { name: 'Egypt', code: 'EG' },
      { name: 'France', code: 'FR' },
      { name: 'Germany', code: 'DE' },
      { name: 'India', code: 'IN' },
      { name: 'Japan', code: 'JP' },
      { name: 'Spain', code: 'ES' },
      { name: 'United States', code: 'US' }
    ];

    this.groupedCities = [
      {
        label: 'Germany', value: 'de',
        items: [
          { label: 'Berlin', value: 'Berlin' },
          { label: 'Frankfurt', value: 'Frankfurt' },
          { label: 'Hamburg', value: 'Hamburg' },
          { label: 'Munich', value: 'Munich' }
        ]
      },
      {
        label: 'USA', value: 'us',
        items: [
          { label: 'Chicago', value: 'Chicago' },
          { label: 'Los Angeles', value: 'Los Angeles' },
          { label: 'New York', value: 'New York' },
          { label: 'San Francisco', value: 'San Francisco' }
        ]
      },
      {
        label: 'Japan', value: 'jp',
        items: [
          { label: 'Kyoto', value: 'Kyoto' },
          { label: 'Osaka', value: 'Osaka' },
          { label: 'Tokyo', value: 'Tokyo' },
          { label: 'Yokohama', value: 'Yokohama' }
        ]
      }
    ];
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

  onMiscellaneousChange(miscellaneous: MiscellaneousDto, $event) {
    this.checkedMiscellaneoussMap[miscellaneous.name] = $event.target.checked;
  }

  getTotalMiscellaneouss(selectedMiscellaneous: MiscellaneousDto[]): number {
    let total: number = 0;
    _forEach(selectedMiscellaneous, (item) => {
      total += (item.quantity * item.price)
    });
    this.misscellTotal = total
    this.facilityPlusMiscel = this.misscellTotal + this.facilityTotal
    return total;
  }

  getTotalFacilities(selectedFacils: FacilityDto[]): number {
    let total: number = 0;
    _forEach(selectedFacils, (item) => {
      total += item.price
    });
    this.facilityTotal = total
    this.facilityPlusMiscel = this.misscellTotal + this.facilityTotal
    return total;
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

  clear(table: Table) {
    table.clear();
  }
  cancel() {
  }

  save(): void {
    this.saving = true;

    const booking = new CreateUpdateBookingDto();
    booking.facilities = this.getCheckedFaclilities();
    booking.miscellaneous = this.getCheckedMiscellaneouss();
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
        this.onSave.emit();
      });
  }
}
