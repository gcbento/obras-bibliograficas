import { Component, OnInit } from '@angular/core';
import { faEdit, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { PessoaService } from './pessoa.service';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.css']
})
export class PessoaComponent implements OnInit {
  faEdit = faEdit
  faTrashAlt = faTrashAlt
  pessoas:any = []

  constructor(private pessoaService: PessoaService) { }

  ngOnInit(): void {
    // this.pessoas = this.pessoaService.getAll().subscribe(()=>{
    //   console.log(this.pessoas)
    // })
    

  }

}
