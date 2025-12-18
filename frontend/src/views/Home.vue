<template>
  <div class="min-h-screen bg-gradient-to-b from-green-50 to-green-100">
    <!-- Hero Section -->
    <section class="hero bg-cover bg-center h-96 flex items-center justify-center" style="background-image: url('https://via.placeholder.com/1920x600/22c55e/ffffff?text=Kazakhstan+Flora')">
      <div class="text-center text-white bg-black bg-opacity-50 p-8 rounded-lg">
        <h1 class="text-5xl font-bold mb-4">Endemic Endangered Plants of Kazakhstan</h1>
        <p class="text-xl mb-6">Discover and protect the unique flora of Kazakhstan</p>
        <div class="space-x-4">
          <router-link to="/species" class="bg-green-600 hover:bg-green-700 text-white px-6 py-3 rounded-lg font-semibold transition duration-300">Browse Species</router-link>
          <router-link to="/taxonomy" class="bg-white text-green-600 hover:bg-gray-100 px-6 py-3 rounded-lg font-semibold transition duration-300">Explore Taxonomy</router-link>
        </div>
      </div>
    </section>

    <!-- About Section -->
    <section class="py-16 px-8 max-w-4xl mx-auto">
      <h2 class="text-3xl font-bold text-center mb-8 text-green-800">About Our Mission</h2>
      <div class="grid md:grid-cols-2 gap-8">
        <div>
          <h3 class="text-xl font-semibold mb-4 text-green-700">Preserving Biodiversity</h3>
          <p class="text-gray-700">Kazakhstan is home to a rich variety of endemic and endangered plant species. Our database helps researchers, conservationists, and enthusiasts track and protect these vital components of our ecosystem.</p>
        </div>
        <div>
          <h3 class="text-xl font-semibold mb-4 text-green-700">Scientific Research</h3>
          <p class="text-gray-700">Access detailed information about plant taxonomy, distribution, and conservation status. Contribute to scientific research and help in the preservation of Kazakhstan's unique flora.</p>
        </div>
      </div>
    </section>

    <!-- Features Section -->
    <section class="bg-green-50 py-16 px-8">
      <div class="max-w-6xl mx-auto">
        <h2 class="text-3xl font-bold text-center mb-12 text-green-800">Key Features</h2>
        <div class="grid md:grid-cols-3 gap-8">
          <div class="text-center">
            <div class="bg-green-100 w-16 h-16 rounded-full flex items-center justify-center mx-auto mb-4">
              <svg class="w-8 h-8 text-green-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"></path>
              </svg>
            </div>
            <h3 class="text-xl font-semibold mb-2">Comprehensive Database</h3>
            <p class="text-gray-600">Detailed records of endemic and endangered species with scientific classifications.</p>
          </div>
          <div class="text-center">
            <div class="bg-green-100 w-16 h-16 rounded-full flex items-center justify-center mx-auto mb-4">
              <svg class="w-8 h-8 text-green-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"></path>
              </svg>
            </div>
            <h3 class="text-xl font-semibold mb-2">Conservation Focus</h3>
            <p class="text-gray-600">Highlight endangered species and support conservation efforts.</p>
          </div>
          <div class="text-center">
            <div class="bg-green-100 w-16 h-16 rounded-full flex items-center justify-center mx-auto mb-4">
              <svg class="w-8 h-8 text-green-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.746 0 3.332.477 4.5 1.253v13C19.832 18.477 18.246 18 16.5 18c-1.746 0-3.332.477-4.5 1.253"></path>
              </svg>
            </div>
            <h3 class="text-xl font-semibold mb-2">Educational Resource</h3>
            <p class="text-gray-600">Learn about Kazakhstan's plant diversity and ecological importance.</p>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
export default {
  name: 'Home'
}
</script>