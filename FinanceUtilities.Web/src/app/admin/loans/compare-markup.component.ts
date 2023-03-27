import { Component, Input, SimpleChanges, OnChanges } from '@angular/core';
import { Loan } from './loan';

@Component({
    selector: 'compare-markup',
    templateUrl: './compare-markup.component.html',
    styleUrls: ['./compare-markup.component.css']
})
export class CompareMarkupComponent {
    @Input() loan: Loan;
    @Input() left: string;
    @Input() right: string;
}
