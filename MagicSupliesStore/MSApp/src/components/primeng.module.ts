
import { NgModule } from '@angular/core';
import { AvatarModule } from 'primeng/avatar';
import { MegaMenuModule } from 'primeng/megamenu';
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { TableModule } from 'primeng/table';

@NgModule({
    exports: [
MegaMenuModule,
AvatarModule,
ButtonModule,
CheckboxModule,
TableModule
    ]
})
export class PrimeNgModule{}
