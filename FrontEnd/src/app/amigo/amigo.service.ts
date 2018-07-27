import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AmigoService {

  readonly rootUrl = 'http://localhost:58272';

  constructor(
    private http: HttpClient,
  ) { }

  obterAmigos() {
    return this.http.get(this.rootUrl + '/api/amigo/obterAmigos');
  }

  cadastrarAmigo(amigo) {
    return this.http.post(this.rootUrl + '/api/amigo/cadastrar', amigo);
  }

  obterAmigosProximos(ID) {
    return this.http.get(this.rootUrl + '/api/amigo/obterAmigosProximos/' +  ID);
  }

  excluirAmigo(amigo) {
    return this.http.post(this.rootUrl + '/api/amigo/excluir/', amigo);
  }

}
