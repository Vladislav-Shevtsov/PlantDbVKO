<template>
  <div class="min-h-screen bg-gray-50 py-16 px-8">
    <div class="max-w-4xl mx-auto">
      <h1 class="text-4xl font-bold text-center mb-12 text-green-800">About Us</h1>

      <div class="bg-white rounded-lg shadow-lg p-8 mb-8">
        <h2 class="text-2xl font-semibold mb-6 text-green-700">Our Mission</h2>
        <p class="text-gray-700 mb-4">
          The Endemic Endangered Plants of Kazakhstan database is dedicated to documenting and preserving information about Kazakhstan's unique plant species. Many of these plants are endemic to the region and face various threats from climate change, habitat loss, and human activities.
        </p>
        <p class="text-gray-700 mb-4">
          Our platform serves as a comprehensive resource for botanists, conservationists, researchers, and nature enthusiasts interested in Kazakhstan's rich floral biodiversity.
        </p>
      </div>

      <div class="bg-white rounded-lg shadow-lg p-8 mb-8">
        <h2 class="text-2xl font-semibold mb-6 text-green-700">What We Do</h2>
        <ul class="list-disc list-inside text-gray-700 space-y-2">
          <li>Maintain a detailed database of endemic and endangered plant species</li>
          <li>Provide taxonomic classifications and relationships</li>
          <li>Share information on distribution, habitat, and conservation status</li>
          <li>Support research and conservation efforts</li>
          <li>Educate the public about Kazakhstan's plant diversity</li>
        </ul>
      </div>

      <div class="bg-white rounded-lg shadow-lg p-8">
        <h2 class="text-2xl font-semibold mb-6 text-green-700">Contact Information</h2>
        <div class="grid md:grid-cols-2 gap-6">
          <div>
            <h3 class="text-lg font-semibold mb-2">General Inquiries</h3>
            <p class="text-gray-700">Email: info@kazakhstanflora.kz</p>
            <p class="text-gray-700">Phone: +7 (727) 123-45-67</p>
          </div>
          <div>
            <h3 class="text-lg font-semibold mb-2">Research Collaboration</h3>
            <p class="text-gray-700">Email: research@kazakhstanflora.kz</p>
            <p class="text-gray-700">Phone: +7 (727) 123-45-68</p>
          </div>
        </div>
        <div class="mt-6">
          <h3 class="text-lg font-semibold mb-2">Address</h3>
          <p class="text-gray-700">
            Institute of Botany and Phytointroduction<br>
            36 Timiryazev Street<br>
            Almaty, Kazakhstan 050060
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'About'
}
</script>