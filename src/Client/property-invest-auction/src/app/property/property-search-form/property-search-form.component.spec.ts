import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertySearchFormComponent } from './property-search-form.component';

describe('PropertySearchFormComponent', () => {
  let component: PropertySearchFormComponent;
  let fixture: ComponentFixture<PropertySearchFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PropertySearchFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertySearchFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
