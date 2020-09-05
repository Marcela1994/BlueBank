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
      "primer_nombre": cuenta.primerNombre, 
      "segundo_nombre": cuenta.segundoNombre, 
      "primer_apellido": cuenta.primerApellido, 
      "segundo_apellido": cuenta.segundoApellido, 
      "documento": cuenta.documento, 
      "nro_cuenta": cuenta.telefono, 
      "clave": cuenta.pin, 
      "saldo": cuenta.saldo
  }
  console.log(request);

    return this.http.post('https://blueapisnet.azurewebsites.net/api/cuenta', request);
  }
}

