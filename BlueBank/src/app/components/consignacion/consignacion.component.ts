import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../../services/clientes.service';

@Component({
  selector: 'app-consignacion',
  templateUrl: './consignacion.component.html',
  styleUrls: ['./consignacion.component.css']
})
export class ConsignacionComponent implements OnInit {

  cuenta: string;
  valor: number;
  respuesta: any = [];
  mensaje: string;

  constructor(private clienteService: ClientesService) { }


  setConsignacion(){
    this.clienteService.consignacion(this.cuenta, this.valor)
    .subscribe(
      res => {
        console.log(res);
        this.respuesta = res;
        this.mensaje= "Se ha consignado a " + this.respuesta[0].nombre +" "+ this.respuesta[0].apellido + " a la cuenta " +this.respuesta[0].numeroDeCuenta+ " el valor de "+ " "+this.valor;
      },
      err => console.error(err)
    )
  }

  ngOnInit(): void {
  }

}
