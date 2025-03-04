import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MegaMenuItem } from 'primeng/api';
import * as alertify from 'alertifyjs';
import { ConfirmationDialogModel } from '../../app/models/confirmation-dialog-model';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router'; // Import Router

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css',

})

export class MenuComponent implements OnInit {
  constructor(
    public dialog: MatDialog, 
    private router: Router
  ) {}

logout() {

  
  if  (localStorage.getItem('TokenID') )
  {
    localStorage.removeItem('TokenID')
    alertify.success('You loged out succesfully')

  }
  else 
  {
    alertify.error("There's no active session, please log in")
  }

}


openLogoutDialog(): void {
  const dialogRef = this.dialog.open(ConfirmationDialogModel);

  dialogRef.afterClosed().subscribe(result => {
    if (result) {
      //Result will not be null if the user click on "yes button"
      this.logout();
      this.router.navigate([''])

    } else {
      //when user click no,
      alertify.error('User canceled logout')
    }   

  });
}

  items: MegaMenuItem[] | undefined;

  ngOnInit() {
    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-home',
        routerLink: "/MainPage"
      },
      {
        label: 'Services',
        icon: 'pi pi-microchip-ai',
        items: [
          [
            {
              items: [{ label: 'SaaS' }, { label: 'Development' }, { label: 'Budget' }, { label: 'Hosting' }]
            }
          ],
        ]
      },
      {
        label: 'Products',
        icon: 'pi pi-code',
        
        items: [
          [
            {

              items: [{ label: 'Serverless' }, { label: "API's" }]
            }
          ],
        ]
      },
      {
        label: "FAQ's",
        icon: 'pi pi-question-circle',
        items: [
          [
            {

              items: [{ label: 'Foro',                  
              // routerLink: "/Foro"
              }]
            }
          ],
        ]
      },
      {
        label: "Config",
        icon: 'pi pi-question-circle',
        items: [
          [
            {
              label: "Config",
              items: [
                {
                  label: 'Users',
                  routerLink: "/Users"
                },
                {
                  label: 'Permissions',
                  routerLink: "/Permissions"

                },
                {
                  label: 'Roles',
                  routerLink: "/Roles"

                },
                {
                  label: 'Role Permissions',
                  routerLink: "/RolePermissions"

                },

                {
                  label: 'User Roles',
                  routerLink: "/UserRoles"

                },
                {
                  label: 'beers',
                  routerLink: "/Beers"
                }

              ]
            }
          ],
        ]
      }
    ]
  }


}
