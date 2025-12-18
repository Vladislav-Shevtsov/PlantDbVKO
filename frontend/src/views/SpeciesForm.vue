<template>
  <div class="species-form">
    <h2>{{ isEdit ? 'Edit Species' : 'Add New Species' }}</h2>
    <form @submit.prevent="submitForm">
      <div>
        <label>Scientific Name:</label>
        <input v-model="form.scientificName" required />
      </div>
      <div>
        <label>Author:</label>
        <input v-model="form.author" />
      </div>
      <div>
        <label>Description:</label>
        <textarea v-model="form.description"></textarea>
      </div>
      <div>
        <label>Taxonomy ID:</label>
        <input v-model="form.taxonomyId" type="text" required />
      </div>
      <button type="submit" :disabled="loading">{{ isEdit ? 'Update' : 'Create' }}</button>
      <router-link to="/species" class="btn cancel">Cancel</router-link>
    </form>
    <div v-if="error" class="error">{{ error }}</div>
  </div>
</template>

<script>
import { useSpeciesStore } from '../stores/species'

export default {
  name: 'SpeciesForm',
  data() {
    return {
      form: {
        scientificName: '',
        author: '',
        description: '',
        taxonomyId: ''
      }
    }
  },
  computed: {
    isEdit() {
      return !!this.$route.params.id
    },
    loading() {
      return useSpeciesStore().loading
    },
    error() {
      return useSpeciesStore().error
    }
  },
  async mounted() {
    if (this.isEdit) {
      await useSpeciesStore().fetchSpeciesById(this.$route.params.id)
      const species = useSpeciesStore().currentSpecies
      if (species) {
        this.form = { ...species }
      }
    }
  },
  methods: {
    async submitForm() {
      try {
        const formData = { ...this.form }
        if (formData.taxonomyId === '') {
          formData.taxonomyId = '11111111-1111-1111-1111-111111111111'
        }
        if (this.isEdit) {
          await useSpeciesStore().updateSpecies(this.$route.params.id, formData)
        } else {
          await useSpeciesStore().createSpecies(formData)
        }
        this.$router.push('/species')
      } catch (e) {
        // error handled in store
      }
    }
  }
}
</script>

<style scoped>
form div {
  margin-bottom: 1rem;
}
label {
  display: block;
  margin-bottom: 0.5rem;
}
input, textarea {
  width: 100%;
  padding: 0.5rem;
  border: 1px solid #ddd;
  border-radius: 4px;
}
button {
  padding: 0.5rem 1rem;
  background: #42b883;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
button:disabled {
  background: #ccc;
}
.btn.cancel {
  margin-left: 1rem;
  background: #f44336;
  text-decoration: none;
  display: inline-block;
}
.error {
  color: red;
  margin-top: 1rem;
}
</style>