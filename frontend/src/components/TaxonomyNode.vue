<template>
  <li>
    <button
      @click="selectNode"
      :class="[
        'w-full text-left px-3 py-2 rounded-md transition duration-200 hover:bg-green-100 focus:outline-none focus:ring-2 focus:ring-green-500',
        isSelected ? 'bg-green-200 text-green-800 font-semibold' : 'text-gray-700 hover:text-green-800'
      ]"
    >
      <span class="flex items-center">
        <svg v-if="node.children && node.children.length" class="w-4 h-4 mr-2 text-gray-500" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7"></path>
        </svg>
        <span v-else class="w-4 h-4 mr-2"></span>
        {{ node.name }} <span class="text-sm text-gray-500">({{ node.rank }})</span>
        <span v-if="node.speciesCount !== undefined" class="ml-auto text-xs bg-gray-200 px-2 py-1 rounded-full">
          {{ node.speciesCount }} species
        </span>
      </span>
    </button>
    <ul v-if="node.children && node.children.length" class="ml-6 mt-1 space-y-1">
      <TaxonomyNode
        v-for="child in node.children"
        :key="child.id"
        :node="child"
        @select="$emit('select', $event)"
        :selectedId="selectedId"
      />
    </ul>
  </li>
</template>

<script>
export default {
  name: 'TaxonomyNode',
  props: {
    node: {
      type: Object,
      required: true
    },
    selectedId: {
      type: String,
      default: null
    }
  },
  computed: {
    isSelected() {
      return this.selectedId === this.node.id
    }
  },
  methods: {
    selectNode() {
      this.$emit('select', this.node)
    }
  }
}
</script>

<style scoped>
</style>