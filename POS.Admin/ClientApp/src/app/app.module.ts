import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ngxLoadingAnimationTypes, NgxLoadingModule } from 'ngx-loading';
import {TranslateModule, TranslateLoader} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import { SharedModule } from './_shared/_shared.module';
import { ToastrModule } from 'ngx-toastr';
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserModule,  TooltipModule.forRoot(),
    BrowserAnimationsModule,
    NgxLoadingModule.forRoot({
      animationType: ngxLoadingAnimationTypes.threeBounce,
      backdropBackgroundColour: '#fff',
      backdropBorderRadius: '4px',
      primaryColour: 'rgba(68, 115, 30, 1)',
      secondaryColour: 'rgba(68, 115, 30, 1)',
      tertiaryColour: 'rgba(68, 115, 30, 1)'
    }),
    TranslateModule.forRoot({
        loader: {
            provide: TranslateLoader,
            useFactory: HttpLoaderFactory,
            deps: [HttpClient]
        }
    }),
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      tapToDismiss: true,
      maxOpened: 1,
      autoDismiss: true
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
