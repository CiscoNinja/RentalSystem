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
  MiscellaneousServiceProxy,
  MiscellaneousDto,
  PermissionDto,
  CreateUpdateMiscellaneousDto,
  FlatPermissionDto,
  Address
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-miscellaneous-dialog.component.html'
})
export class EditMiscellaneousDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
  miscellaneous = new CreateUpdateMiscellaneousDto();
  permissions: FlatPermissionDto[];
  grantedPermissionNames: string[];
  checkedPermissionsMap: { [key: string]: boolean } = {};
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
    this._miscellaneousService
      .get(this.id)
      .subscribe((result: CreateUpdateMiscellaneousDto) => {
        this.miscellaneous = result;
      });
  }

  save(): void {
    this.saving = true;

    const miscellaneous = new MiscellaneousDto();
    miscellaneous.init(this.miscellaneous);

    this._miscellaneousService
      .update(miscellaneous)
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
