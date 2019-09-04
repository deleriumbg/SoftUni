import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterFormReactiveComponent } from './register-form-reactive.component';

describe('RegisterFormReactiveComponent', () => {
  let component: RegisterFormReactiveComponent;
  let fixture: ComponentFixture<RegisterFormReactiveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterFormReactiveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterFormReactiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
