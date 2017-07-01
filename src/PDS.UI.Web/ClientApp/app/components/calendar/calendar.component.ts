import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';
import { CalendarEvent } from '../../services/calendarevent';

@Component({
    selector: 'app-calendar',
    template: require('./calendar.component.html'),
    providers: [DataService]
})
export class CalendarComponent implements OnInit {

    calendarEvents: CalendarEvent[];

    query: any = {};

    constructor(private dataService: DataService) { }

    ngOnInit() {

        // debug
        this.query.startDate = '2017-06-12';
        this.query.endDate =  '2017-06-12';
                            
        this.dataService.getEvents(this.query)
            .subscribe(calendarEvents => this.calendarEvents = calendarEvents);
    }

}