import {
  Component,
  OnInit,
  HostListener,
  ViewChild,
  ElementRef,
  AfterViewInit,
} from '@angular/core';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-ngbd-carousel-navigation',
  templateUrl: './ngbd-carousel-navigation.component.html',
  styleUrls: ['./ngbd-carousel-navigation.component.scss'],
  providers: [NgbCarouselConfig], // add NgbCarouselConfig to the component providers
})
export class NgbdCarouselNavigationComponent implements AfterViewInit {
  @ViewChild('carousel') divView: ElementRef;
  showNavigationArrows = false;
  showNavigationIndicators = false;

  discounts = [
    {
      name: 'Free Shipping & 60-Day Free Returns',
      sub: 'Shop All Our New Markdowns',
    },
    { name: 'Save Up to 40%', sub: 'Join Now' },
  ];
  constructor(config: NgbCarouselConfig) {
    config.interval = 2000;
    // customize default values of carousels used by this component tree
    config.showNavigationArrows = true;
    config.showNavigationIndicators = true;
  }

  // ngOnInit(): void {}

  ngAfterViewInit() {
    // this.divView.showNavigationArrows = true;
    // this.divView._container.nativeElement.scrollHeight = 70;
    console.log(this.divView);
    // this.divView.nativeElement.innerHTML = 'Hello Angular 10!';
  }
}
