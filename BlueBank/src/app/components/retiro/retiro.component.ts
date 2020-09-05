import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../../services/clientes.service';
import { Retiro } from '../../models/retiro'

@Component({
  selector: 'app-retiro',
  templateUrl: './retiro.component.html',
  styleUrls: ['./retiro.component.css']
})
export class RetiroComponent implements OnInit {

  retiro: Retiro = {
    cuenta: '',
    clave: '',
    valor: 0
  };
  
  respuesta: any = [];
  mensaje: string;

  constructor(private clienteService: ClientesService) { }

  setRetiro(){
    console.log('datos del retiro: ');
    console.log(this.retiro.cuenta);
    console.log(this.retiro.valor);
    this.clienteService.retiro(this.retiro)
    .subscribe(

      res => {
        console.log('Llamado exitoso a API retirar');
        this.respuesta = res;
        console.log(res);
        this.mensaje = this.respuesta[0].mensaje;
      },
      err => console.error(err)
    )
  }

  ngOnInit(): void {
  }

}
