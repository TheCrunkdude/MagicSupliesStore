import { Component, OnInit } from '@angular/core';
import { MegaMenuItem } from 'primeng/api';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css',

})
export class MenuComponent implements OnInit {
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
                  label: 'RolePermissions',
                  routerLink: "/RolePermissions"

                }
              ]
            }
          ],
        ]
      }
    ]
  }


}
