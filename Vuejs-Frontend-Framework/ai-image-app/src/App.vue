<template>
  <HelloWorld1 />
  <MyTable1></MyTable1>
</template>

<script>
import HelloWorld1 from "./components/AIimage.vue";
import MyTable1 from "./components/table1.vue";

export default {
  name: "App",
  components: {
    HelloWorld1,
    MyTable1,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
