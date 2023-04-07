import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuranceDocumentsComponent } from './insurance-documents.component';

describe('InsuranceDocumentsComponent', () => {
  let component: InsuranceDocumentsComponent;
  let fixture: ComponentFixture<InsuranceDocumentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsuranceDocumentsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsuranceDocumentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
