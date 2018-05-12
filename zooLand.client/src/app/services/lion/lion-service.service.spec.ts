import { TestBed, inject } from '@angular/core/testing';

import { LionServiceService } from './lion-service.service';

describe('LionServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LionServiceService]
    });
  });

  it('should be created', inject([LionServiceService], (service: LionServiceService) => {
    expect(service).toBeTruthy();
  }));
});
