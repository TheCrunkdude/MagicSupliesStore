
import { NgModule } from '@angular/core';
import { AvatarModule } from 'primeng/avatar';
import { MegaMenuModule } from 'primeng/megamenu';
import { ButtonModule } from 'primeng/button';

@NgModule({
    exports: [
MegaMenuModule,
AvatarModule,
ButtonModule
    ]
})
export class PrimeNgModule{}
