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
  FacilityServiceProxy,
  FacilityDto,
  PermissionDto,
  CreateUpdateFacilityDto,
  FlatPermissionDto,
  FacTypeEnum
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-facility-dialog.component.html'
})
export class EditFacilityDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
  facility = new CreateUpdateFacilityDto();
  permissions: FlatPermissionDto[];
  grantedPermissionNames: string[];
  checkedPermissionsMap: { [key: string]: boolean } = {};
  selectedFacilityType: FacTypeEnum;
  facilitytypeenums: string[];
  facilitytypeenum = FacTypeEnum;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _facilityService: FacilityServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._facilityService
      .get(this.id)
      .subscribe((result: CreateUpdateFacilityDto) => {
        this.facility = result;
      });
    
      this.facilitytypeenums = Object.keys(this.facilitytypeenum).filter(f => isNaN(Number(f)));
  }

  setInitialPermissionsStatus(): void {
    _map(this.permissions, (item) => {
      this.checkedPermissionsMap[item.name] = this.isPermissionChecked(
        item.name
      );
    });
  }

  isPermissionChecked(permissionName: string): boolean {
    return _includes(this.grantedPermissionNames, permissionName);
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

    const facility = new FacilityDto();
    facility.init(this.facility);

    this._facilityService
      .update(facility)
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
