import { AsyncPipe, JsonPipe } from '@angular/common';
import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

import { ToastrService } from 'ngx-toastr';
import { Observable, Subscription } from 'rxjs';
import { KeystoreService } from '../../services/keystore.service';
import { User } from '../../types/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-keystore-form',
  imports: [ReactiveFormsModule, AsyncPipe, JsonPipe, RouterLink],
  templateUrl: './keystore-form.component.html',
  styleUrl: './keystore-form.component.css'
})
export class KeystoreFormComponent implements OnInit, OnDestroy{
  form!: FormGroup;
  users$!: Observable<User[]>
  keyformSubscription!: Subscription;
  paramsSubscription!: Subscription;
  keyStoreService= inject(KeystoreService);
  userService= inject(UserService);
  isEdit=false;
  id=0;

  constructor(private fb: FormBuilder, private activatedRouter: ActivatedRoute, private router: Router, private toasterService: ToastrService) {}
  onSubmit() {
    if (!this.isEdit) {
      this.keyformSubscription = this.keyStoreService.addKey(this.form.value).subscribe(
        {
          next:(response)=> {
            this.toasterService.success("Key successfully added");
            this.router.navigateByUrl("/keys");
          },
          error: err => {
            console.log(err)
          }
        }
      )
    }
    else {
      let data = this.form.value;
      data.id = this.id;
      console.log(data);
      this.keyStoreService.editKey(this.id, data).subscribe(
        {
          next: (res) => {
            this.toasterService.success("Key successfully edited");
            this.router.navigateByUrl("/keys");
          },
          error: err => {
            console.log(err)
          }
        }
      )
      
    }
  }
  ngOnInit(): void {
    this.users$ = this.userService.getUsers();
    this.paramsSubscription = this.activatedRouter.params.subscribe(
      {
        next: (response) => {
          console.log(response['id'])
          let id = response['id'];
          this.id = id;
          if (!id) return;
          
          this.keyStoreService.getKey(id).subscribe({
            next:(response) => {
              this.form.patchValue(response)
              this.isEdit = true;
            },
            error: err=> {
              console.log(err)
            }
          })
        },
        error: err=> {
          console.log(err)
        }
      }
    )
    this.form = this.fb.group(
      {
        keyName: [],
        keyValue: [],
        userId: []
      }
    )
      
  }

  ngOnDestroy(): void {
    if(this.keyformSubscription) {

      this.keyformSubscription.unsubscribe();
    }

    if (this.paramsSubscription) {
      this.paramsSubscription.unsubscribe();
    }
  }
}
