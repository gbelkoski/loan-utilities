import { Component, OnInit } from '@angular/core';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: 'dashboard', title: 'Почетна',  icon: 'dashboard', class: '' },
    { path: 'loans', title: 'Кредити',  icon:'attach_money', class: '' },
    { path: 'banks', title: 'Банки',  icon:'account_balance', class: '' },
    { path: 'typography', title: 'Типови на кредити', icon: 'library_books', class: '' },
    { path: 'notifications', title: 'Типови на трошоци', icon: 'list', class: '' },
    { path: 'icons', title: 'Корисници',  icon:'supervisor_account', class: '' },
    { path: 'maps', title: 'Кон kreditinfo',  icon:'location_on', class: '' },
    { path: 'upgrade', title: 'Web scraping',  icon:'cloud_download', class: 'active-pro' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
