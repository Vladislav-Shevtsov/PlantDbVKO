import { createApp } from 'vue'
import { createPinia } from 'pinia'
import router from './router'
import './style.css'
import App from './App.vue'

// initialize daisyUI theme from localStorage before app mounts
const storedTheme = typeof window !== 'undefined' ? localStorage.getItem('daisy-theme') : null
if (storedTheme) {
	document.documentElement.setAttribute('data-theme', storedTheme)
} else {
	document.documentElement.setAttribute('data-theme', 'floraLight')
}

const app = createApp(App)
app.use(createPinia())
app.use(router)
app.mount('#app')
