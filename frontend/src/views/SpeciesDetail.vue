<template>
  <div class="species-detail" v-if="species">
    <h2>{{ species.scientificName }}</h2>
    <p><strong>Author:</strong> {{ species.author }}</p>
    <p><strong>Description:</strong> {{ species.description }}</p>
    <p><strong>Taxonomy ID:</strong> {{ species.taxonomyId }}</p>

    <h3>Translations</h3>
    <ul v-if="species.translations.length">
      <li v-for="t in species.translations" :key="t.id">
        {{ t.languageCode }}: {{ t.name }}
      </li>
    </ul>
    <p v-else>No translations.</p>

    <h3>Media</h3>
    <ul v-if="species.media.length">
      <li v-for="m in species.media" :key="m.id">
        <img :src="m.url" :alt="m.altText" style="max-width: 200px;" />
      </li>
    </ul>
    <p v-else>No media.</p>

    <h3>Distributions</h3>
    <ul v-if="species.distributions.length">
      <li v-for="d in species.distributions" :key="d.id">
        Lat: {{ d.latitude }}, Lon: {{ d.longitude }}, Region: {{ d.regionCode }}
      </li>
    </ul>
    <p v-else>No distributions.</p>

    <div class="actions">
      <router-link :to="`/species/${species.id}/edit`" class="btn">Edit</router-link>
      <button @click="deleteSpecies" class="btn delete">Delete</button>
      <router-link to="/species" class="btn">Back to List</router-link>
    </div>
  </div>
  <div v-else-if="loading">Loading...</div>
  <div v-else-if="error" class="error">{{ error }}</div>
</template>

<script>
import { useSpeciesStore } from '../stores/species'

export default {
  name: 'SpeciesDetail',
  computed: {
    species() {
      return useSpeciesStore().currentSpecies
    },
    loading() {
      return useSpeciesStore().loading
    },
    error() {
      return useSpeciesStore().error
    }
  },
  async mounted() {
    await useSpeciesStore().fetchSpeciesById(this.$route.params.id)
  },
  methods: {
    async deleteSpecies() {
      if (confirm('Are you sure you want to delete this species?')) {
        try {
          await useSpeciesStore().deleteSpecies(this.$route.params.id)
          this.$router.push('/species')
        } catch (e) {
          // error handled in store
        }
      }
    }
  }
}
</script>

<style scoped>
.actions {
  margin-top: 2rem;
}
.btn {
  padding: 0.5rem 1rem;
  background: #42b883;
  color: white;
  text-decoration: none;
  border-radius: 4px;
  margin-right: 1rem;
  display: inline-block;
}
.btn.delete {
  background: #f44336;
}
.error {
  color: red;
}
</style>