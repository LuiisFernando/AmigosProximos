import { Component, ViewChild, ElementRef, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { HomeService } from './home.service';
import { AmigoService } from './../amigo/amigo.service';
import { Router } from '@angular/router';
import { Amigo } from '../shared/amigo.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  amigos: any;
  amigos2: any;

  @ViewChild('canvasEl') canvasEl: ElementRef;
  private context: CanvasRenderingContext2D;

  amigoSelecionado: Amigo;
  amigosProximos: Array<Amigo>;

  larguraCanvas: any;
  alturaCanvas: any;

  constructor(
    private toastr: ToastrService,
    private homeService: HomeService,
    private amigoService: AmigoService,
    private router: Router
  ) {
    localStorage.removeItem('AmigoQueEstou');
    this.amigos = this.amigoService.obterAmigos();
    this.obterAmigos();
  }

  ngOnInit() {
    this.context = (this.canvasEl.nativeElement as HTMLCanvasElement).getContext('2d');
  }

  obterAmigos() {
    this.amigoService.obterAmigos().subscribe(
      (data: any) => {


        this.amigos2 = data;

        if (localStorage.getItem('AmigoQueEstou') != null) {
          const nome = localStorage.getItem('AmigoQueEstou');
          this.amigoSelecionado = data.find(x => x.Nome === nome);

          this.amigoService.obterAmigosProximos(this.amigoSelecionado.ID).subscribe(
            (datas: any) => {
              this.amigosProximos = datas;
            }
          );
        }

        // pega maior PosicaoX e PosicaoY dos amigos e seta o tamanho do canvas
        this.larguraCanvas = Math.max.apply(Math, data.map(function(o) { return o.PosicaoX; })) + 20;
        this.alturaCanvas = Math.max.apply(Math, data.map(function(o) { return o.PosicaoY; })) + 20;
        document.getElementById('canvas').setAttribute('width', this.larguraCanvas);
        document.getElementById('canvas').setAttribute('height', this.alturaCanvas);

        this.drawAmigo(this.amigos2, this.amigosProximos);
      },
      err => {
          if (err.status === 401 || err.status === 402) {
              this.router.navigateByUrl('/forbidden');
          }
      }
    );
  }

  drawAmigo(amigos, amigosProximos) {
    for (const amigo of amigos) {

      if (this.amigoSelecionado && amigosProximos) {

        const amigoSelecionado = amigo.Nome === this.amigoSelecionado.Nome;
        const isAmigoProximo = amigosProximos.find(x => x.Nome === amigo.Nome);

        this.draw(amigo.PosicaoX, amigo.PosicaoY, amigoSelecionado, isAmigoProximo);
      } else {
        this.draw(amigo.PosicaoX, amigo.PosicaoY, false, false);
      }
    }
  }

  draw(x, y, amigoSelected, isAmigoProximo) {

    let classe = '';

    if (amigoSelected) {
      classe = '#000099';
    } else if (isAmigoProximo) {
      classe = '#00ff00';
    } else {
      classe = '#ff0000';
    }

    this.context.beginPath();
    this.context.arc(x, y, 20, 0, 2 * Math.PI, true);
    this.context.fillStyle = classe;
    this.context.fill();
    this.context.lineWidth = 1;
    this.context.strokeStyle = '#666666';
    this.context.stroke();
  }

  dropDownAmigoChange($event) {
    localStorage.setItem('AmigoQueEstou', $event.Nome);

    if (localStorage.getItem('AmigoQueEstou') != null) {
      const nome = localStorage.getItem('AmigoQueEstou');
      this.amigoSelecionado = this.amigos2.find(x => x.Nome === nome);
    }

    this.amigoService.obterAmigosProximos($event.ID).subscribe(
      (data: any) => {
        this.amigosProximos = data;
        this.drawAmigo(this.amigos2, data);
      }
    );
  }
}
