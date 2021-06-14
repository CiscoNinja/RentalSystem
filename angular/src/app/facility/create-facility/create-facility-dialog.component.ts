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
  FacilityServiceProxy,
  FacilityDto,
  PermissionDto,
  CreateUpdateFacilityDto,
  PermissionDtoListResultDto,
  FacTypeEnum
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  templateUrl: 'create-facility-dialog.component.html'
})
export class CreateFacilityDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  facility = new FacilityDto();
  permissions: PermissionDto[] = [];
  checkedPermissionsMap: { [key: string]: boolean } = {};
  defaultPermissionCheckedStatus = true;
  //selectedFacilityType: FacTypeEnum;
  facilitytypeenums: string[];
  facilitytypeenum = FacTypeEnum;
  isEnabled: boolean;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _facilityService: FacilityServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    // this._facilityService
    //   .getAllPermissions()
    //   .subscribe((result: PermissionDtoListResultDto) => {
    //     this.permissions = result.items;
    //     this.setInitialPermissionsStatus();
    //   });
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
    // just return default permission checked status
    // it's better to use a setting
    return this.defaultPermissionCheckedStatus;
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

    const facility = new CreateUpdateFacilityDto();
    facility.init(this.facility);
    //facility.grantedPermissions = this.getCheckedPermissions();

    this._facilityService
      .create(facility)
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
