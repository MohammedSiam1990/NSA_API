import { Directive, HostListener, ElementRef, Input, Renderer2 } from "@angular/core";
@Directive({
  selector: "[special3Char]"
})
export class special3Char {
  regexStr = "^[a-zA-Z0-9_!@#*%$&(){}.,><^+-=`~]*$";
  @Input() isAlphaNumeric: boolean;

  constructor(private el: ElementRef, renderer: Renderer2) {
    renderer.listen(el.nativeElement, 'keydown', (event) => {
        if (event.keyCode == 222 || event.keyCode == 220)
            event.preventDefault();
    })
  }

//   @HostListener("keypress", ["$event"]) onKeyPress(event) {
//     return new RegExp(this.regexStr).test(event.key);
//   }

  @HostListener("paste", ["$event"]) blockPaste(event: KeyboardEvent) {
    this.validateFields(event);
  }

  validateFields(event) {
    setTimeout(() => {
      this.el.nativeElement.value = this.el.nativeElement.value
        .replace(/[""''\\| ]/g, "")
        .replace(/\s/g, "");
      event.preventDefault();
    }, 100);
  }
  
}