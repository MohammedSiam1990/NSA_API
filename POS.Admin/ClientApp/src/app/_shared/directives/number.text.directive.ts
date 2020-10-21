// import { Directive, ElementRef, Renderer2 } from '@angular/core';
// import { PatternRegularEx } from '../pattern/pattern-regular-ex';

// @Directive({
//     selector: '[numberText]'
// })
// export class NumberTextDirective {
//     constructor(elem: ElementRef, renderer: Renderer2) {

//         renderer.listen(elem.nativeElement, 'keydown', (event) => {
//             var regex = new RegExp(PatternRegularEx.EnglishAlphaNumericPattern);
//             if (!regex.test(event.key))
//                 event.preventDefault();
//         })
//     }
// }