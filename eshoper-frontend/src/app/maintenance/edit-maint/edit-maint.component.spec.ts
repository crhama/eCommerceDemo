import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMaintComponent } from './edit-maint.component';

describe('EditMaintComponent', () => {
  let component: EditMaintComponent;
  let fixture: ComponentFixture<EditMaintComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditMaintComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditMaintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
