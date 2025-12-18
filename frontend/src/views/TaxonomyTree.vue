<template>
  <div class="min-h-screen bg-gray-50 py-8 px-4 sm:px-6 lg:px-8">
    <div class="max-w-7xl mx-auto">
      <div class="bg-white shadow-lg rounded-lg overflow-hidden">
        <div class="px-6 py-4 bg-green-600 text-white">
          <h1 class="text-2xl font-bold">Taxonomy Explorer</h1>
          <p class="text-green-100">Explore the hierarchical classification of Kazakhstan's plant species</p>
        </div>

        <div class="flex">
          <!-- Left Sidebar - Taxonomy Tree -->
          <div class="w-1/3 bg-gray-50 p-6 border-r border-gray-200">
            <h2 class="text-lg font-semibold mb-4 text-gray-800">Taxonomy Hierarchy</h2>
            <div v-if="loading" class="text-center py-4">
              <div class="animate-spin rounded-full h-8 w-8 border-b-2 border-green-600 mx-auto"></div>
            </div>
            <div v-if="error" class="bg-red-50 border border-red-200 text-red-700 px-3 py-2 rounded mb-4 text-sm">
              {{ error }}
            </div>
            <div v-if="hierarchy.length" class="space-y-2">
              <TaxonomyNode
                v-for="node in hierarchy"
                :key="node.id"
                :node="node"
                @select="selectTaxonomy"
                :selectedId="selectedTaxonomyId"
              />
            </div>
            <p v-else class="text-gray-500 text-sm">No taxonomy data available.</p>
          </div>

          <!-- Right Panel - Species List -->
          <div class="w-2/3 p-6">
            <div v-if="selectedTaxonomy">
              <h2 class="text-xl font-semibold mb-4 text-gray-800">
                Species in {{ selectedTaxonomy.name }}
              </h2>
              <div v-if="speciesLoading" class="text-center py-4">
                <div class="animate-spin rounded-full h-8 w-8 border-b-2 border-green-600 mx-auto"></div>
              </div>
              <div v-if="speciesError" class="bg-red-50 border border-red-200 text-red-700 px-3 py-2 rounded mb-4 text-sm">
                {{ speciesError }}
              </div>
              <div v-if="taxonomySpecies.length === 0 && !speciesLoading" class="text-center py-8">
                <svg class="mx-auto h-12 w-12 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9.663 17h4.673M12 3v1m6.364 1.636l-.707.707M21 12h-1M4 12H3m3.343-5.657l-.707-.707m2.828 9.9a5 5 0 117.072 0l-.548.547A3.374 3.374 0 0014 18.469V19a2 2 0 11-4 0v-.531c0-.895-.356-1.754-.988-2.386l-.548-.547z" />
                </svg>
                <h3 class="mt-2 text-sm font-medium text-gray-900">No species found</h3>
                <p class="mt-1 text-sm text-gray-500">This taxonomy category has no associated species yet.</p>
              </div>
              <div v-else class="grid gap-4 md:grid-cols-2 lg:grid-cols-3">
                <div
                  v-for="species in taxonomySpecies"
                  :key="species.id"
                  class="bg-white border border-gray-200 rounded-lg p-4 hover:shadow-md transition duration-300"
                >
                  <h3 class="text-lg font-semibold text-gray-900 mb-2">{{ species.scientificName }}</h3>
                  <p class="text-sm text-gray-600 mb-2">{{ species.author || 'Unknown author' }}</p>
                  <p class="text-sm text-gray-500 mb-3 line-clamp-2">{{ species.description || 'No description available.' }}</p>
                  <router-link
                    :to="`/species/${species.id}`"
                    class="text-green-600 hover:text-green-800 text-sm font-medium"
                  >
                    View Details →
                  </router-link>
                </div>
              </div>
            </div>
            <div v-else class="text-center py-12">
              <svg class="mx-auto h-16 w-16 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 5a1 1 0 011-1h14a1 1 0 011 1v2a1 1 0 01-1 1H5a1 1 0 01-1-1V5zM4 13a1 1 0 011-1h6a1 1 0 011 1v6a1 1 0 01-1 1H5a1 1 0 01-1-1v-6zM16 13a1 1 0 011-1h2a1 1 0 011 1v6a1 1 0 01-1 1h-2a1 1 0 01-1-1v-6z" />
              </svg>
              <h3 class="mt-4 text-lg font-medium text-gray-900">Select a Taxonomy</h3>
              <p class="mt-1 text-gray-500">Choose a category from the tree on the left to view associated species.</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useTaxonomyStore } from '../stores/taxonomy'
import { useSpeciesStore } from '../stores/species'
import TaxonomyNode from '../components/TaxonomyNode.vue'

export default {
  name: 'TaxonomyTree',
  components: { TaxonomyNode },
  data() {
    return {
      selectedTaxonomyId: null,
      selectedTaxonomy: null,
      taxonomySpecies: [],
      speciesLoading: false,
      speciesError: null
    }
  },
  computed: {
    hierarchy() {
      return useTaxonomyStore().hierarchy
    },
    loading() {
      return useTaxonomyStore().loading
    },
    error() {
      return useTaxonomyStore().error
    }
  },
  mounted() {
    useTaxonomyStore().fetchHierarchy()
  },
  methods: {
    async selectTaxonomy(node) {
      this.selectedTaxonomyId = node.id
      this.selectedTaxonomy = node
      this.speciesLoading = true
      this.speciesError = null
      try {
        await useSpeciesStore().fetchSpecies({ taxonomyId: node.id, pageSize: 100 })
        this.taxonomySpecies = useSpeciesStore().species
      } catch (error) {
        this.speciesError = error.message
      } finally {
        this.speciesLoading = false
      }
    }
  }
}
</script>