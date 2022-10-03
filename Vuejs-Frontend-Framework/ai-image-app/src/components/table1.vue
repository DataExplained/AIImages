<template>
  <header>
    <button @click="getFunction">Refresh</button>
    <p>
      <input
        type="text"
        id="myInput"
        onkeyup="myFunction()"
        placeholder="Search for names.."
      />
    </p>

    <table id="myTable">
      <tr class="header">
        <th style="width: 60%">File Name</th>
        <th style="width: 40%">Prediction</th>
      </tr>
      <tr v-for="result in this.b" :key="result.id">
        <td>{{ result.image }}</td>
        <td>{{ result.classes }}</td>
      </tr>
    </table>
  </header>
</template>

<script>
export default {
  name: "MyTable1",
  props: {},
  data() {
    return {
      AllResult: "",
      b: [],
    };
  },
  methods: {
    async getFunction() {
      this.AllResult = "";
      var requestOptions = {
        method: "GET",
        redirect: "follow",
      };

      await fetch("https://localhost:7115/api/AIimage", requestOptions)
        .then((response) => response.text())
        .then((result) => (this.AllResult = result))
        .catch((error) => console.log("error", error));
      this.b = eval(this.AllResult);
      console.log(this.b);
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
header {
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
  margin: 3rem auto;
  border-radius: 10px;
  padding: 1rem;
  background-color: #fbfbfb;
  color: rgb(0, 0, 0);
  text-align: center;
  width: 90%;
  max-width: 40rem;
  font-size: 3rem;
}
#myInput {
  background-position: 10px 12px; /* Position the search icon */
  background-repeat: no-repeat; /* Do not repeat the icon image */
  width: 80%; /* Full-width */
  font-size: 16px; /* Increase font-size */
  padding: 12px 20px 12px 40px; /* Add some padding */
  border: 1px solid #ddd; /* Add a grey border */
  margin-bottom: 12px; /* Add some space below the input */
}

#myTable {
  border-collapse: collapse; /* Collapse borders */
  width: 100%; /* Full-width */
  border: 1px solid #ddd; /* Add a grey border */
  font-size: 18px; /* Increase font-size */
}

#myTable th,
#myTable td {
  text-align: left; /* Left-align text */
  padding: 12px; /* Add padding */
}

#myTable tr {
  /* Add a bottom border to all table rows */
  border-bottom: 1px solid #ddd;
}

#myTable tr.header,
#myTable tr:hover {
  /* Add a grey background color to the table header and on hover */
  background-color: #f1f1f1;
}
.greenButton {
  font: inherit;
  cursor: pointer;
  border: 1px solid #adfa93;
  background-color: #b1fd96;
  color: rgb(0, 0, 0);
  padding: 0.05rem 1rem;
  box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.26);
  border-radius: 10px;
  margin: 0 1rem;
}
</style>
