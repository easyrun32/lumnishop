import { Component, NgModule, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarComponent implements OnInit {
  public checked: boolean = false;
  constructor() {}

  ngOnInit(): void {}
  onClickUnChecked() {
    this.checked = false;
  }
}
