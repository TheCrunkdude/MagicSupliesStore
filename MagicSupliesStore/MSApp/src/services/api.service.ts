import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserTable} from '../app/interfaces/userTable-interface';
import { RolesTable } from '../app/interfaces/rolesTable-interface';
import { PermissionsTable } from '../app/interfaces/permissionsTable-interface';
import { rolePermissionsTable } from '../app/interfaces/rolesPermissionsTable-interface';
import { userRolesTable } from '../app/interfaces/userRoles-interface';

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
    return this.http.get (`${this.apiUrl}/LoginController`)
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
  deleteUser(id: number):Observable<any>{
    return this.http.delete(`${this.apiUrl}/DeleteUser?ID=${id}`,{ responseType: 'text'})
  }
  
  postData (loginModel:LoginModel): Observable <any>{
    return this.http.post (`${this.apiUrl}/Login`,loginModel,{ responseType: 'text'})
  }

////Roles////


getRolesTable(): Observable<RolesTable[]> {
  return this.http.get<RolesTable[]>(this.apiUrl+ '/GetRoles');
}
getRole (id:number):Observable <any> {
  return this.http.get(`${this.apiUrl}/GetRole?id=${id}`);
}  
getCheckRole (role: string):Observable <any>{
  return this.http.get(`${this.apiUrl}/GetCheckRole?role=${role}`);
}
postRole(rolesTable:RolesTable): Observable<any>{
  return this.http.post (`${this.apiUrl}/PostNewRole`,rolesTable,{ responseType: 'text'})
}
putRole (rolesTable:RolesTable): Observable <any>{
  return this.http.put(`${this.apiUrl}/UpdateRole`,rolesTable,{ responseType: 'text'})
}
deleteRole(id: number):Observable<any>{
  return this.http.delete(`${this.apiUrl}/DeleteRole?ID=${id}`,{ responseType: 'text'})
}


////Permissions////

getPermissions(): Observable<PermissionsTable[]> {
  return this.http.get<PermissionsTable[]>(this.apiUrl+ '/GetPermissions');
}
getPermission (id:number):Observable <any> {
  return this.http.get(`${this.apiUrl}/GetPermission?id=${id}`);
}  
getPermissionByName (permission:string):Observable <any> {
  return this.http.get(`${this.apiUrl}/GetPermission?permission=${permission}`);
}  
postPermission(permissionsTable:PermissionsTable): Observable<any>{
  return this.http.post (`${this.apiUrl}/PostNewPermission`,permissionsTable,{ responseType: 'text'})
}
putPermission(permissionsTable:PermissionsTable): Observable <any>{
  return this.http.put(`${this.apiUrl}/UpdatePermission`,permissionsTable,{ responseType: 'text'})
}
deletePermission(id: number):Observable<any>{
  return this.http.delete(`${this.apiUrl}/DeletePermission?ID=${id}`,{ responseType: 'text'})
}

//RolePermissions

getRolePermissions(): Observable<rolePermissionsTable[]> {
  return this.http.get<rolePermissionsTable[]>(this.apiUrl+ '/GetAllRolePermissions');
}
updateRolePermissions(permissionRequest: any[]):Observable<any>{
  return this.http.put(`${this.apiUrl}/UpdateRolePermission`,permissionRequest,{ responseType: 'text'})
}

//UserRoles

getUserRoles():
Observable<userRolesTable[]> {
  return this.http.get<userRolesTable[]>(this.apiUrl+ '/GetAllUserRoles');
}
updateUserRoles(userRolesRequest: any[]):Observable<any>{
  return this.http.put(`${this.apiUrl}/UpdateUserRoles`,userRolesRequest,{ responseType: 'text'})
}



}
