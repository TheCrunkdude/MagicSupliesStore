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

    @ViewChild('gridComponent') gridComponent !: GridComponent;
    constructor(public apiService: ApiService) {

    }
    

    async previousPage(){
        console.log("previous page funcionando")
        if  (this.currentPage>1){
            this.currentPage--
            this.LoadBeerDataMethod()
        }
        else{        
            alertify.error('you are currently in the fistpage, you stupid ass')
        }
    }
    async nextPage(){
        console.log("next page funcionando")
        this.currentPage++
        this.LoadBeerDataMethod()
        
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

      

      async LoadBeerDataMethod() {
        this.dataSourceBeerPage = new MatTableDataSource<BeerTable>([]);
        console.log('currentpage', this.dataSourceBeerPage)
        if (this.apiService) {
            console.log('currentpage', this.currentPage)

             this.position = this.currentPage * 10
            console.log('position', this.position)
            let request: paginatorInput={
                startRow: this.position - 10,
                endRow : this.position

            }


          this.apiService.getBeers(request)
            .subscribe(
              (response: any) => {
                const rows = response.rows
                 this.totalItems = response.totalItems

                console.log("total items",this.totalItems)
                console.log(rows)
                this.dataSourceBeerPage = new MatTableDataSource<BeerTable>(response.rows);
                console.log(response.rows)
                
            }

          )
        }
      }

    ngOnInit(): void {

        this.LoadGrid()
        this.LoadBeerDataMethod()    
    }



}


