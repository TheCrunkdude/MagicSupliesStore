import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserTable} from '../app/interfaces/userTable-interface';

export interface loginModel{
  User : string,
  Password: string
}

@Injectable({
  providedIn: 'root'
})
export class ApiService {
private apiUrl = 'https://localhost:7201/api';

  constructor(private http:HttpClient) { }

  getData (): Observable <any>{
    return this.http.get (`${this.apiUrl}/LoginControler`)
    console.log('getdata ok')
  }
  getUserTable(): Observable<UserTable[]> {
    return this.http.get<UserTable[]>(this.apiUrl+ '/GetUsers');
  }
  

  postData (loginModel:loginModel): Observable <any>{
    
    return this.http.post (`${this.apiUrl}/LoginControler`, loginModel,{ responseType: 'text' } )

    console.log('getdata ok')
  }


}
