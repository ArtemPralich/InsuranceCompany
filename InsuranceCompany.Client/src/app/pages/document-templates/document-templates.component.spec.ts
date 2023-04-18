import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocumentTemplatesComponent } from './document-templates.component';

describe('DocumentTemplatesComponent', () => {
  let component: DocumentTemplatesComponent;
  let fixture: ComponentFixture<DocumentTemplatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DocumentTemplatesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DocumentTemplatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
