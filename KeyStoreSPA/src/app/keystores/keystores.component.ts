import { Component, inject, OnInit } from '@angular/core';
import { KeystoreService } from '../services/keystore.service';
import { Observable } from 'rxjs';
import { KeyStore } from '../types/keystore';
import { AsyncPipe, CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-keystores',
  imports: [AsyncPipe, RouterLink, CommonModule],
  templateUrl: './keystores.component.html',
  styleUrl: './keystores.component.css'
})
export class KeystoresComponent implements OnInit{
  keys$!: Observable<KeyStore[]>
  keyStoreService = inject(KeystoreService);
  
  constructor (private toasterService: ToastrService) {}

  ngOnInit(): void {
    this.keys$ = this.keyStoreService.getKeys();
  }
  delete(id: number) {
    this.keyStoreService.deleteKey(id).subscribe(
      {
        next: (response) => {
          this.toasterService.success("Key successfully deleted")
          this.getKeys();
        },
        error: err => {
          console.log(err)
        }
      }
    )
  }

  private getKeys() {
    this.keys$ = this.keyStoreService.getKeys();
  }
}
