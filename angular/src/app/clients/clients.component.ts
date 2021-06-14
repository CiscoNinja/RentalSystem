import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  ClientServiceProxy,
  ClientDto,
  ClientDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateClientDialogComponent } from './create-client/create-client-dialog.component';
import { EditClientDialogComponent } from './edit-client/edit-client-dialog.component';

class PagedClientsRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: './clients.component.html',
  animations: [appModuleAnimation()]
})
export class ClientsComponent extends PagedListingComponentBase<ClientDto> {
  clients: ClientDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _clientsService: ClientServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedClientsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._clientsService
      .getAll(request.keyword, request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: ClientDtoPagedResultDto) => {
        this.clients = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(client: ClientDto): void {
    abp.message.confirm(
      this.l('ClientDeleteWarningMessage', client.firstName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._clientsService
            .delete(client.id)
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

  createClient(): void {
    this.showCreateOrEditClientDialog();
  }

  editClient(client: ClientDto): void {
    this.showCreateOrEditClientDialog(client.id);
  }

  showCreateOrEditClientDialog(id?: number): void {
    let createOrEditClientDialog: BsModalRef;
    if (!id) {
      createOrEditClientDialog = this._modalService.show(
        CreateClientDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditClientDialog = this._modalService.show(
        EditClientDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditClientDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
