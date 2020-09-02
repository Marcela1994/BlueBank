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


  constructor(private crearCuentaService: CrearCuentaService, private router: Router, private activatedRoute: ActivatedRoute) {
   
    // this.intentarCrearCuenta = false;
  }

  

  setCrearCuenta(){
    this.crearCuentaService.registrarCuenta(this.cliente)
      .subscribe(
        res => {
          console.log('Crear cuenta');
          console.log('Datos enviados ' + this.cliente.primerNombre);
          console.log('Datos enviados ' + this.cliente.segundoNombre);
          console.log('Datos enviados ' + this.cliente.primerApellido);
          console.log('Datos enviados ' + this.cliente.segundoApellido);
          console.log(res);
          this.router.navigate(['/clientes']);
        },
        err => console.error(err)
      )

  }

  ngOnInit(): void {
  }

}
