import { JsonPipe } from '@angular/common';
import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { UserService } from '../../services/user.service';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-form',
  imports: [ReactiveFormsModule, JsonPipe, RouterLink],
  templateUrl: './user-form.component.html',
  styleUrl: './user-form.component.css'
})
export class UserFormComponent implements OnInit, OnDestroy{
  form!: FormGroup;
  userformSubscription!: Subscription;
  paramsSubscription!:  Subscription;
  userService = inject(UserService);
  isEdit = false;
  id=0;
  constructor(private fb: FormBuilder, private activatedRouter: ActivatedRoute, private router: Router, private toasterService: ToastrService) {}

  onSubmit() {
    if (!this.isEdit) {
      this.userformSubscription = this.userService.addUser(this.form.value).subscribe(
        {
          next:(response)=> {
            this.toasterService.success("User successfully added");
            this.router.navigateByUrl("/users");
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
      this.userService.editUser(this.id, data).subscribe(
        {
          next: (res) => {
            this.toasterService.success("User successfully edited");
            this.router.navigateByUrl("/users");
          },
          error: err => {
            console.log(err)
          }
        }
      )
      
    }
    
  }
   ngOnDestroy(): void {
    if(this.userformSubscription) {

      this.userformSubscription.unsubscribe();
    }

    if (this.paramsSubscription) {
      this.paramsSubscription.unsubscribe();
    }
   }
  ngOnInit(): void {
    this.paramsSubscription = this.activatedRouter.params.subscribe(
      {
        next: (response) => {
          console.log(response['id'])
          let id = response['id'];
          this.id = id;
          if (!id) return;
          
          this.userService.getUser(id).subscribe({
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
        username: ['', Validators.required],
        email: ['', Validators.email],
        password: []
      }
    )
  }
}
