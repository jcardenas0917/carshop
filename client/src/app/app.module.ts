import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { HighlightModule } from 'ngx-highlightjs';
import json from 'highlight.js/lib/languages/json';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeroComponent } from './components/hero/hero.component';
import { HomeContentComponent } from './components/home-content/home-content.component';
import { LoadingComponent } from './components/loading/loading.component';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faCartArrowDown, faUserTag, faCar } from '@fortawesome/free-solid-svg-icons';
import { SellComponent } from './pages/sell/sell.component';
import { BuyComponent } from './pages/buy/buy.component';
import { AboutComponent } from './pages/about/about.component';
import { HttpClientModule } from '@angular/common/http';
import { CreateProfileComponent } from './pages/create-profile/create-profile.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { EditProfileComponent } from './pages/create-profile/edit-profile.component';
export function hljsLanguages() {
  return [{ name: 'json', func: json }];
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProfileComponent,
    NavBarComponent,
    FooterComponent,
    HeroComponent,
    HomeContentComponent,
    LoadingComponent,
    SellComponent,
    BuyComponent,
    AboutComponent,
    CreateProfileComponent,
    EditProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HighlightModule.forRoot({
      languages: hljsLanguages
    }),
    FontAwesomeModule,
    NgbPaginationModule,
    NgbAlertModule,
    HttpClientModule,
    ReactiveFormsModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {
    library.add(
      faCartArrowDown, faUserTag, faCar
    );
  }
}
