import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import SingleItemWindow from './components/Items/SingleItemWindow.vue';

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/About.vue')
    },
    {
      path: '/itemDetails',
      name: 'itemDetails',
      component: SingleItemWindow
    },
    {
      path: '/allItems',
      name: 'allItems',
      component: () => import('./components/Items/ItemsWindow.vue')
    },
    {
      path: '/cart',
      name: 'cart',
      component: () => import('./components/Cart/Cart.vue')
    },
  ]
})
