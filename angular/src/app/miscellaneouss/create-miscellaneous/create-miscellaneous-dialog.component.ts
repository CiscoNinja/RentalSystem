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
  MiscellaneousServiceProxy,
  MiscellaneousDto,
  PermissionDto,
  CreateUpdateMiscellaneousDto,
  PermissionDtoListResultDto,
  Address
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  templateUrl: 'create-miscellaneous-dialog.component.html'
})
export class CreateMiscellaneousDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  miscellaneous = new MiscellaneousDto();
  permissions: PermissionDto[] = [];
  checkedPermissionsMap: { [key: string]: boolean } = {};
  defaultPermissionCheckedStatus = true;
  address = new Address();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _miscellaneousService: MiscellaneousServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    const miscellaneous = new CreateUpdateMiscellaneousDto();
    miscellaneous.init(this.miscellaneous);
    // miscellaneous.grantedPermissions = this.getCheckedPermissions();

    this._miscellaneousService
      .create(miscellaneous)
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
