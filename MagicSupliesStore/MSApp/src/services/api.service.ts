import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserTable} from '../app/interfaces/userTable-interface';

export interface LoginModel{
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

  getUser (id?:number|any, name?:string  ):Observable <any> {
    return this.http.get(`${this.apiUrl}/GetUser?id=${id}&name=${name}`);
  }  

  getUserByName ( name?:string  ):Observable <any> {
    return this.http.get(`${this.apiUrl}/GetUser?name=${name}`);
  }  

  postUser(userTable:UserTable): Observable<any>{
    return this.http.post (`${this.apiUrl}/PostNewUser`,userTable,{ responseType: 'text'})
  }

  putUser (userTable:UserTable): Observable <any>{
    return this.http.put(`${this.apiUrl}/UpdateUser`,userTable,{ responseType: 'text'})
  }
  
  postData (loginModel:LoginModel): Observable <any>{
    return this.http.post (`${this.apiUrl}/LoginControler`,loginModel,{ responseType: 'text'})
  }



}
