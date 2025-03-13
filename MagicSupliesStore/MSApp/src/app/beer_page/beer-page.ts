import { Component, OnInit,ViewChild } from "@angular/core";
import { GridComponent } from "../../components/gridcomponent/gridcomponent";
import { ApiService } from '../../services/api.service';
import { BeerTable, PaginatorTable } from "../interfaces/beerTable-interface";
import { MatTableDataSource } from "@angular/material/table";
import { paginatorInput } from "../interfaces/paginatorInput-interface";
import * as alertify from 'alertifyjs';


@Component({
    selector: 'beer-page',
    templateUrl: './beer-page.html',
    styleUrl: './beer-page.css',

})
export class BeerPageComponent implements OnInit{
    dataSourceBeerPage: any;
    headers: string[]= [];
    columns: { key: string, header: string }[] = [];
    currentPage : number= 1;
    totalItems : number = 1;
    startRow: number= 0;
    endRow: number = 0
    position: number = 0;
    maxPages : number = 0;
    pageSize :number = 10;
    @ViewChild('gridComponent') gridComponent !: GridComponent;
    constructor(public apiService: ApiService) {

    }
    
    onPageChange(newPage: number) {
      this.currentPage = newPage;
      this.LoadBeerDataMethod();
    }
    
    onPageSizeChange(newSize: number) {
      this.pageSize = newSize;
      this.currentPage = 1;
      this.maxPages = Math.ceil(this.totalItems/ this.pageSize)
      this.LoadBeerDataMethod();
    }
        
    

    async LoadGrid() {
        //Load headers information
        this.headers = ['id', 'nombre', 'estilo', 'pais'];
        //Loads columns information
        this.columns = [
          { key: 'id', header: 'ID' },
          { key: 'nombre', header: 'Cerveza' },
          { key: 'estilo', header: 'Estilo' },
          { key: 'pais', header: 'Pais de origen' },
        ];
    
      }


    changePageSize(newSize: number) {
        this.pageSize = newSize;
        this.currentPage = 1; 
        this.position = this.currentPage * this.pageSize;
        this.LoadBeerDataMethod();
    }
      

      async LoadBeerDataMethod() {
        this.dataSourceBeerPage = new MatTableDataSource<BeerTable>([]);
        console.log('currentpage', this.dataSourceBeerPage)
        if (this.apiService) {
            console.log('currentpage', this.currentPage)

             this.position = this.currentPage * this.pageSize
             this.startRow= (this.position -this.pageSize)+1
            let request: paginatorInput={
                entity: 'cervezas',
                startRow: this.position - this.pageSize,
                endRow : this.position
            }


          this.apiService.getBeers(request)
            .subscribe(
              (response: any) => {
                const rows = response.rows
                 this.totalItems = response.totalItems

                this.dataSourceBeerPage = new MatTableDataSource<BeerTable>(response.rows);
            }

          )
        }
      }

    ngOnInit(): void {

        this.LoadGrid()
        this.LoadBeerDataMethod()    
    }



}


