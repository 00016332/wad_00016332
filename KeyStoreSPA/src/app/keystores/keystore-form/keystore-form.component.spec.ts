import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KeystoreFormComponent } from './keystore-form.component';

describe('KeystoreFormComponent', () => {
  let component: KeystoreFormComponent;
  let fixture: ComponentFixture<KeystoreFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KeystoreFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KeystoreFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
