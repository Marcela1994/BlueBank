import { Component, OnInit } from '@angular/core';
import { CrearCuentaService } from '../../services/crear-cuenta.service';
import { Cuenta } from '../../models/Cuenta';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-crear-cuenta',
  templateUrl: './crear-cuenta.component.html',
  styleUrls: ['./crear-cuenta.component.css']
})
export class CrearCuentaComponent implements OnInit {

  // resCreacion: number;
  //intentarCrearCuenta: boolean;
  //users: any;
  cliente: Cuenta = {
    primerNombre: '',
    segundoNombre: '',
    primerApellido: '',
    segundoApellido: '',
    documento: '',
    telefono: '',
    pin: '',
    saldo: 0
  }


  constructor(private crearCuentaService: CrearCuentaService) {
   
   
    // this.intentarCrearCuenta = false;
  }


  setCrearCuenta(){
    this.crearCuentaService.registrarCuenta(this.cliente)
      .subscribe(
        res => {
          console.log(res);
        },
        err => console.error(err)
      )
  }



/*  setCrearCuenta() {
    this.intentarCrearCuenta = true;
    //this.resCreacion = this.crearCuentaService.registrarCuenta();

    console.log('Llamado al servicio crear cuenta');
    console.log('intentarCrearCuenta ' + this.intentarCrearCuenta);
    console.log('resCreacion ' + this.resCreacion);

    this.crearCuentaService.obtenerListadoClientes().subscribe(
      (data) => { // Success
        console.log('Exito al llamar al servicio');
        console.log('datos: ' + data);
        this.users = data;
      },
      (error) => {
        console.log('error al llamar al servicio');
        console.error(error);
      }
    );

    // return this.crearCuentaService.registrarCuenta(); 
  } */

  ngOnInit(): void {
  }

}
