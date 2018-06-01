import { autoinject } from 'aurelia-framework';

import { Navigation } from 'models/navigation';

@autoinject()
export class AppSidebarNavDivider {
  navigation: Navigation;

  constructor() {

  }

  activate(data) {
    this.navigation = data || {};
  }
}