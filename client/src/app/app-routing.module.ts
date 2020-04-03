import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { ProfileComponent } from './pages/profile/profile.component';
import { SellComponent } from './pages/sell/sell.component';
import { BuyComponent } from './pages/buy/buy.component';
import { AboutComponent } from './pages/about/about.component';
import { CreateProfileComponent } from './pages/create-profile/create-profile.component';
import { EditProfileComponent } from './pages/create-profile/edit-profile.component';

const routes: Routes = [
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'sell',
    component: SellComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'buy',
    component: BuyComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'about',
    component: AboutComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'create',
    component: CreateProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'edit',
    component: EditProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
