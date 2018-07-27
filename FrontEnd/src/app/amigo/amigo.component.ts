import { ToastrService } from 'ngx-toastr';
import { AmigoService } from './amigo.service';
import { Component, OnInit, TemplateRef, OnDestroy } from '@angular/core';
import { NgForm, NgModel } from '@angular/forms';

import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { DataTableDirective } from 'angular-datatables';

import { Observable, Subject } from 'rxjs';

import * as $ from 'jquery';

@Component({
  selector: 'app-amigo',
  templateUrl: './amigo.component.html',
  styleUrls: ['./amigo.component.css']
})
export class AmigoComponent implements OnInit, OnDestroy {

  amigos: any = [];
  amigoSelecionado: any;

  modalRef: BsModalRef;

  amigosProximos: Observable<Object>;
  amigosProximosSelecionados = [];

  dtOptions: DataTables.Settings = {};
  private datatableElement: DataTableDirective;

  dtTrigger: Subject<any> = new Subject<any>();

  mensagemErro = '';

  constructor(
    private amigoService: AmigoService,
    private modalService: BsModalService,
    private toastrService: ToastrService
  ) { }

  ngOnInit() {
    this.obterAmigos();
  }

  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }

  displayToConsole(datatableElement: DataTableDirective): void {
    datatableElement.dtInstance.then((dtInstance: DataTables.Api) => console.log(dtInstance));
  }

  openModal(template: TemplateRef<any>) {

    this.amigosProximosSelecionados = null;
    this.amigosProximos = null;
    this.amigoSelecionado = null;
    this.mensagemErro = '';

    // this.amigosProximos = this.amigoService.obterAmigos();

    this.modalRef = this.modalService.show(template);
  }

  openModalEdit(template: TemplateRef<any>, ID) {

    this.amigoSelecionado  = this.amigos.find(x => x.ID === ID);
    this.amigoService.obterAmigosProximos(ID).subscribe(
      (data: any) => {
        this.amigoSelecionado.AmigosProximos = data;
        this.modalRef = this.modalService.show(template);
      }
    );
  }

  obterAmigos() {


    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 2
    };

    this.amigoService.obterAmigos().subscribe(
      (data: any) => {
        this.amigos = data;
        console.log(this.amigos);
        this.dtTrigger.next();
      }
    );
  }

  dropDownChange($event) {
    this.amigosProximosSelecionados =  $event;
  }

  onSubmit(nome, x, y) {

    if (!nome || !x || !y) {
      this.toastrService.error('Preencha todos os campos');
      return;
    }

    const amigo = {
      Nome: nome,
      PosicaoX: x,
      PosicaoY: y,
      amigosProximos: this.amigosProximosSelecionados
    };

    this.amigoService.cadastrarAmigo(amigo).subscribe(
      (data: any) => {
        this.obterAmigos();
        this.modalService.hide(1);
        this.toastrService.success('Amigo cadastrado com sucesso');
      },
      err => {
        this.mensagemErro = err.error.Message;
      }
    );
  }

  excluirAmigo(ID) {
    console.log(ID);
    const amigo  = this.amigos.find(x => x.ID === ID);
    this.amigoService.excluirAmigo(amigo).subscribe(
      succ => { this.obterAmigos(); }
    );
  }

}
