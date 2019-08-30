import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PolicyItemsComponent } from './policy-items.component';

describe('PolicyItemsComponent', () => {
  let component: PolicyItemsComponent;
  let fixture: ComponentFixture<PolicyItemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PolicyItemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PolicyItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
