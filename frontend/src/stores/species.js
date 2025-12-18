import { defineStore } from 'pinia'
import axios from 'axios'

const API_BASE = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5058/api'

export const useSpeciesStore = defineStore('species', {
  state: () => ({
    species: [],
    currentSpecies: null,
    loading: false,
    error: null
  }),

  actions: {
    async fetchSpecies({ pageNumber = 1, pageSize = 10, searchTerm = '', taxonomyId = null } = {}) {
      this.loading = true
      this.error = null
      try {
        const params = { pageNumber, pageSize, searchTerm }
        if (taxonomyId) params.taxonomyId = taxonomyId
        const response = await axios.get(`${API_BASE}/species`, { params })
        this.species = response.data
      } catch (error) {
        this.error = error.message
      } finally {
        this.loading = false
      }
    },

    async fetchSpeciesById(id) {
      this.loading = true
      this.error = null
      try {
        const response = await axios.get(`${API_BASE}/species/${id}`)
        this.currentSpecies = response.data
      } catch (error) {
        this.error = error.message
      } finally {
        this.loading = false
      }
    },

    async createSpecies(speciesData) {
      this.loading = true
      this.error = null
      try {
        const response = await axios.post(`${API_BASE}/species`, speciesData)
        this.species.push(response.data)
        return response.data
      } catch (error) {
        this.error = error.message
        throw error
      } finally {
        this.loading = false
      }
    },

    async updateSpecies(id, speciesData) {
      this.loading = true
      this.error = null
      try {
        const response = await axios.put(`${API_BASE}/species/${id}`, speciesData)
        const index = this.species.findIndex(s => s.id === id)
        if (index !== -1) this.species[index] = response.data
        this.currentSpecies = response.data
        return response.data
      } catch (error) {
        this.error = error.message
        throw error
      } finally {
        this.loading = false
      }
    },

    async deleteSpecies(id) {
      this.loading = true
      this.error = null
      try {
        await axios.delete(`${API_BASE}/species/${id}`)
        this.species = this.species.filter(s => s.id !== id)
      } catch (error) {
        this.error = error.message
        throw error
      } finally {
        this.loading = false
      }
    }
  }
})