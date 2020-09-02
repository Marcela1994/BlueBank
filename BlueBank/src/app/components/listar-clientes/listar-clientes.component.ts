import { Component, OnInit } from '@angular/core';
import {ClientesService} from '../../services/clientes.service';
import {Cliente} from '../../models/Cliente';

@Component({
  selector: 'app-listar-clientes',
  templateUrl: './listar-clientes.component.html',
  styleUrls: ['./listar-clientes.component.css']
})
export class ListarClientesComponent implements OnInit {

  clientes: any = [];

  constructor(private clienteService: ClientesService) { }

  ngOnInit(): void {
    this.clienteService.consultarClientes()
        .subscribe(
          res => {
            console.log('***********************************');
            console.log('Respuesta del api get clientes');
            console.log(res);
            this.clientes =  res;
            console.log('***********************************');
          },
          err => console.log(err)
        )
  }

}
