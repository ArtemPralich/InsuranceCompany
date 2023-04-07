import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuranceBankDataComponent } from './insurance-bank-data.component';

describe('InsuranceBankDataComponent', () => {
  let component: InsuranceBankDataComponent;
  let fixture: ComponentFixture<InsuranceBankDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsuranceBankDataComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsuranceBankDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
