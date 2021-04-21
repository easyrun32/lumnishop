import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SvgComponent } from './svg.component';
import { NgxUsefulSwiperModule } from 'ngx-useful-swiper';
import { NgbdCarouselNavigationComponent } from './ngbd-carousel-navigation/ngbd-carousel-navigation.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    SvgComponent,
    NgbdCarouselNavigationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    NgbModule,
    NgxUsefulSwiperModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
