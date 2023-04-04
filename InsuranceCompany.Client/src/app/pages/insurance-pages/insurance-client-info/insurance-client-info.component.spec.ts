import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDatepicker } from '@angular/material/datepicker';
import { InsuranceClientInfoComponent } from './insurance-client-info.component';

describe('InsuranceClientInfoComponent', () => {
  let component: InsuranceClientInfoComponent;
  let fixture: ComponentFixture<InsuranceClientInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsuranceClientInfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsuranceClientInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
