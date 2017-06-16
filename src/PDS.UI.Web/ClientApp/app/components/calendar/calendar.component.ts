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

    constructor(private dataService: DataService) { }

    ngOnInit() {
        
        this.calendarEvents = this.dataService.getEvents();
    }

}