import { Component, OnInit } from '@angular/core';
import {CrearCuentaService } from '../../services/crear-cuenta.service';

@Component({
  selector: 'app-crear-cuenta',
  templateUrl: './crear-cuenta.component.html',
  styleUrls: ['./crear-cuenta.component.css']
})
export class CrearCuentaComponent implements OnInit {

   resCreacion: number;
   intentarCrearCuenta: boolean;

   constructor(private crearCuentaService: CrearCuentaService) {
     this.intentarCrearCuenta = false;
   }

  setCrearCuenta() {
    this.intentarCrearCuenta = true;
    //this.resCreacion = this.crearCuentaService.registrarCuenta();

    console.log('Llamado al servicio crear cuenta');
    console.log('intentarCrearCuenta ' + this.intentarCrearCuenta);
    console.log('resCreacion ' + this.resCreacion);

    return this.crearCuentaService.registrarCuenta(); 
  }

  ngOnInit(): void{
  }

}
