import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import About from '../views/About.vue'
import SpeciesList from '../views/SpeciesList.vue'
import SpeciesForm from '../views/SpeciesForm.vue'
import SpeciesDetail from '../views/SpeciesDetail.vue'
import TaxonomyTree from '../views/TaxonomyTree.vue'

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/about', name: 'About', component: About },
  { path: '/species', name: 'SpeciesList', component: SpeciesList },
  { path: '/species/new', name: 'SpeciesNew', component: SpeciesForm },
  { path: '/species/:id', name: 'SpeciesDetail', component: SpeciesDetail },
  { path: '/species/:id/edit', name: 'SpeciesEdit', component: SpeciesForm },
  { path: '/taxonomy', name: 'TaxonomyTree', component: TaxonomyTree }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router