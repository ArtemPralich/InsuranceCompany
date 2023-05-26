import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { InsuranceSurvey } from 'src/app/models/InsuranceSurvey';
import { Question } from 'src/app/models/Question';
import { SurveyService } from 'src/app/service/SurveyService';
import { QuestionTypeService } from 'src/app/service/QuestionTypeService';
import { QuestionType } from 'src/app/models/QuestionType';
import { InsuranceRate } from 'src/app/models/InsuranceRate';
import { Answer } from 'src/app/models/Answer';
import { InsuranceRateService } from 'src/app/service/InsuranceRateService';

@Component({
  selector: 'app-survey-editor',
  templateUrl: './survey-editor.component.html',
  styleUrls: ['./survey-editor.component.css']
})
export class SurveyEditorComponent  implements OnInit {
  insuranceSurveys: InsuranceSurvey[] = [];
  selectedSurvey: InsuranceSurvey = new InsuranceSurvey("");
  questionSurveys: Question[] = [];
  selectedAnswersForDelete: Answer[] = [];
  insuranceRates: InsuranceRate[] = [];
  selectedInsuranceRate: InsuranceRate[] = [];

   constructor(public insuranceSurveyService: SurveyService, public dialog: MatDialog, public insuranceRateService: InsuranceRateService, private toastr: ToastrService) 
  {}

  ngOnInit(): void {
    this.loadSurveys();

    this.insuranceRateService.GetAllInsuranceRequests().subscribe(res => {
      this.insuranceRates = res;
      console.log(this.insuranceRates)
    });
  }

  loadSurveys() {
    this.insuranceSurveyService.GetAllInsuranceSurveys().subscribe(res => {
      this.insuranceSurveys = res;
      
      this.choiceSurvey(this.insuranceSurveys[0]);
      this.insuranceSurveys.forEach(element => {
        element.questions.forEach(question =>{
          question.selectedAnswersForDelete = [];
        })
      });
      console.log(this.insuranceSurveys);
    });
  }

  updateSurvey(){
    this.selectedSurvey.insuranceRates = this.selectedInsuranceRate;
    this.insuranceSurveyService.UpdateInsuranceSurvey(this.selectedSurvey).subscribe(res => {
      
    });
  }

  openDialogCreateAnswer(question: Question){
    const dialogRef = this.dialog.open(DialogCreateAnswerPopup,  {
      data: this.selectedSurvey});

      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          console.log(this.selectedSurvey)
          question.answers.push(result);
        }
    });
  }

  deleteSurvey(){
    console.log(this.selectedSurvey);
    this.insuranceSurveyService.DeleteInsuranceSurvey(this.selectedSurvey.id).subscribe((data) => {
      this.toastr.success('Успешно удалено', 'Успешно!');
      this.loadSurveys();
    },
        error => {
          this.toastr.error('Ошибка удаления', 'Ошибка!');
      });
  }

  deleteAnswers(question: Question) {
    console.log(question.selectedAnswersForDelete);
    const filteredAnswers = question.answers.filter(answer => !question.selectedAnswersForDelete.includes(answer));
    // заменяем исходный массив на новый
    question.answers.splice(0, question.answers.length, ...filteredAnswers);
    console.log(question.answers);
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
  
  deleteQuestion(question: Question, survey: InsuranceSurvey) {
    const index = survey.questions.indexOf(question);
    survey.questions.splice(index, 1);
  }

  choiceSurvey(survey: InsuranceSurvey) {
    this.selectedInsuranceRate = [];
    this.selectedSurvey = survey;
    this.insuranceRates.forEach(element => {
      this.selectedSurvey.insuranceRates.forEach(element2 => {
        if(element.id == element2.id){
          this.selectedInsuranceRate.push(element);
        }
      })
    });
    console.log(this.selectedInsuranceRate)
  }

  compareRates(rate1: any, rate2: any) {
    return rate1 && rate2 ? rate1.id === rate2.id : rate1 === rate2;
  }
}


@Component({
  selector: 'CreateQuestionPopup',
  templateUrl: 'CreateQuestionPopup.html',
  styleUrls: ['./survey-editor.component.css']
})
export class DialogCreateQuestionPopup {
  addQuestion: Question = new Question("");
  questionTypes: QuestionType[] = [];
  selectedQuestionTypes : QuestionType = new QuestionType("");

  constructor(@Inject(MAT_DIALOG_DATA) public selectedSurvey: InsuranceSurvey, 
    public dialogRef: MatDialogRef<DialogCreateQuestionPopup>, 
    public insuranceSurveyService: SurveyService,
    public questionTypeService: QuestionTypeService,) 
  {
    console.log(selectedSurvey);
    this.loadQuestionType();
  }

  loadQuestionType() {
    this.questionTypeService.GetAllQuestionType().subscribe(res => {
      this.questionTypes = res;
    });
  }

  close(){
    this.dialogRef.close();
  }

  create(){
    this.addQuestion.questionTypeId = this.selectedQuestionTypes.id;
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
      this.toastr.success('Успешно добавлено', 'Успешно!');
    },
        error => {
          this.toastr.error('Ошибка добавления', 'Ошибка!');
      });
  }
}

@Component({
  selector: 'CreateAnswerPopup',
  templateUrl: 'CreateAnswerPopup.html',
  styleUrls: ['./survey-editor.component.css']
})
export class DialogCreateAnswerPopup {
  addAnswer: Answer = new Answer("", "");

  constructor(public insuranceSurveyService: SurveyService, public dialogRef: MatDialogRef<DialogCreateSurveyPopup>) 
  {}

  close(){
    this.dialogRef.close();
  }

  create(){
    this.dialogRef.close(this.addAnswer);
  }
}