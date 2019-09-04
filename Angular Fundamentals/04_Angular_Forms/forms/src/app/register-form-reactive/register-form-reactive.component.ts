import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register-form-reactive',
  templateUrl: './register-form-reactive.component.html',
  styleUrls: ['./register-form-reactive.component.css']
})
export class RegisterFormReactiveComponent implements OnInit {
  phoneNumbers: Array<string> = [ '+359', '+791', '+792', '+198', '+701'];
  form;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.form = this.fb.group({
      fullName: ['', [Validators.required, Validators.pattern(/[A-Z][a-z]+\s[A-Z][a-z]+/)]],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.pattern(/[0-9]{9}/)]],
      jobTitle: [''],
      password: ['', [Validators.required, Validators.pattern(/^[A-Za-z0-9]{3,16}$/)]],
      confirmPassword: ['', Validators.required],
      imageUrl: ['', [Validators.required, Validators.pattern(/http.*(.jpg|.png)/)]]
    })
  }

  register() {
    console.log(this.form)
  }

  get f() {
    return this.form.controls;
  }
}
