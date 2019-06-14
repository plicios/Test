import Vue from 'vue'
import App from './App.vue'
import VueSidebarMenu from 'vue-sidebar-menu'
import 'vue-sidebar-menu/dist/vue-sidebar-menu.css'
import VueRouter from 'vue-router'
import Home from './components/home.vue'
import AddQuestion from './components/addquestion.vue'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(VueSidebarMenu)
Vue.use(VueRouter)

const router = new VueRouter({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/addquestion',
      name: 'AddQuestion',
      component: AddQuestion
    },
    // {
    //   path: '/questions',
    //   name: 'Questions',
    //   component: Questions
    // },
    // {
    //   path: '/createquiz',
    //   name: 'CreateQuiz',
    //   component: CreateQuiz
    // },
  ]
})


new Vue({ // eslint-disable-line no-new
  el: '#app',
  router,
  render: h => h(App)
})