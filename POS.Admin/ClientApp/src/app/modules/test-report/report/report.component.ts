import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { TelerikReportViewerComponent } from '@progress/telerik-angular-report-viewer';
import { StringResources } from '../stringResources';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  
  @ViewChild('viewer1', { static: false }) viewer: TelerikReportViewerComponent;
  constructor() { }

  ngOnInit(): void {
  }


//   ngAfterViewInit(): void {
//      // Localization demo.
//       const language = navigator.language;
//       let resources = StringResources.english; // Default.

//       if (language === 'ja-JP') {
//           resources = StringResources.japanese;
//       }
// debugger
//       this.viewer.viewerObject.stringResources = Object.assign(this.viewer.viewerObject.stringResources);
//   }

  title = "Report Viewer";
  viewerContainerStyle = {
      position: 'absolute',
      left: '5px',
      right: '5px',
      top: '40px',
      bottom: '5px',
      overflow: 'hidden',
      clear: 'both',
      ['font-family']: 'ms sans serif'
  };

  ready() { console.log('ready'); }
  viewerToolTipOpening(e: any, args: any) { console.log('viewerToolTipOpening ' + args.toolTip.text); }

}
