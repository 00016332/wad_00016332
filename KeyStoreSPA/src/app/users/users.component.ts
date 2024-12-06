import { Component, inject, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { Observable } from 'rxjs';
import { User } from '../types/user';
import { AsyncPipe, CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-users',
  imports: [AsyncPipe, CommonModule, RouterLink],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent implements OnInit{
    
    users$!: Observable<User[]>
    userService = inject(UserService);
    constructor(private toasterService: ToastrService) {}
    ngOnInit(): void {
      this.users$ = this.userService.getUsers()
    }

    delete(id: number) {
        this.userService.deleteUser(id).subscribe(
          {
            next: (response) => {
              this.toasterService.success("User successfully deleted")
              this.getUsers();
            },
            error: err => {
              console.log(err)
            }
          }
        )
    }
    private getUsers() {
      this.users$ = this.userService.getUsers();
    }
}
