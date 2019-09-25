/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AtmFleetComponent } from './atm-fleet.component';

describe('AtmFleetComponent', () => {
  let component: AtmFleetComponent;
  let fixture: ComponentFixture<AtmFleetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AtmFleetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AtmFleetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
