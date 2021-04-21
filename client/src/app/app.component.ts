import { Component } from '@angular/core';
import { SwiperOptions } from 'swiper';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Nike';
  // https://swiperjs.com/swiper-api#parameters
  config: SwiperOptions = {
    // centerInsufficientSlides: false,
    freeMode: true,

    // pagination: { el: '.swiper-pagination', clickable: true },
    // navigation: {
    //   nextEl: '.swiper-button-next',
    //   prevEl: '.swiper-button-prev',
    // },
    // spaceBetween: 1,
  };
}
