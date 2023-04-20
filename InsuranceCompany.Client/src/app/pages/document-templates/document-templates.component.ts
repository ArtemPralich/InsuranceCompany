import { Component, OnDestroy, OnInit } from '@angular/core';
import { Editor } from 'ngx-editor';
import { Template } from 'src/app/models/Template';
import { DocumentService } from 'src/app/service/DocumentService';

@Component({
  selector: 'app-document-templates',
  templateUrl: './document-templates.component.html',
  styleUrls: ['./document-templates.component.css']
})
export class DocumentTemplatesComponent implements OnInit, OnDestroy {
  editor: Editor | undefined;
  html = '<b> qwe<b>';
  templates: Template[];
  selected: Template= new Template("");;

  constructor(public documentService: DocumentService, ) 
  {}

  ngOnInit(): void {
    this.editor = new Editor();

    this.documentService.GetAllTemplates().subscribe(res => {
      this.templates = res;
      console.log(this.templates);
    });
  }

  ngOnDestroy(): void {
    this.editor?.destroy();
  }
  save(): void{
    console.log(this.selected);
    this.documentService.UpdateTemplate(this.selected).subscribe((data)=>{
    },
    error=>{
      alert("Creare kind failed")
    });
  }
}
