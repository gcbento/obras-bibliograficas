import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component'
import { PessoaComponent } from './components/pessoa/pessoa.component'

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "autores",
    component: PessoaComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
