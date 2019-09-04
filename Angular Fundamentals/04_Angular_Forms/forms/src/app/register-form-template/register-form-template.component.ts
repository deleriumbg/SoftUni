import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register-form-template',
  templateUrl: './register-form-template.component.html',
  styleUrls: ['./register-form-template.component.css']
})
export class RegisterFormTemplateComponent implements OnInit {
  phoneNumbers: Array<string> = [ '+359', '+791', '+792', '+198', '+701'];
  @ViewChild('form', {static: false}) htmlForm: NgForm;;

  constructor() { }

  ngOnInit() {
  }

  register(formData) {
    if (this.htmlForm.valid) {
      this.htmlForm.reset();
    }
  }
}
