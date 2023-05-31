import { Component, ElementRef } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  constructor(private el: ElementRef) {}

  // toggleClass() {
  //   const element = this.el.nativeElement.querySelector('.menu-slide');
  //   if (element.classList.contains('disp')) {
  //     element.classList.remove('disp');
  //   } else {
  //     element.classList.add('disp');
  //   }
  // }
}
