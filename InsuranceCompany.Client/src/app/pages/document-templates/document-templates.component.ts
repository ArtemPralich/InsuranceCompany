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
  addTemp: boolean=false;

  constructor(public documentService: DocumentService, ) 
  {}

  ngOnInit(): void {
    this.editor = new Editor();
    this.getAllTemplates();
  }

  ngOnDestroy(): void {
    this.editor?.destroy();
  }

  getAllTemplates() {
    this.documentService.GetAllTemplates().subscribe(res => {
      this.templates = res;
      console.log(this.templates);
    });
  }

  save(): void{
    if(this.addTemp) {
      this.documentService.CreateTemplate(this.selected).subscribe((data)=>{        
        this.selected.text = "";
      },
      error=>{
        alert("Ошибка сохранения!")
      });
    }
    else {
      this.documentService.UpdateTemplate(this.selected).subscribe((data)=>{
        this.selected.text = "";
      },
      error=>{
        alert("Ошибка сохранения!")
      });
    }
    this.backAdd();
    this.getAllTemplates();
  }

  addTemplate(): void {
    this.addTemp = true;
  }

  backAdd(): void {
    this.addTemp = false;
  }
}
