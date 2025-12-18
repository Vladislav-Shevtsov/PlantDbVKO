<template>
  <div id="app" class="min-h-screen bg-base-100 text-base-content">
    <header class="shadow-lg">
      <div class="navbar bg-primary text-primary-content">
      <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div class="flex justify-between items-center py-4">
          <div class="flex items-center">
            <router-link to="/" class="text-2xl font-bold text-white hover:text-green-200 transition duration-300">
              Kazakhstan Flora
            </router-link>
          </div>
          <nav class="hidden md:flex space-x-4 items-center">
            <router-link to="/" class="btn btn-ghost btn-sm">Home</router-link>
            <router-link to="/about" class="btn btn-ghost btn-sm">About</router-link>
            <router-link to="/species" class="btn btn-ghost btn-sm">Species</router-link>
            <router-link to="/taxonomy" class="btn btn-ghost btn-sm">Taxonomy</router-link>
            <theme-toggle />
          </nav>
          <div class="md:hidden">
            <button @click="toggleMenu" class="text-white hover:text-green-200 focus:outline-none">
              <svg class="h-6 w-6 fill-current" viewBox="0 0 24 24">
                <path v-if="!isMenuOpen" fill-rule="evenodd" d="M4 5h16a1 1 0 0 1 0 2H4a1 1 0 1 1 0-2zm0 6h16a1 1 0 0 1 0 2H4a1 1 0 0 1 0-2zm0 6h16a1 1 0 0 1 0 2H4a1 1 0 0 1 0-2z"/>
                <path v-else fill-rule="evenodd" d="M18.278 16.864a1 1 0 0 1-1.414 1.414l-4.829-4.828-4.828 4.828a1 1 0 0 1-1.414-1.414l4.828-4.829-4.828-4.828a1 1 0 0 1 1.414-1.414l4.829 4.828 4.828-4.828a1 1 0 0 1 1.414 1.414l-4.828 4.829 4.828 4.828z"/>
              </svg>
            </button>
          </div>
        </div>
        <div v-if="isMenuOpen" class="md:hidden">
          <div class="px-2 pt-2 pb-3 space-y-1 sm:px-3">
            <router-link to="/" @click="closeMenu" class="block px-3 py-2 rounded-md text-base font-medium">Home</router-link>
            <router-link to="/about" @click="closeMenu" class="block px-3 py-2 rounded-md text-base font-medium">About</router-link>
            <router-link to="/species" @click="closeMenu" class="block px-3 py-2 rounded-md text-base font-medium">Species</router-link>
            <router-link to="/taxonomy" @click="closeMenu" class="block px-3 py-2 rounded-md text-base font-medium">Taxonomy</router-link>
            <div class="mt-2 px-3"><theme-toggle /></div>
          </div>
        </div>
      </div>
      </div>
    </header>
    <main class="flex-1">
      <router-view />
    </main>
    <footer class="bg-primary text-primary-content py-8">
      <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div class="text-center">
          <p>&copy; 2025 Kazakhstan Flora Database. All rights reserved.</p>
          <p class="mt-2">Dedicated to preserving Kazakhstan's endemic and endangered plant species.</p>
        </div>
      </div>
    </footer>
  </div>
</template>

<script>
import ThemeToggle from './components/ThemeToggle.vue'
export default {
  name: 'App',
  components: { ThemeToggle },
  data() {
    return {
      isMenuOpen: false
    }
  },
  methods: {
    toggleMenu() {
      this.isMenuOpen = !this.isMenuOpen
    },
    closeMenu() {
      this.isMenuOpen = false
    }
  }
}
</script>
