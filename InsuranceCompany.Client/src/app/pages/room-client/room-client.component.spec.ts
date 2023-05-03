import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomClientComponent } from './room-client.component';

describe('RoomClientComponent', () => {
  let component: RoomClientComponent;
  let fixture: ComponentFixture<RoomClientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomClientComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RoomClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
