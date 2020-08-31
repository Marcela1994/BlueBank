import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import{ CrearCuentaComponent} from './components/crear-cuenta/crear-cuenta.component'; 
import {BodyComponent} from './components/body/body.component';
import {AppComponent} from './app.component';
import {ConsignacionComponent} from './components/consignacion/consignacion.component';
import {ConsultaComponent} from './components/consulta/consulta.component';
import {RetiroComponent} from './components/retiro/retiro.component';

const routes: Routes = [
  { path: 'cuenta', component: CrearCuentaComponent},
  { path: 'index', component: BodyComponent},
  { path: 'consignacion', component: ConsignacionComponent},
  { path: 'consulta', component: ConsultaComponent},
  { path: 'retiro', component: RetiroComponent},
  { path: '**', component: BodyComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
