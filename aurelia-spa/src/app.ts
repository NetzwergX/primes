import { PLATFORM } from 'aurelia-pal';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
  public router: Router;

  // eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
  public configureRouter(config: RouterConfiguration, router: Router) {

    config.title = 'Prime.UI';
    router.title = 'prime-ui';
    config.map([
      {
        route: ['', 'Overview'],
        name: 'overview',
        moduleId: PLATFORM.moduleName('./app/overview'),
        nav: true,
        title: 'Übersicht'
      }
    ]);

    this.router = router;

  }
}
