import { Injectable } from '@angular/core';
import { CalendarEvent } from './calendarevent';



@Injectable()
export class DataService {

    public calendarEvents = [        
        new CalendarEvent(this.getDayOfWeek('2017-06-14'),
                          '12/06/2017',
                          '12/06/2017',
                              `Consideration of Private Members Bills. 
                               Proceedings will be interrupted at
                               11am for the Urgent Questions.`),
        new CalendarEvent(this.getDayOfWeek('2017-06-15'),
                          '19/06/2017',
                          '19/06/2017',
                          `Compulsory Emergency First Aid 
                           Education (State-funded Secondary Schools) Bill - 2nd
                           reading (day 1)`)
    ];
        
    constructor() { }

    public getEvents(): any {
        return this.calendarEvents;
        
    }

    private getDayOfWeek(date: string): string {
        var d = new Date(date);

        var weekday = new Array(7);
        weekday[0] = "Sunday";
        weekday[1] = "Monday";
        weekday[2] = "Tuesday";
        weekday[3] = "Wednesday";
        weekday[4] = "Thursday";
        weekday[5] = "Friday";
        weekday[6] = "Saturday";

        var result = weekday[d.getDay()]

        return result;
    }

}
