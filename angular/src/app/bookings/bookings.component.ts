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
  BookingListDto
} from '@shared/service-proxies/service-proxies';
import { CreateBookingDialogComponent } from './create-booking/create-booking-dialog.component';
import { EditBookingDialogComponent } from './edit-booking/edit-booking-dialog.component';

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

  createBooking(): void {
    this.showCreateOrEditBookingDialog();
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
