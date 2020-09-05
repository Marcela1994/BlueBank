import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Retiro} from '../models/retiro';
import {ConsultaSaldo} from '../models/ConsultaSaldo';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  constructor(protected http: HttpClient) { }

  consultarClientes() {
    return this.http.get('https://blueapisnet.azurewebsites.net/api/persona');
  }

  consignacion(cuenta: string, valor: number) {

    let request = {
      "cuenta": cuenta,
      "valor": valor
    };
    return this.http.post('https://blueapisnet.azurewebsites.net/api/consignacion', request);
  }


  retiro(cuenta: Retiro) {
    let request = {
      "cuenta": cuenta.cuenta,
      "valor": cuenta.valor,
      "pin": cuenta.clave
    };
    return this.http.post('https://blueapisnet.azurewebsites.net/api/retiro', request);
  }

  ConsultaSaldo(cuenta: string, pin: string) {
    let request = {
      "cuenta": cuenta,
      "pin": pin
    };
    console.log(request);
    
    return this.http.post<any>('https://blueapisnet.azurewebsites.net/api/consultarSaldo', request);
  }

}
