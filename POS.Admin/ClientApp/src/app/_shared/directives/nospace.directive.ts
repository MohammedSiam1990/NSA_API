import { Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
    selector: '[nospace]'
})
export class NoSpaceDirective {
    constructor(elem: ElementRef, renderer: Renderer2) {
        renderer.listen(elem.nativeElement, 'keydown', (event) => {
            if (event.keyCode == 32 || event.keyCode == 13)
                event.preventDefault();
        })
    }
}
