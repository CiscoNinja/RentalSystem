import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  BookingServiceProxy,
  BookingDto,
  BookingDtoPagedResultDto,
  BookingListDtoPagedResultDto,
  BookingListDto,
  MiscellaneousListDto,
  FacilityListDto,
  BookingListDtoListResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateBookingDialogComponent } from './create-booking/create-booking-dialog.component';
import { EditBookingDialogComponent } from './edit-booking/edit-booking-dialog.component';
import { forEach } from 'lodash-es';
import { Moment } from 'moment';
import * as moment from 'moment';

class PagedBookingsRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: './bookings.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['invoice.css']
})
export class BookingsComponent extends PagedListingComponentBase<BookingDto> {
  bookings: BookingListDto[] = [];
  selectedBoking: BookingListDto;
  keyword = '';
  misscellTotal: number;
  facilityTotal: number;

  constructor(
    injector: Injector,
    private _bookingsService: BookingServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedBookingsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._bookingsService
      .getAllBookings(request.keyword, request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: BookingListDtoPagedResultDto) => {
        this.bookings = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(booking: BookingDto): void {
    abp.message.confirm(
      this.l('BookingDeleteWarningMessage', booking.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._bookingsService
            .delete(booking.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  checkIn(booking: BookingDto): void {
    abp.message.confirm(
      this.l('CheckInWarningMessage', booking.clientName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._bookingsService
            .checkIn(moment(new Date()), booking)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyCheckedIn'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createBooking(): void {
    this.showCreateOrEditBookingDialog();
  }

  checkOut(booking: BookingDto): void {
    abp.message.confirm(
      this.l('CheckOutWarningMessage', booking.clientName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._bookingsService
            .checkOut(moment(new Date()), booking)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyCheckedOut'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  // checkIn(booking: BookingDto): void {
  //   this._bookingsService
  //     .checkIn(this.momentDate, booking).subscribe(() => {
  //       this.refresh();
  //     });
  // }

  // checkOut(booking: BookingDto ): void {
  //   this._bookingsService
  //     .checkOut(this.momentDate, booking).subscribe(() => {
  //       this.refresh();
  //     });
  // }

  getTotalMiscellaneouss(selectedMiscellaneous: MiscellaneousListDto[]): number {
    let total: number = 0;
    forEach(selectedMiscellaneous, (item) => {
      total += (item.quantity * item.price)
    });
    this.misscellTotal = total
    return total;
  }

  getTotalFacilities(selectedFacils: FacilityListDto[]): number {
    let total: number = 0;
    forEach(selectedFacils, (item) => {
      total += (item.numberOfDaysBooked* item.price);
    });
    this.facilityTotal = total
    return total;
  }

  editBooking(booking: BookingDto): void {
    this.showCreateOrEditBookingDialog(booking.id);
  }

  setSelectedBooking(booking: BookingListDto): void {
    this.selectedBoking = booking;
  }

  showCreateOrEditBookingDialog(id?: number): void {
    let createOrEditBookingDialog: BsModalRef;
    if (!id) {
      createOrEditBookingDialog = this._modalService.show(
        CreateBookingDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditBookingDialog = this._modalService.show(
        EditBookingDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditBookingDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
