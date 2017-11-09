import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { WriteDataComponent } from './components/writedata/writedata.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    WriteDataComponent,
    FetchDataComponent
  ],
  imports: [
    CommonModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'fetch-data', pathMatch: 'full' },
      { path: 'write-data', component: WriteDataComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: '**', redirectTo: 'fetch-data' }
    ])
  ]
})
export class AppModuleShared {
}
