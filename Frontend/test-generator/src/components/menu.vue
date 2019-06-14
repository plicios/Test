<template>
  <sidebar-menu :menu="menu" />
</template>

<script>
import { SidebarMenu } from 'vue-sidebar-menu'
import '@fortawesome/fontawesome-free/css/all.css'
    export default {
        name: 'Menu',
        components: {
            SidebarMenu
        },
        data() {
            return {
                menu: [
                    {
                        header: true,
                        title: 'Menu',
                        // component: componentName
                        // visibleOnCollapse: true
                        // class: ''
                        // attributes: {}
                    },
                    {
                        href: '/',
                        title: 'Home',
                        icon: 'fa fa-home',
                    },
                    {
                        href: '/addquestion',
                        title: 'Add Question',
                        icon: 'fa fa-plus',
                        /* 
                        // custom icon
                        icon: {
                            element: 'span',
                            class: 'fa fa-user',
                            attributes: {}
                        }
                        */
                        // disabled: true
                        // class: ''
                        // attributes: {}
                        // alias: '/path'
                        /*
                        badge: {
                            text: 'new',
                            class: 'default-badge'
                            // attributes: {}
                            // element: 'span'
                        }
                        */
                    },
                    {
                        href: '/listofquestions',
                        title: 'List of Questions',
                        icon: 'fa fa-list',
                        // icon: 'fa fa-chart-area',
                        // child: [
                        //     {
                        //         href: '/charts/sublink',
                        //         title: 'Sub Link',
                        //     }
                        // ]
                    },
                    {
                        href: '/createquiz',
                        title: 'Create Quiz',
                        icon: 'fa fa-scroll',
                    }

                ]
            }
        }
    }
</script>