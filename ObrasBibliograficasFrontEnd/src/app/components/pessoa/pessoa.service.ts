import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pessoa } from './pessoa.model';
import { MatSnackBar } from '@angular/material/snack-bar'

@Injectable({
  providedIn: 'root'
})
export class PessoaService {

  baseUrl: string = "https://obrasbibliograficas.azurewebsites.net/api/pessoa"

  constructor(private http: HttpClient, private snackBar: MatSnackBar) { }

  getAll(pageSize: number = 10, pageNumber: number = 1): Observable<any> {
    return this.http.get(`${this.baseUrl}?pageNumber=${pageNumber}&pageSize=${pageSize}`)
  }

  cadastrar(pessoa: Pessoa): Observable<any> {
    return this.http.post<Pessoa>(this.baseUrl, pessoa)
  }

  delete(id: number): Observable<any>{
    return this.http.delete(`${this.baseUrl}?id=${id}`)
  }

  showMessage(msg: string): void {
    this.snackBar.open(msg, '', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }
}

