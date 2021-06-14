import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  FacilityServiceProxy,
  FacilityDto,
  FacilityDtoPagedResultDto,
  FacTypeEnum
} from '@shared/service-proxies/service-proxies';
import { CreateFacilityDialogComponent } from './create-facility/create-facility-dialog.component';
import { EditFacilityDialogComponent } from './edit-facility/edit-facility-dialog.component';

class PagedFacilitysRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: './facilitys.component.html',
  animations: [appModuleAnimation()]
})
export class FacilitysComponent extends PagedListingComponentBase<FacilityDto> {
  facilitys: FacilityDto[] = [];
  keyword = '';
  facilitytypeenums: string[];
  facTypeEnum = FacTypeEnum;

  constructor(
    injector: Injector,
    private _facilitysService: FacilityServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedFacilitysRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._facilitysService
      .getAll(request.keyword, request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: FacilityDtoPagedResultDto) => {
        this.facilitys = result.items;
        this.showPaging(result, pageNumber);
      });

      this.facilitytypeenums = Object.keys(this.facTypeEnum).filter(f => isNaN(Number(f)));

  }

  delete(facility: FacilityDto): void {
    abp.message.confirm(
      this.l('FacilityDeleteWarningMessage', facility.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._facilitysService
            .delete(facility.id)
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

  createFacility(): void {
    this.showCreateOrEditFacilityDialog();
  }

  editFacility(facility: FacilityDto): void {
    this.showCreateOrEditFacilityDialog(facility.id);
  }

  showCreateOrEditFacilityDialog(id?: number): void {
    let createOrEditFacilityDialog: BsModalRef;
    if (!id) {
      createOrEditFacilityDialog = this._modalService.show(
        CreateFacilityDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditFacilityDialog = this._modalService.show(
        EditFacilityDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditFacilityDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
