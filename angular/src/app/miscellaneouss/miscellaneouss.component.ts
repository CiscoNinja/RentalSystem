import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  MiscellaneousServiceProxy,
  MiscellaneousDto,
  MiscellaneousDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateMiscellaneousDialogComponent } from './create-miscellaneous/create-miscellaneous-dialog.component';
import { EditMiscellaneousDialogComponent } from './edit-miscellaneous/edit-miscellaneous-dialog.component';

class PagedMiscellaneoussRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: './miscellaneouss.component.html',
  animations: [appModuleAnimation()]
})
export class MiscellaneoussComponent extends PagedListingComponentBase<MiscellaneousDto> {
  miscellaneouss: MiscellaneousDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _miscellaneoussService: MiscellaneousServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedMiscellaneoussRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._miscellaneoussService
      .getAll(request.keyword, request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: MiscellaneousDtoPagedResultDto) => {
        this.miscellaneouss = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(miscellaneous: MiscellaneousDto): void {
    abp.message.confirm(
      this.l('MiscellaneousDeleteWarningMessage', miscellaneous.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._miscellaneoussService
            .delete(miscellaneous.id)
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

  createMiscellaneous(): void {
    this.showCreateOrEditMiscellaneousDialog();
  }

  editMiscellaneous(miscellaneous: MiscellaneousDto): void {
    this.showCreateOrEditMiscellaneousDialog(miscellaneous.id);
  }

  showCreateOrEditMiscellaneousDialog(id?: number): void {
    let createOrEditMiscellaneousDialog: BsModalRef;
    if (!id) {
      createOrEditMiscellaneousDialog = this._modalService.show(
        CreateMiscellaneousDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditMiscellaneousDialog = this._modalService.show(
        EditMiscellaneousDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditMiscellaneousDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
