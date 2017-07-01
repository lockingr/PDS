import { Member } from './Member';

export interface CalendarItem {

    id: number;

    startDate: string;

    endDate: string;

    member: Member;

}