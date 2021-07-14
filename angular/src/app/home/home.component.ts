import { Component, Injector, ChangeDetectionStrategy } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BookingListDto, BookingListDtoListResultDto, BookingListDtoPagedResultDto, BookingServiceProxy, FacilityDto, FacilityDtoListResultDto, FacilityServiceProxy, FacTypeEnum } from '@shared/service-proxies/service-proxies';
import { forEach } from 'lodash-es';
import * as moment from 'moment';

@Component({
  templateUrl: './home.component.html',
  animations: [appModuleAnimation()],
  // changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent extends AppComponentBase {
  thisDay = new Date();
  momentDate =  moment(this.thisDay);
  data: any;
  data2: any;
  allTimeTotal: number = 0;
  currentYearTotal: number = 0;
  currentMonthTotal: number = 0;
  weekTotal: number = 0;
  bookingCountEachMonth: number[] = [];
  totalForEachMonth: number[] = [];
  polarChartValues: number[] = [];
  polarChartLabes: string[] = [];
  polarChartColors: string[] = []
  monthsOfYear = ['january', 'febuary', 'march', 'april', 'may', 'june', 'july',
    'august', 'september', 'october', 'november', 'december'];

  colors = ["#FF6384","#36A2EB","#FFCE56","#808000","#008000","#FF00FF","#00FFFF","#ADD8E6","#800080","#800000","#E78A61"]



  openBookings: any[];

  chartOptions: any;
  bookings: BookingListDto[] = [];
  facilitys: FacilityDto[] = [];
  keyword = '';
  facilitytypeenums: string[];
  facTypeEnum = FacTypeEnum;

  constructor(
    injector: Injector,
    private _facilitysService: FacilityServiceProxy,
    private _bookingsService: BookingServiceProxy) {
    super(injector);
  }

  ngOnInit() {

    this.facilitytypeenums = Object.keys(this.facTypeEnum).filter(f => isNaN(Number(f)));

    this._bookingsService
      .getAllList().subscribe((result: BookingListDtoListResultDto) => {
        this.bookings = result.items;
        // console.log(this.bookings);
        this.allTimeTotal = this.getAllTimeTotal(this.bookings);
        this.getCurrentMonthTotal(this.bookings);
        this.getCurrentYearTotal(this.bookings);
        this.getWeeksTotal(this.bookings);
        this.getMonthlyCount(this.bookings);
        this.getEachMonthTotal(this.bookings);

      this.drawComboChart();

      });

      this._bookingsService
      .getFacilities().subscribe((result: FacilityDtoListResultDto) => {
        this.facilitys = result.items;

        this.getPolarChartData(this.facilitys, this.facilitytypeenums);

        this.drawPolarChart();
      });
  }

  drawComboChart(){
   
    this.data = {
      labels: ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC'],
      datasets: [{
        type: 'line',
        label: 'Number of Bookings',
        borderColor: '#42A5F5',
        backgroundColor: '#42A5F5',
        borderWidth: 2,
        fill: false,
        yAxisID: 'y-axis-2',
        data: this.bookingCountEachMonth
      }, {
        type: 'bar',
        label: 'Amount Realized',
        backgroundColor: '#FFA726',
        yAxisID: 'y-axis-1',
        data: this.totalForEachMonth
      }],
    };
    this.chartOptions = {
      responsive: true,
      hoverMode: 'index',
      stacked: false,
      tooltips: {
        mode: 'index',
        intersect: true
    },
      scales: {
          yAxes: [{
              type: 'linear',
              display: true,
              position: 'left',
              id: 'y-axis-1',
          }, {
              type: 'linear',
              display: true,
              position: 'right',
              id: 'y-axis-2',
              gridLines: {
                  drawOnChartArea: false
              }
          }]
      }
  };
  }

  drawPolarChart(){
    this.data2 = {
      datasets: [{
        data: this.polarChartValues,
        backgroundColor: this.polarChartColors,
      hoverBackgroundColor: this.polarChartColors
      }],
      labels: this.polarChartLabes
    }
    
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
    bookings.filter(e => e.creationTime.toDate().getFullYear() == this.thisDay.getFullYear())
      .forEach(x => {
        total += x.totalAmount;
      })
    this.currentYearTotal = total;
    return this.currentYearTotal
  }

  getCurrentMonthTotal(bookings: BookingListDto[]): number {
    var total = 0;
    bookings.filter(e => e.creationTime.toDate().getMonth() == this.thisDay.getMonth())
      .forEach(x => {
        total += x.totalAmount;
      })
    this.currentMonthTotal = total;
    return this.currentMonthTotal
  }

  getWeeksTotal(bookings: BookingListDto[]): number {
    var total = 0;
    bookings.filter(e => e.creationTime.week() == this.momentDate.week())
      .forEach(x => {
        total += x.totalAmount;
      })
    this.weekTotal = total;
    return this.weekTotal
  }

  getEachMonthTotal(bookings: BookingListDto[]): number[] {
    var bookingsThisYear = bookings.filter(e => e.creationTime.toDate().getFullYear() == this.thisDay.getFullYear());

    this.monthsOfYear.forEach(thisMonth => {

      var total = 0;
      bookingsThisYear.filter(z => z.creationTime.toDate().getMonth() == this.monthsOfYear.indexOf(thisMonth))
        .forEach(x => {
          total += x.totalAmount;
        })
        this.totalForEachMonth.push(total);

        // forEach(bookingsThisYear, function (x) {
        //   if (x.creationTime.toDate().getMonth() == thisMonth) {
        //     this.totalForEachMonth[thisMonth] += x.totalAmount;
        //   }
        // })
    })
    
    return this.totalForEachMonth;
  }

  getMonthlyCount(bookings: BookingListDto[]): number[] {
    var bookingsThisYear = bookings.filter(e => e.creationTime.toDate().getFullYear() == this.thisDay.getFullYear());

    this.monthsOfYear.forEach(thisMonth => {

      var total = bookingsThisYear.filter(z => z.creationTime.toDate().getMonth() == this.monthsOfYear.indexOf(thisMonth)).length
        this.bookingCountEachMonth.push(total);
    })
    
    return this.bookingCountEachMonth;
  }

  getPolarChartData(facility: FacilityDto[], facilityType: string[]): number[] {
    var chartvalue: number[] = [];
    var chartlabel: string[] = [];

    forEach(facilityType, function (x) {
        chartvalue.push(facility.filter(y => facilityType[y.facType] == x).length);
        chartlabel.push(x);
        });
        
        this.polarChartValues = chartvalue;
        this.polarChartLabes = chartlabel;
        this.polarChartColors = this.colors.slice(0,this.polarChartValues.length)
    return this.polarChartValues;
  }
}
