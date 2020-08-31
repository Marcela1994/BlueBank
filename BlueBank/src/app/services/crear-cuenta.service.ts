import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CrearCuentaService {

  constructor(protected http: HttpClient) { }

  registrarCuenta() {
    this.http.get('https://randomuser.me/api/?results=25').subscribe(data => {console.log(data);
    });
  }
}
