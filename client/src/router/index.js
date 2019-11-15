import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import ExampleIndex from '@/components/example/Index'
import ExampleView from '@/components/example/View'
import ClientIndex from '@/components/clients/Index'
import ClientCreateOrUpdate from '@/components/clients/CreateOrUpdate'
import SellerIndex from '@/components/sellers/Index'
import SellerCreateOrUpdate from '@/components/sellers/CreateOrUpdate'
import ProductIndex from '@/components/products/Index'
import ProductCreateOrUpdate from '@/components/products/CreateOrUpdate'
import SoldIndex from '@/components/solds/Index'
import SoldCreateOrUpdate from '@/components/solds/CreateOrUpdate'

Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/example', name: 'ExampleIndex', component: ExampleIndex },
  { path: '/example/:id', name: 'ExampleView', component: ExampleView },
  { path: '/clients/', name: 'ClientIndex', component: ClientIndex},
  { path: '/clients/add', name: 'ClientCreate', component: ClientCreateOrUpdate},
  { path: '/clients/:id/edit', name: 'ClientEdit', component: ClientCreateOrUpdate},
  { path: '/sellers/', name: 'SellerIndex', component: SellerIndex},
  { path: '/sellers/add', name: 'SellerCreate', component: SellerCreateOrUpdate},
  { path: '/sellers/:id/edit', name: 'SellerEdit', component: SellerCreateOrUpdate},
  { path: '/products/', name: 'ProductIndex', component: ProductIndex},
  { path: '/products/add', name: 'ProductCreate', component: ProductCreateOrUpdate},
  { path: '/products/:id/edit', name: 'ProductEdit', component: ProductCreateOrUpdate},
  { path: '/solds/', name: 'SoldIndex', component:SoldIndex},
  { path: '/solds/add', name: 'SoldCreate', component: SoldCreateOrUpdate},
  { path: '/solds/:id/edit', name: 'SoldEdit', component: SoldCreateOrUpdate},
]


export default new Router({
  routes
})
