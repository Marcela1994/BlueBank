import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Retiro} from '../models/retiro';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  constructor(protected http: HttpClient) { }

  consultarClientes() {
    return this.http.get('https://localhost:44372/api/persona');
  }

  consignacion(cuenta: string, valor: number) {

    let request = {
      "valor": valor,
      "cuenta": cuenta
    };
    return this.http.post('https://bluebankapis.azurewebsites.net/api/cuentaConsignacion', request);
  }


  retiro(cuenta: Retiro) {
    let request = {
      "valor": cuenta.valor,
      "cuenta": cuenta.cuenta,
      "pin": cuenta.clave
    };
    return this.http.post('https://bluebankapis.azurewebsites.net/api/cuentaRetiro', request);
  }
}
