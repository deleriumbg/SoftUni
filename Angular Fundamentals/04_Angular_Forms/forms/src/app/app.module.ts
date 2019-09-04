import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { RegisterFormTemplateComponent } from './register-form-template/register-form-template.component';
import { ValidateImageUrlDirective } from './validate-image-url.directive';
import { RegisterFormReactiveComponent } from './register-form-reactive/register-form-reactive.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterFormTemplateComponent,
    ValidateImageUrlDirective,
    RegisterFormReactiveComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
