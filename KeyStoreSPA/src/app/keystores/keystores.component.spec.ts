import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KeystoresComponent } from './keystores.component';

describe('KeystoresComponent', () => {
  let component: KeystoresComponent;
  let fixture: ComponentFixture<KeystoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KeystoresComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KeystoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
