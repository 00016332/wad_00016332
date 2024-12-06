import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { KeyStore } from '../types/keystore';

@Injectable({
  providedIn: 'root'
})
export class KeystoreService {
  apiUrl: string = "http://localhost:5251/api/keystores";

  constructor(private http: HttpClient) { }

  getKeys() {
    return this.http.get<KeyStore[]>(this.apiUrl);
  }

  deleteKey(id: number) {
    return this.http.delete(this.apiUrl + '/' + id);
  }

  getKey(id: number) {
    return this.http.get(this.apiUrl + '/' + id);
  }

  addKey(data: KeyStore) {
    return this.http.post(this.apiUrl, data)
  }

  editKey(id: number, data: KeyStore) {
    return this.http.put(this.apiUrl + '/' + id, data);
  }
}
