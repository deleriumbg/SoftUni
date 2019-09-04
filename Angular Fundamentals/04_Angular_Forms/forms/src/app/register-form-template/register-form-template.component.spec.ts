import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterFormTemplateComponent } from './register-form-template.component';

describe('RegisterFormTemplateComponent', () => {
  let component: RegisterFormTemplateComponent;
  let fixture: ComponentFixture<RegisterFormTemplateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterFormTemplateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterFormTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
