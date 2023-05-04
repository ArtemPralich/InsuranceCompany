import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Editor } from 'ngx-editor';
import { InsuranceRate } from 'src/app/models/InsuranceRate';
import { Template } from 'src/app/models/Template';
import { DocumentService } from 'src/app/service/DocumentService';
import { InsuranceRateService } from 'src/app/service/InsuranceRateService';

@Component({
  selector: 'app-document-templates',
  templateUrl: './document-templates.component.html',
  styleUrls: ['./document-templates.component.css']
})
export class DocumentTemplatesComponent implements OnInit, OnDestroy {
  editor: Editor | undefined;
  html = '<b> qwe<b>';
  templates: Template[];
  selected: Template = new Template("");
  editorConfig = {
    bypassHTML: true
  };
  addTemp: boolean=false;
  insuranceRates: InsuranceRate[] = [];
  selectedInsuranceRate: InsuranceRate[] = [];
  selectedItem: boolean=false;

  constructor(public documentService: DocumentService, public insuranceRateService: InsuranceRateService,) 
  {}

  ngOnInit(): void {
    this.editor = new Editor();
    this.getAllTemplates();

    this.insuranceRateService.GetAllInsuranceRequests().subscribe(res => {
      this.insuranceRates = res;
      
    });
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

    save(): void {
      this.selected.insuranceRates = this.selectedInsuranceRate.map(obj => obj.id);
      if (this.addTemp) {
          this.documentService.CreateTemplate(this.selected).subscribe((data) => {
            this.selected.text = "";
            this.getAllTemplates();
          },
              error => {
                  alert("Ошибка сохранения!")
              });
      }
      else {
          this.documentService.UpdateTemplate(this.selected).subscribe((data) => {
            this.selected.text = "";
            this.getAllTemplates();
          },
              error => {
                  alert("Ошибка сохранения!")
              });
      }
      this.backAdd();
      this.getAllTemplates();
    }

    addTemplate(): void {
        this.addTemp = true;
        this.selected = new Template("");
        this.selected.title = "";
        this.selected.text = "";
        this.selectedItem = true;
        this.selectedInsuranceRate = [];
    }

    deleteTemplate(): void {
      this.documentService.DeleteTeplate(this.selected.id).subscribe((data) => {
        this.selected.title = "";
        this.selected.text = "";
        this.selectedItem = false;
        this.getAllTemplates();
    },
        error => {
            alert("Ошибка удаления!")
        });
    }

    onSelectionChange() {
      console.log(this.selected)
      this.selectedInsuranceRate = this.insuranceRates.filter(rate => {
        return this.selected.insuranceRates.includes(rate.id);
      });
    }

    backAdd(): void {
        this.addTemp = false;
        this.selectedItem = false;
    }
}
