import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SessionOverViewComponent } from './session-over-view.component';

describe('SessionOverViewComponent', () => {
  let component: SessionOverViewComponent;
  let fixture: ComponentFixture<SessionOverViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SessionOverViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SessionOverViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
