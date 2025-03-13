import { Component, EventEmitter, input, Input, Output } from '@angular/core';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator-table.component.html',
  styleUrls: ['./paginator-table.component.css']
})
export class PaginatorComponent {
  @Input() currentPage: number = 1;
  @Input() totalItems: number = 0;
  @Input() pageSize: number = 10;
  @Input() startRow: number = 0;
  @Input() position: number = 0;
  @Output() pageChanged = new EventEmitter<number>();
  @Output() pageSizeChanged = new EventEmitter<number>();

  get totalPages(): number {
    return Math.ceil(this.totalItems / this.pageSize);
  }


  previousPage() {
    if (this.currentPage > 1) {
      this.pageChanged.emit(this.currentPage - 1);
    }
  }

  nextPage() {
    if (this.currentPage < this.totalPages) {
      this.pageChanged.emit(this.currentPage + 1);
    }
  }

  changePageSize(event: any) {
    const newSize = +event.target.value;
    this.pageSize = newSize; 
    this.pageSizeChanged.emit(newSize);
  }
}
