import { TestBed } from '@angular/core/testing';

import { MiroWebPluginService } from './miro-web-plugin.service';

describe('MiroWebPluginService', () => {
  let service: MiroWebPluginService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MiroWebPluginService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
