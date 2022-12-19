import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

export enum DateFormat {
  short = 'short date',
  medium = 'medium date',
  long = 'long date',
  dateOnly = 'date only',
}

@Pipe({
  name: 'customDate',
})
export class CustomDatePipe extends DatePipe implements PipeTransform {
  private readonly datePatterns = new Map<string, string>([
    ['short',    'd/M/y, HH:mm:ss '],
    ['medium',   'MMM d, y, h:mm:ss a'],
    ['long',     'EEEE, LLLL d, y, h:mm:ss a'],
    ['dateOnly', 'MMM d, y'],
  ]);

  transform(date: Date, format?: string): any {
    const pattern = 
      this.datePatterns.get(format) 
      || this.datePatterns.get('short'); //default format

    return super.transform(date, pattern);
  }
}