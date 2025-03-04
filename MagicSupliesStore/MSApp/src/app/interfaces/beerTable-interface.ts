
export interface BeerTable{
  id: number,
  nombre: string,
  estilo: string,
  pais: string,
}

export interface PaginatorTable {
  rows: BeerTable [],
  totalItems: number
}