import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoardAccessorComponent } from './board-accessor.component';

describe('BoardAccessorComponent', () => {
  let component: BoardAccessorComponent;
  let fixture: ComponentFixture<BoardAccessorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BoardAccessorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BoardAccessorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
