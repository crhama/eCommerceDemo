import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ShopModule } from './shop/shop.module';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ContactComponent } from './contact/contact.component';
import { AccountModule } from './account/account.module';
import { SliderComponent } from './slider/slider.component';
import { VideoGalleryComponent } from './video-gallery/video-gallery.component';
import { DataServiceModule } from './data-service/data-service.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ContactComponent,
    SliderComponent,
    VideoGalleryComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'contact', component: ContactComponent }
    ]),
    ShopModule,
    AccountModule,
    DataServiceModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
