import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../types/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl: string = "http://localhost:5251/api/users";

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]>
  {
    return this.http.get<User[]>(this.apiUrl);
  }
  addUser(data: User) {
    return this.http.post(this.apiUrl, data)
  }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(this.apiUrl +'/'+id);
  }

  deleteUser(id: number) {
    return this.http.delete(this.apiUrl +'/'+id);
  }

  editUser(id: number, data: User){
    return this.http.put(this.apiUrl + '/' + id, data);
  }
}
