/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FaultLogsService } from './fault-logs.service';

describe('Service: FaultLogs', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FaultLogsService]
    });
  });

  it('should ...', inject([FaultLogsService], (service: FaultLogsService) => {
    expect(service).toBeTruthy();
  }));
});
