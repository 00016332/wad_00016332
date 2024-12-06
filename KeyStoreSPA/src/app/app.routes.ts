import { Routes } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { UserFormComponent } from './users/user-form/user-form.component';
import { KeystoresComponent } from './keystores/keystores.component';
import { KeystoreFormComponent } from './keystores/keystore-form/keystore-form.component';

export const routes: Routes = [
    {
        path: "",
        redirectTo: "keys",
        pathMatch: "full" 
    },
    {
        path: "users",
        component: UsersComponent
    },
    {
        path: "users/create",
        component: UserFormComponent
    },
    {
        path: "users/:id",
        component: UserFormComponent
    },

    {
        path: "keys",
        component: KeystoresComponent
    },
    {
        path: "keys/create",
        component: KeystoreFormComponent
    },
    {
        path: "keys/:id",
        component: KeystoreFormComponent
    },
];
