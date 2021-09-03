import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { MenuService } from 'src/app/_shared/services/menu.service';
import { NavService } from 'src/app/_shared/services/nav.service';
import { NavItem } from 'src/app/_shared/components/menu-list-item/menu-list-item.component'
import { VERSION } from '@angular/material/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements AfterViewInit,OnInit {

  @ViewChild('appDrawer') appDrawer: ElementRef;
  version = VERSION;
  constructor(    private menuService: MenuService,
    private navService: NavService,) { }

  ngOnInit(): void {

  }

  navItems: NavItem[] = [
    {
      displayName: 'DevFestFL TwoTwoTwo',
      iconName: 'recent_actors',
      route:'/login',
      children: [
        {
          displayName: 'Speakers',
          iconName: 'group',
          route:'/login',
          children: [
            {
              displayName: 'campany',
              iconName: 'person',
              route:'/campany',
              children: [
                {
                  displayName: 'campany',
                  iconName: 'star_rate',
                  route:'/campany',
                }
              ]
            },
            {
              displayName: 'Stephen Fluin',
              iconName: 'person',
              route:'/signup',
              children: [
                {
                  displayName: 'What\'s up with the Web?',
                  iconName: 'star_rate',
                  route:'/signup',
                }
              ]
            },
            {
              displayName: 'Mike Brocchi',
              iconName: 'person',
              route:'/login',
              children: [
                {
                  displayName: 'My ally, the CLI',
                  iconName: 'star_rate',
                  route:'/login',
                },
                {
                  displayName: 'Become an Angular Tailor',
                  iconName: 'star_rate',
                  route:'/signup',
                }
              ]
            }
          ]
        },
        {
          displayName: 'Sessions',
          iconName: 'speaker_notes',
          route:'/login',
          children: [
            {
              displayName: 'Create Enterprise UIs',
              iconName: 'star_rate',
              route:'/signup',
            },
            {
              displayName: 'What\'s up with the Web?',
              iconName: 'star_rate',
              route:'/signup',
            },
            {
              displayName: 'My ally, the CLI',
              iconName: 'star_rate',
              route:'/signup',
            },
            {
              displayName: 'Become an Angular Tailor',
              iconName: 'star_rate',
              route:'/signup',
            }
          ]
        },
        {
          displayName: 'Feedback',
          iconName: 'feedback',
          route:'/signup',
        }
      ]
    },
    {
      displayName: 'Disney',
      iconName: 'videocam',
      children: [
        {
          displayName: 'Speakers',
          iconName: 'group',
          children: [
            {
              displayName: 'Michael Prentice',
              iconName: 'person',
              route:'/signup',
              children: [
                {
                  displayName: 'Create Enterprise UIs',
                  iconName: 'star_rate',
                  route:'/signup',
                }
              ]
            },
            {
              displayName: 'Stephen Fluin',
              iconName: 'person',
              route:'/signup',
              children: [
                {
                  displayName: 'What\'s up with the Web?',
                  iconName: 'star_rate',
                  route:'/signup',
                }
              ]
            },
            {
              displayName: 'Mike Brocchi',
              iconName: 'person',
              route:'/signup',
              children: [
                {
                  displayName: 'My ally, the CLI',
                  iconName: 'star_rate',
                  route: 'my-ally-cli'
                },
                {
                  displayName: 'Become an Angular Tailor',
                  iconName: 'star_rate',
                  route:'/signup',
                }
              ]
            }
          ]
        },
        {
          displayName: 'Feedback',
          iconName: 'feedback',
          route: 'feedback'
        }
      ]
    }
    ,
    {
      displayName: 'Disney',
      iconName: 'videocam',
      children: [
        {
          displayName: 'Speakers',
          iconName: 'group',
          children: [
            {
              displayName: 'Michael Prentice',
              iconName: 'person',
              route:'/signup',
              children: [
                {
                  displayName: 'Create Enterprise UIs',
                  iconName: 'star_rate',
                  route:'/signup',
                }
              ]
            },
            {
              displayName: 'Stephen Fluin',
              iconName: 'person',
              route:'/signup',
              children: [
                {
                  displayName: 'What\'s up with the Web?',
                  iconName: 'star_rate',
                  route:'/signup',
                }
              ]
            }
          ]
        },
        {
          displayName: 'Feedback',
          iconName: 'feedback',
          route: 'feedback'
        }
      ]
    }
  ];

  ngAfterViewInit() {

    this.navService.appDrawer = this.appDrawer;
  }


}
