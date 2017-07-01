import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { CalendarEvent } from './calendarevent';
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {
            
    constructor(private http: Http) { }

    public getEvents(filter) {
    
        return this.http.get("/api/calendar" + '?' + this.toQueryString(filter))
            .map(res => res.json());
        
    }

    toQueryString(obj) {
        var parts = [];

        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined)
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
        }

        return parts.join('&')
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
