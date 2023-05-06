import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { InsuranceSurvey } from 'src/app/models/InsuranceSurvey';
import { Question } from 'src/app/models/Question';
import { SurveyService } from 'src/app/service/SurveyService';

@Component({
  selector: 'app-survey-editor',
  templateUrl: './survey-editor.component.html',
  styleUrls: ['./survey-editor.component.css']
})
export class SurveyEditorComponent  implements OnInit {
  insuranceSurveys: InsuranceSurvey[] = [];
  selectedSurvey: InsuranceSurvey = new InsuranceSurvey("");
  questionSurveys: Question[] = [];

  constructor(public insuranceSurveyService: SurveyService, public dialog: MatDialog, private toastr: ToastrService) 
  {}

  ngOnInit(): void {
    this.loadSurveys();
  }

  loadSurveys() {
    this.insuranceSurveyService.GetAllInsuranceSurveys().subscribe(res => {
      this.insuranceSurveys = res;
      this.selectedSurvey = this.insuranceSurveys[0];
      this.toastr.info('Запрос выполнен успешно!', 'Успешно');
    });
  }

  openDialogQuestion() {
    const dialogRef = this.dialog.open(DialogCreateQuestionPopup,  {
      data: this.selectedSurvey});

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log(this.selectedSurvey)
        this.selectedSurvey.questions.push(result);
      }
    });
  }

  openDialogSurvey() {
    const dialogRef = this.dialog.open(DialogCreateSurveyPopup);

    dialogRef.afterClosed().subscribe(result => {
      this.loadSurveys();
    });
  }

  choiceSurvey(survey: InsuranceSurvey) {
    this.selectedSurvey = survey;
  }
}


@Component({
  selector: 'CreateQuestionPopup',
  templateUrl: 'CreateQuestionPopup.html',
  styleUrls: ['./survey-editor.component.css']
})
export class DialogCreateQuestionPopup {
  addQuestion: Question = new Question("");

  constructor(@Inject(MAT_DIALOG_DATA) public selectedSurvey: InsuranceSurvey, public dialogRef: MatDialogRef<DialogCreateQuestionPopup>, public insuranceSurveyService: SurveyService,) 
  {console.log(selectedSurvey);}

  close(){
    this.dialogRef.close();
  }

  create(){
    console.log(this.addQuestion);
    this.dialogRef.close(this.addQuestion);
  }
}


@Component({
  selector: 'CreateSurveyPopup',
  templateUrl: 'CreateSurveyPopup.html',
  styleUrls: ['./survey-editor.component.css']
})
export class DialogCreateSurveyPopup {
  addSurvey: InsuranceSurvey = new InsuranceSurvey("");

  constructor(public insuranceSurveyService: SurveyService, public dialogRef: MatDialogRef<DialogCreateSurveyPopup>, private toastr: ToastrService) 
  {}

  close(){
    this.dialogRef.close();
  }

  create(){
    this.insuranceSurveyService.CreateSurvey(this.addSurvey).subscribe((data) => {
      this.close();
    },
        error => {
          alert("Ошибка сохранения!")
      });
  }
}