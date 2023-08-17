import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogViwerComponent } from './dialog-viwer.component';

describe('DialogViwerComponent', () => {
  let component: DialogViwerComponent;
  let fixture: ComponentFixture<DialogViwerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogViwerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DialogViwerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
