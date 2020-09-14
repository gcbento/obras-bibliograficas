import { Component, OnInit } from '@angular/core';
import { faEdit, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { Pessoa } from './pessoa.model';
import { PessoaService } from './pessoa.service';
import { PessoaListComponent } from './pessoa-list/pessoa-list.component'

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.css']
})
export class PessoaComponent implements OnInit {
  faEdit = faEdit
  faTrashAlt = faTrashAlt
  pessoa: Pessoa = {
    id: 0,
    nome: ""
  }
  listData: Array<any>

  constructor(private pessoaService: PessoaService) {
    
  }

  ngOnInit(): void {

  }

  cadastrarPessoa(): void {
    this.pessoaService.cadastrar(this.pessoa).subscribe(result => {
      if (result.data) {
        this.pessoaService.showMessage('Autor cadastrado com sucesso!')
        this.pessoaService.getAll().subscribe(result => {
          this.listData = result
        })
      }
      else {
        result.messages.forEach(msg => {
          this.pessoaService.showMessage(msg)
        });
      }
    })
  }

}
