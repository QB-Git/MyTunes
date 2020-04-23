<template>
    <div>
        <div>Page A</div>
        <p>{{ $route.params.id }}</p>
    </div>
</template>

<script>
    export default {
        name: 'PageA'
    }
</script>
