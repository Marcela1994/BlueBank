import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Cuenta} from '../models/Cuenta';

@Injectable({
  providedIn: 'root'
})
export class CrearCuentaService {

  constructor(protected http: HttpClient) { }


  registrarCuenta(cuenta: Cuenta) {
    
    let request = {
      "pnombre": cuenta.primerNombre, 
      "snombre": cuenta.segundoNombre, 
      "papellido": cuenta.primerApellido, 
      "sapellido": cuenta.segundoApellido, 
      "documento": cuenta.documento, 
      "nrocuenta": cuenta.telefono, 
      "clave": cuenta.pin, 
      "saldo": cuenta.saldo
  }

    return this.http.post('https://bluebankapis.azurewebsites.net/api/cuenta', request);
  }
}

