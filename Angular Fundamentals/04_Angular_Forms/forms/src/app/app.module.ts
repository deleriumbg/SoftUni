import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { RegisterFormTemplateComponent } from './register-form-template/register-form-template.component';
import { ValidateImageUrlDirective } from './validate-image-url.directive';

@NgModule({
  declarations: [
    AppComponent,
    RegisterFormTemplateComponent,
    ValidateImageUrlDirective
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
