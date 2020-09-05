import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../../services/clientes.service';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent implements OnInit {

  cuenta: string;
  pin: string;
  saldo :string;


  constructor(private clienteService: ClientesService) { }

  setConsulta(){
    this.clienteService.ConsultaSaldo(this.cuenta, this.pin)
    .subscribe(
      res => {
        console.log(res);
        console.log("respuesta saldo: " + res.saldoActual);
        this.saldo = res.saldoActual;
      },
      err => console.error(err)
    )
  }

  ngOnInit(): void {
  }

}
