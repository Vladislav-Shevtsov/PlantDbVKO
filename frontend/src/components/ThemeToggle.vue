<template>
  <div class="flex items-center space-x-2">
    <button @click="toggleTheme" class="btn btn-ghost btn-sm">
      <svg v-if="isDark" xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
        <path d="M17.293 13.293A8 8 0 116.707 2.707a8 8 0 0010.586 10.586z" />
      </svg>
      <svg v-else xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
        <path d="M10 2a1 1 0 011 1v1a1 1 0 11-2 0V3a1 1 0 011-1zm4.22 2.03a1 1 0 011.415 0l.707.708a1 1 0 11-1.414 1.414l-.708-.707a1 1 0 010-1.415zM17 9a1 1 0 110 2h-1a1 1 0 110-2h1zM6.343 4.343a1 1 0 010 1.414L5.636 6.464A1 1 0 114.222 5.05l.707-.707a1 1 0 011.414 0zM10 16a1 1 0 011 1v1a1 1 0 11-2 0v-1a1 1 0 011-1z" />
      </svg>
    </button>
  </div>
</template>

<script>
export default {
  name: 'ThemeToggle',
  data() {
    return {
      isDark: false
    }
  },
  mounted() {
    const stored = localStorage.getItem('daisy-theme')
    if (stored) {
      this.isDark = stored === 'dark'
      document.documentElement.setAttribute('data-theme', this.isDark ? 'dark' : 'floraLight')
    } else {
      // default to floraLight
      document.documentElement.setAttribute('data-theme', 'floraLight')
    }
  },
  methods: {
    toggleTheme() {
      this.isDark = !this.isDark
      const theme = this.isDark ? 'dark' : 'floraLight'
      // apply theme and persist
      document.documentElement.setAttribute('data-theme', theme)
      localStorage.setItem('daisy-theme', theme)
      // emit a global event so other parts can react if needed
      window.dispatchEvent(new CustomEvent('daisy-theme-changed', { detail: { theme } }))
    }
  }
}
</script>
