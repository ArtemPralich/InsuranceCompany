import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuredPersonsComponent } from './insured-persons.component';

describe('InsuredPersonsComponent', () => {
  let component: InsuredPersonsComponent;
  let fixture: ComponentFixture<InsuredPersonsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsuredPersonsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsuredPersonsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
