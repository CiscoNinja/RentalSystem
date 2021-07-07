import { Component, Injector, ChangeDetectionStrategy } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BookingListDto, BookingListDtoPagedResultDto, BookingServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: './home.component.html',
  animations: [appModuleAnimation()],
  // changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent extends AppComponentBase {
  thisDay = new Date();
  data: any;
  data2: any;
  allTimeTotal: number = 0;
  currentYearTotal: number = 0;
  currentMonthTotal: number = 0;
  todaysTotal: number = 0;

  openBookings: any[];

  chartOptions: any;
  bookings: BookingListDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _bookingsService: BookingServiceProxy,) {
    super(injector);
  }

  ngOnInit() {

    this._bookingsService
      .getAllList().subscribe((result: BookingListDtoPagedResultDto) => {
        this.bookings = result.items;
        console.log(this.bookings);
      this.allTimeTotal = this.getAllTimeTotal(this.bookings);
      this.getCurrentMonthTotal(this.bookings);
      this.getCurrentYearTotal(this.bookings);
      this.getTodaysTotal(this.bookings);
    });

    this.data2 = {
      datasets: [{
          data: [
              11,
              16,
              7,
              3,
              14
          ],
          backgroundColor: [
              "#FF6384",
              "#4BC0C0",
              "#FFCE56",
              "#E7E9ED",
              "#36A2EB"
          ],
          label: 'My dataset'
      }],
      labels: [
          "Red",
          "Green",
          "Yellow",
          "Grey",
          "Blue"
      ]
  }

    this.data = {
      labels: ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC'],
      datasets: [{
        type: 'line',
        label: 'Dataset 1',
        borderColor: '#42A5F5',
        borderWidth: 2,
        fill: false,
        data: [
          50,
          25,
          12,
          48,
          56,
          76,
          42,
          12,
          48,
          56,
          76,
          42
        ]
      }, {
        type: 'bar',
        label: 'Dataset 3',
        backgroundColor: '#FFA726',
        data: [
          41,
          52,
          24,
          12,
          48,
          56,
          76,
          42,
          74,
          23,
          21,
          32
        ]
      }]
    };
    this.chartOptions = {
      responsive: true,
      title: {
        display: true,
        text: 'Combo Bar Line Chart'
      },
      tooltips: {
        mode: 'index',
        intersect: true
      }
    };
  }

  getAllTimeTotal(bookings: BookingListDto[]): number {
    var total = 0
    bookings.forEach(e => {
      total += e.totalAmount;
    })
    // this.allTimeTotal = total;
    return total
  }

  getCurrentYearTotal(bookings: BookingListDto[]): number {
    var total = 0
    bookings.filter(e => e.checkedInDate.toDate().getFullYear() == this.thisDay.getFullYear() )
    .forEach(x => {
      total += x.totalAmount;
    })
    this.currentYearTotal = total;
    return this.currentYearTotal
  }

  getCurrentMonthTotal(bookings: BookingListDto[]): number {
    var total =  0;
    bookings.filter(e => e.checkedInDate.toDate().getMonth() == this.thisDay.getMonth() )
    .forEach(x => {
      total += x.totalAmount;
    })
    this.currentMonthTotal = total;
    return this.currentMonthTotal
  }

  getTodaysTotal(bookings: BookingListDto[]): number {
    var total =  0;
    bookings.filter(e => e.checkedInDate.toDate().getDay() == this.thisDay.getDay() )
    .forEach(x => {
      total += x.totalAmount;
    })
    this.todaysTotal = total;
    return this.todaysTotal
  }

}
