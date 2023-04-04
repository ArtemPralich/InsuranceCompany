import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuranceSuraveysComponent } from './insurance-suraveys.component';

describe('InsuranceSuraveysComponent', () => {
  let component: InsuranceSuraveysComponent;
  let fixture: ComponentFixture<InsuranceSuraveysComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsuranceSuraveysComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsuranceSuraveysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
