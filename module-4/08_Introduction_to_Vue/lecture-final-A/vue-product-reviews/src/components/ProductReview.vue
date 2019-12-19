<template>
  <div class="main">
    <h2>Product Reviews for {{ name }}</h2>

    <p class="description">{{ description }}</p>
    <input v-model="count" />
    <p>The count is {{count}}</p>
    <div v-if="Math.random() > .05">
      <p>Now you see me</p>
    </div>
    <div v-else>
      <p>Now you don't</p>
    </div>

    <h3>This is the list</h3>
    <ul id="example-1">
      <li v-for="item in items" v-bind:key="item">{{ item.message }}</li>
    </ul>
  </div>
</template>

<style scoped>
div.main {
  margin: 1rem 0;
}
</style>

<script>
export default {
  name: "product-review",
  data() {
    return {
      name: "Cigar Parties for Dummies",
      description:
        "Host and plan the perfect cigar party for all of your squirrelly friends.",
      count: 0,
      items: [
        {
          message: "foo"
        },
        {
          message: "bar"
        }
      ]
    };
  }
};
</script>