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

  constructor(private clienteService: ClientesService) { }


  setConsignacion(){
    this.clienteService.consignacion(this.cuenta, this.valor)
    .subscribe(
      res => {
        console.log(res);
      },
      err => console.error(err)
    )
  }

  ngOnInit(): void {
  }

}
