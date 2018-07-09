import { TestBed, inject } from '@angular/core/testing';

import { AmigoService } from './amigo.service';

describe('AmigoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AmigoService]
    });
  });

  it('should be created', inject([AmigoService], (service: AmigoService) => {
    expect(service).toBeTruthy();
  }));
});
