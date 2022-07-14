import { Component, Inject } from '@angular/core';
import { MiroWebPluginService } from '../services/miro-web-plugin.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public sessionId: number | null = null;
  public baseURL: string = '';

  constructor(private miroWebPluginSvc: MiroWebPluginService, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }
}

