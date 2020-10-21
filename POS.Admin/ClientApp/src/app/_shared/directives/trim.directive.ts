import { Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
    selector: '[trim]'
})
export class TrimDirective {
    constructor(elem: ElementRef, renderer: Renderer2) {
        renderer.listen(elem.nativeElement, 'focusout', (event) => {
            var value = elem.nativeElement.value.trim();
            renderer.setProperty(elem.nativeElement, 'value', value);
            elem.nativeElement.dispatchEvent(new Event("input"));
        })
    }
}
