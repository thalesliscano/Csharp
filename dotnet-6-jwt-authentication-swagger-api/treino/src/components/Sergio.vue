<script setup>
defineProps({
  tela: {
    type: String,
    required: true,
  },
});
</script>

<template>
  <h2>Sergio componente {{ tela }}</h2>
</template>
