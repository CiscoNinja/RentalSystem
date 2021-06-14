import { Injector, Pipe, PipeTransform } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';

@Pipe({
  name: 'eNumAsString'
})

export class ENumAsStringPipe extends AppComponentBase implements PipeTransform {

  constructor(injector: Injector) {
    super(injector);
  }

  transform(value: number, enumType: any): any {
    return enumType[value].split(/(?=[A-Z])/).join().replace(",", " ");;
  }
}