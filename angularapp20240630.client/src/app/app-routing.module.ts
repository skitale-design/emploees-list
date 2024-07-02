import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmploeesComponent } from './emploees/emploees.component';

const routes: Routes = [
  {path: "emploees", component: EmploeesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
