import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { BodyComponent } from './components/body/body.component';
import { CrearCuentaComponent } from './components/crear-cuenta/crear-cuenta.component';
import { ConsignacionComponent } from './components/consignacion/consignacion.component';
import { RetiroComponent } from './components/retiro/retiro.component';
import { ConsultaComponent } from './components/consulta/consulta.component';
import { CrearCuentaService } from './services/crear-cuenta.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    BodyComponent,
    CrearCuentaComponent,
    ConsignacionComponent,
    RetiroComponent,
    ConsultaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [CrearCuentaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
