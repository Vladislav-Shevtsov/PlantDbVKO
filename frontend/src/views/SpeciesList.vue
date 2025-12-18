<template>
  <div class="min-h-screen bg-gray-50 py-8 px-4 sm:px-6 lg:px-8">
    <div class="max-w-7xl mx-auto">
      <div class="bg-white shadow-lg rounded-lg overflow-hidden">
        <div class="px-6 py-4 bg-green-600 text-white">
          <h1 class="text-2xl font-bold">Species Directory</h1>
          <p class="text-green-100">Browse Kazakhstan's endemic and endangered plant species</p>
        </div>

        <div class="p-6">
          <div class="flex flex-col sm:flex-row justify-between items-center mb-6">
            <div class="w-full sm:w-1/2 mb-4 sm:mb-0">
              <input
                v-model="searchTerm"
                @input="debouncedSearch"
                type="text"
                placeholder="Search by scientific name..."
                class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-green-500 focus:border-transparent"
              />
            </div>
            <router-link
              to="/species/new"
              class="bg-green-600 hover:bg-green-700 text-white px-6 py-2 rounded-lg font-semibold transition duration-300"
            >
              Add New Species
            </router-link>
          </div>

          <div v-if="loading" class="text-center py-8">
            <div class="animate-spin rounded-full h-12 w-12 border-b-2 border-green-600 mx-auto"></div>
            <p class="mt-4 text-gray-600">Loading species...</p>
          </div>

          <div v-if="error" class="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded mb-4">
            {{ error }}
          </div>

          <div v-if="!loading && species.length === 0" class="text-center py-8">
            <svg class="mx-auto h-12 w-12 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9.663 17h4.673M12 3v1m6.364 1.636l-.707.707M21 12h-1M4 12H3m3.343-5.657l-.707-.707m2.828 9.9a5 5 0 117.072 0l-.548.547A3.374 3.374 0 0014 18.469V19a2 2 0 11-4 0v-.531c0-.895-.356-1.754-.988-2.386l-.548-.547z" />
            </svg>
            <h3 class="mt-2 text-sm font-medium text-gray-900">No species found</h3>
            <p class="mt-1 text-sm text-gray-500">Get started by adding a new species.</p>
          </div>

          <div v-if="species.length > 0" class="overflow-x-auto">
            <table class="min-w-full divide-y divide-gray-200">
              <thead class="bg-gray-50">
                <tr>
                  <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Scientific Name</th>
                  <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Author</th>
                  <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Actions</th>
                </tr>
              </thead>
              <tbody class="bg-white divide-y divide-gray-200">
                <tr v-for="spec in species" :key="spec.id" class="hover:bg-gray-50">
                  <td class="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">{{ spec.scientificName }}</td>
                  <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{{ spec.author || 'Unknown' }}</td>
                  <td class="px-6 py-4 whitespace-nowrap text-sm font-medium">
                    <router-link
                      :to="`/species/${spec.id}`"
                      class="text-green-600 hover:text-green-900 mr-4"
                    >
                      View Details
                    </router-link>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>

          <!-- Pagination -->
          <div v-if="totalPages > 1" class="flex items-center justify-between mt-6">
            <div class="text-sm text-gray-700">
              Showing {{ (currentPage - 1) * pageSize + 1 }} to {{ Math.min(currentPage * pageSize, totalSpecies) }} of {{ totalSpecies }} species
            </div>
            <div class="flex space-x-2">
              <button
                @click="goToPage(currentPage - 1)"
                :disabled="currentPage === 1"
                class="px-3 py-1 border border-gray-300 rounded-md text-sm font-medium text-gray-500 bg-white hover:bg-gray-50 disabled:opacity-50 disabled:cursor-not-allowed"
              >
                Previous
              </button>
              <button
                v-for="page in visiblePages"
                :key="page"
                @click="goToPage(page)"
                :class="[
                  'px-3 py-1 border rounded-md text-sm font-medium',
                  page === currentPage
                    ? 'border-green-500 bg-green-50 text-green-600'
                    : 'border-gray-300 bg-white text-gray-500 hover:bg-gray-50'
                ]"
              >
                {{ page }}
              </button>
              <button
                @click="goToPage(currentPage + 1)"
                :disabled="currentPage === totalPages"
                class="px-3 py-1 border border-gray-300 rounded-md text-sm font-medium text-gray-500 bg-white hover:bg-gray-50 disabled:opacity-50 disabled:cursor-not-allowed"
              >
                Next
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useSpeciesStore } from '../stores/species'

export default {
  name: 'SpeciesList',
  data() {
    return {
      searchTerm: '',
      searchTimeout: null,
      currentPage: 1,
      pageSize: 50,
      totalSpecies: 0,
      totalPages: 0
    }
  },
  computed: {
    species() {
      return useSpeciesStore().species
    },
    loading() {
      return useSpeciesStore().loading
    },
    error() {
      return useSpeciesStore().error
    },
    visiblePages() {
      const pages = []
      const start = Math.max(1, this.currentPage - 2)
      const end = Math.min(this.totalPages, this.currentPage + 2)
      for (let i = start; i <= end; i++) {
        pages.push(i)
      }
      return pages
    }
  },
  mounted() {
    this.fetchSpecies()
  },
  methods: {
    async fetchSpecies() {
      await useSpeciesStore().fetchSpecies({
        pageNumber: this.currentPage,
        pageSize: this.pageSize,
        searchTerm: this.searchTerm
      })
      // Assuming the API returns pagination info, update totalSpecies and totalPages
      // For now, we'll estimate
      this.totalSpecies = this.species.length * this.totalPages || this.species.length
      this.totalPages = Math.ceil(this.totalSpecies / this.pageSize)
    },
    debouncedSearch() {
      clearTimeout(this.searchTimeout)
      this.searchTimeout = setTimeout(() => {
        this.currentPage = 1
        this.fetchSpecies()
      }, 300)
    },
    goToPage(page) {
      if (page >= 1 && page <= this.totalPages) {
        this.currentPage = page
        this.fetchSpecies()
      }
    }
  }
}
</script>