<script setup>
import { RouterView } from 'vue-router';
</script>

<template>
  <div>
    <Suspense>
      <RouterView/>
    </Suspense>
  </div>
</template>

