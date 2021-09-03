// import { Directive, ElementRef, Renderer2 } from '@angular/core';
// import { PatternRegularEx } from '../pattern/pattern-regular-ex';

// @Directive({
//     selector: '[englishText]'
// })
// export class EnglishTextDirective {
//     constructor(elem: ElementRef, renderer: Renderer2) {
//         renderer.listen(elem.nativeElement, 'keydown', (event) => {

//             if ([46, 8, 9, 27, 13, 110, 190, 36, 95].indexOf(event.keyCode) !== -1 ||
//                 // Allow: Ctrl+A
//                 (event.keyCode === 65 && (event.ctrlKey || event.metaKey)) ||
//                 // Allow: Ctrl+C
//                 (event.keyCode === 67 && (event.ctrlKey || event.metaKey)) ||
//                 // Allow: Ctrl+V
//                 (event.keyCode === 86 && (event.ctrlKey || event.metaKey)) ||
//                 // Allow: Ctrl+X
//                 (event.keyCode === 88 && (event.ctrlKey || event.metaKey)) ||
//                 // Allow: home, end, left, right
//                 (event.keyCode >= 35 && event.keyCode <= 39)) {
//                 // let it happen, don't do anything
//                 return;
//             }
//             var regex = new RegExp(PatternRegularEx.UserNamePattern);
//             if (!regex.test(event.key))
//                 event.preventDefault();
//         })
//     }
// }
