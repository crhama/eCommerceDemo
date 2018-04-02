import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainMaintComponent } from './main-maint.component';

describe('MainMaintComponent', () => {
  let component: MainMaintComponent;
  let fixture: ComponentFixture<MainMaintComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainMaintComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainMaintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
