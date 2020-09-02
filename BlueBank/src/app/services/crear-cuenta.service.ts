import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Cuenta} from '../models/Cuenta';

@Injectable({
  providedIn: 'root'
})
export class CrearCuentaService {

  constructor(protected http: HttpClient) { }


  registrarCuenta(cuenta: Cuenta) {
    return this.http.post('https://bluebankapis.azurewebsites.net/api/cuenta', cuenta);
  }
}
