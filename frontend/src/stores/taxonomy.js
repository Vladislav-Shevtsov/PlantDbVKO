import { defineStore } from 'pinia'
import axios from 'axios'

const API_BASE = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5058/api'

export const useTaxonomyStore = defineStore('taxonomy', {
  state: () => ({
    hierarchy: [],
    loading: false,
    error: null
  }),

  actions: {
    async fetchHierarchy() {
      this.loading = true
      this.error = null
      try {
        const response = await axios.get(`${API_BASE}/taxonomy/hierarchy`)
        this.hierarchy = response.data
      } catch (error) {
        this.error = error.message
      } finally {
        this.loading = false
      }
    }
  }
})