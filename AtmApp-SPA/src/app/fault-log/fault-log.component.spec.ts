/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FaultLogComponent } from './fault-log.component';

describe('FaultLogComponent', () => {
  let component: FaultLogComponent;
  let fixture: ComponentFixture<FaultLogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FaultLogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FaultLogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
