import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { HttpConfigInterceptor } from './interceptor/httpconfig.interceptor';
import { ErrordialogComponent } from './components/errordialog/errordialog.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { TranslateModule } from "@ngx-translate/core";
import { TruncateWordPipe } from './pipes/truncate.word.pipe';

import { TruncatePipe } from './pipes/truncate.pipe';
import { SafePipe } from './pipes/safe.pipe';
import { SentenceCasePipe } from './pipes/sentence.case.pipe';
import { SharedHeaderComponent } from './components/shared-header/shared-header.component';
import { ControlMessagesComponent } from './components/control-messages/control-messages.component';
import { RouterModule } from '@angular/router';
import { ButtonLoaderComponent } from './components/button-loader/button-loader.component';
import { NotificationComponent } from './components/notification/notification.component';
import { OnlyNumbersDirective } from './directives/only-numbers.directive';
import { FooterComponent } from './components/footer/footer.component';
import { TruncateTextPipe } from './pipes/TruncateTextPipe';
// import { SitePageComponent } from '../home-page-module/components/site-page/site-page.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { ReversePipe, FilterPipe } from './pipes/ReversePipe';
import { ToastrModule } from 'ngx-toastr';
import { A11yModule } from '@angular/cdk/a11y';
import { ClipboardModule } from '@angular/cdk/clipboard';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { PortalModule } from '@angular/cdk/portal';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatBadgeModule } from '@angular/material/badge';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTreeModule } from '@angular/material/tree';
import { MenuListItemComponent } from './components/menu-list-item/menu-list-item.component';
import { LayoutComponent } from './components/layout/layout.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { ModalBasicComponent } from './components/modal-basic/modal-basic.component';
import { NgxPaginationModule, } from 'ngx-pagination';
import { Ng2OrderModule } from 'ng2-order-pipe';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { TwoDigitDecimaNumberDirective } from './directives/two-digit-decima-number.directive';
import { ModalBasicTwoComponent } from './components/modal-basic-two/modal-basic-two.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { AlertComponent } from './components/alert/alert.component';
import { ExcelModule, GridModule, PDFModule } from '@progress/kendo-angular-grid';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { MessageService } from '@progress/kendo-angular-l10n';
import { special3Char } from './directives/Special3CharacterDirective';

@NgModule({
  declarations: [
    ErrordialogComponent,
    TruncateWordPipe,
    TruncatePipe,
    SafePipe,
    SharedHeaderComponent,
    SentenceCasePipe,
    special3Char,
    ControlMessagesComponent,
    NotificationComponent,
    ButtonLoaderComponent,
    OnlyNumbersDirective,
    FooterComponent,
    TruncateTextPipe,
    ModalBasicComponent,
    ModalBasicTwoComponent,
    ReversePipe,
    FilterPipe,
    MenuListItemComponent,
    LayoutComponent,
    TwoDigitDecimaNumberDirective,
    ModalBasicTwoComponent,
    ResetPasswordComponent,
    AlertComponent
   
    
  ],
  imports: [
    MatMenuModule,
    ReactiveFormsModule,
    TranslateModule,
    RouterModule,
    FormsModule,
    CommonModule,
    NgbModule,
    NgxPaginationModule,
    Ng2OrderModule,
    Ng2SearchPipeModule,
    NgSelectModule,
    ToastrModule.forRoot({
      timeOut: 4000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      maxOpened: 1,
      autoDismiss: true
    }),
    A11yModule,
    ClipboardModule,
    CdkStepperModule,
    CdkTableModule,
    CdkTreeModule,
    DragDropModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    PortalModule,
    ScrollingModule,
    GridModule,
    InputsModule,
    PDFModule,
    ExcelModule
    
  ],
  exports: [
    NotificationComponent,
    ButtonLoaderComponent,
    ReactiveFormsModule,
    NgbModule,
    FormsModule,
    TranslateModule,
    special3Char,
    TruncateWordPipe,
    ControlMessagesComponent,
    TruncatePipe,
    SafePipe,
    SentenceCasePipe,
    SharedHeaderComponent,
    ControlMessagesComponent,
    OnlyNumbersDirective,
    FooterComponent,
    TruncateTextPipe,
    ModalBasicComponent,
    ModalBasicTwoComponent,
    ReversePipe,
    FilterPipe,
    MenuListItemComponent,
    LayoutComponent,
    NgSelectModule,
    NgxPaginationModule,
    Ng2OrderModule,
    Ng2SearchPipeModule,
    TwoDigitDecimaNumberDirective,
    //Angular Matrial

    A11yModule,
    ClipboardModule,
    CdkStepperModule,
    CdkTableModule,
    CdkTreeModule,
    DragDropModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    PortalModule,
    ScrollingModule,
    ResetPasswordComponent,
    AlertComponent,
    GridModule,
    InputsModule,
    PDFModule,
    ExcelModule

  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true },MessageService
  ]
})
export class SharedModule { }
