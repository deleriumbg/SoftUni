import { Directive, ElementRef, HostListener } from '@angular/core';
import { NgForm } from '@angular/forms';

@Directive({
  selector: '[appValidateImageUrl]'
})
export class ValidateImageUrlDirective {

  constructor(
    private elRef: ElementRef,
    private form: NgForm) { }

  @HostListener('input')
  inputHandle() {
    let element: string = this.elRef.nativeElement.value;
    if (element.startsWith('http') && (element.endsWith('.png') || element.endsWith('.jpg'))) {
      this.elRef.nativeElement.style.borderColor = 'green';
      this.form.control.setErrors(null);
    } else {
      this.elRef.nativeElement.style.borderColor = 'red';
      this.form.control.setErrors({ 'image': true });
    }
  }
}
