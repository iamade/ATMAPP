/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AtmfleetService } from './atmfleet.service';

describe('Service: Atmfleet', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AtmfleetService]
    });
  });

  it('should ...', inject([AtmfleetService], (service: AtmfleetService) => {
    expect(service).toBeTruthy();
  }));
});
