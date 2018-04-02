import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EntityListMaintComponent } from './entity-list-maint.component';

describe('EntityListMaintComponent', () => {
  let component: EntityListMaintComponent;
  let fixture: ComponentFixture<EntityListMaintComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EntityListMaintComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EntityListMaintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
