import { AfterViewInit, Component, Input, OnChanges, OnInit, ViewChild } from '@angular/core';
import { Pessoa } from '../pessoa.model';
import { PessoaService } from '../pessoa.service';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-pessoa-list',
  templateUrl: './pessoa-list.component.html',
  styleUrls: ['./pessoa-list.component.css']
})
export class PessoaListComponent implements AfterViewInit, OnInit, OnChanges {
  @Input() listData;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  length = 10;
  pageSize = 10;
  currentPage = 1;

  pessoas: Array<Pessoa>
  displayedColumns = ['id', 'nome', 'opcoes'];

  constructor(private pessoaService: PessoaService) {
  }

  ngOnInit() {
    this.consultarPessoas()
  }

  excluirPessoa(id: number) {
    this.pessoaService.delete(id).subscribe(result => {
      if (result.data) {
        this.pessoaService.showMessage("Autor excluido com sucesso")
        this.consultarPessoas()
      }
    })
  }

  ngAfterViewInit() {
    this.paginator.page.subscribe(
      (event) => {
        this.currentPage = event.pageIndex + 1
        this.pessoaService.getAll(10, event.pageIndex + 1).subscribe(result => {
          let data = result.data
          this.pessoas = data.listData ?? []
          this.tratarNomes()
        })
      }
    );
  }

  ngOnChanges() {
    this.ngOnInit()
  }

  private tratarNomes() {
    if (this.pessoas.length > 0) {
      this.pessoas.forEach(pessoa => {
        let qtdeNomes = pessoa.nome.trim().toLocaleLowerCase().split(' ')
        let ultimoNome = "";
        let nome = ""
        let penultimoNome = ""

        if (qtdeNomes.length > 1) {
          for (let i = 0; i < qtdeNomes.length; i++) {

            if (i == qtdeNomes.length - 1) {
              ultimoNome = qtdeNomes[i].toUpperCase()
              if (this.isTipoEspeficoSobrenome(ultimoNome)) {

                penultimoNome = this.pegarPenultimoNome(nome)

                ultimoNome = `${penultimoNome} ${ultimoNome}`
                let ultimoNomeIndex = nome.lastIndexOf(' ')
                nome = nome.slice(0, ultimoNomeIndex + 1).trim();
              }
            } else {

              if (this.isSobrenome(qtdeNomes[i])) {
                nome = `${nome} ${qtdeNomes[i].charAt(0).toUpperCase() + qtdeNomes[i].slice(1)}`
              }
              else
                nome = `${nome} ${qtdeNomes[i]}`
            }
          }

          pessoa.nome = `${ultimoNome}, ${nome}`
        }
        else {
          pessoa.nome = pessoa.nome.toLocaleUpperCase()
        }

      });
    }
  }

  private pegarPenultimoNome(nomeCompleto): string {
    let penultimoNome = nomeCompleto.trim().split(' ')[nomeCompleto.trim().split(' ').length - 1].toLocaleUpperCase()
    return penultimoNome
  }

  private isSobrenome(nome): boolean {
    let preposicoes = ["da", "de", "do", "das", "dos"]
    let res = true

    preposicoes.forEach(preposicao => {
      if (preposicao == nome) {
        res = false
      }
    });

    return res
  }

  private isTipoEspeficoSobrenome(nome): boolean {
    let sobrenomes = ["filho", "filha", "neto", "neta", "sobrinho", "sobrinha", "junior"]
    let res = false

    sobrenomes.forEach(sobrenome => {
      if (sobrenome == nome.toLocaleLowerCase()) {
        res = true
      }
    });

    return res
  }

  private consultarPessoas() {
    this.pessoaService.getAll(10, this.currentPage).subscribe(result => {
      if (result.success) {
        let data = result.data
        this.pessoas = data.listData ?? []
        this.length = data.total
        this.pageSize = data.totalPage
        this.tratarNomes()
      }
    })
  }
}
