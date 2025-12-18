module.exports = {
  content: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  theme: {
    extend: {},
  },
  plugins: [require('daisyui')],
  daisyui: {
    themes: [
      {
        floraLight: {
          "primary": "#16a34a",
          "secondary": "#065f46",
          "accent": "#4ade80",
          "neutral": "#f7fafc",
          "base-100": "#ffffff",
          "info": "#3abff8",
          "success": "#16a34a",
          "warning": "#f59e0b",
          "error": "#dc2626"
        }
      },
      {
        dark: {
          'primary': '#22223b',
          'secondary': '#4a4e69',
          'accent': '#9a8c98',
          'neutral': '#23272a',
          'base-100': '#18181b',
          'info': '#3abff8',
          'success': '#16a34a',
          'warning': '#f59e0b',
          'error': '#dc2626',
          'base-content': '#f3f4f6'
        }
      }
    ]
  }
}
