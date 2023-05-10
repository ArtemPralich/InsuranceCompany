import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistationEmployeeComponent } from './registation-employee.component';

describe('RegistationEmployeeComponent', () => {
  let component: RegistationEmployeeComponent;
  let fixture: ComponentFixture<RegistationEmployeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistationEmployeeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegistationEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
