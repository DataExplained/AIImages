<template>
  <header>AI Inference</header>
  <img v-if="url === null" :src="emptyfile" height="400" width="550" />
  <img v-if="url" :src="url" height="400" width="550" />
  <p></p>
  <input type="file" @change="onFileSelected" />
  <button class="greenButton" @click="sendData">Upload</button>

  <button class="greenButton" @click="addnewImage">Refresh</button>

  <p v-if="AIResult">Prediction: {{ AIResult }}</p>
  <p v-if="probability">Probability: {{ probability }}</p>
  <p></p>
</template>

<script>
export default {
  name: "HelloWorld1",
  props: {},
  data() {
    return {
      contents: null,
      info: null,
      emptyfile: "./assets/empty.png",
      AIResult: "",
      ImageId: 0,
      counter: 0,
      ImageResult: "",
      url: null,
      base64: "",
      text: "",
      probability: "",
      i: 1,
      list_of_result: [],
      filename: "",
    };
  },

  methods: {
    addnewImage() {
      this.url = null;
      this.base64 = "";
      this.i = 1;
      this.AIResult = "";
      this.probability = "";
      this.list_of_result = [];
      this.filename = "";
    },

    async sendData() {
      var myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/json");

      var raw = JSON.stringify({
        ImageBase64: this.base64,
        Filename: this.filename,
      });

      var requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: raw,
        redirect: "follow",
      };

      await fetch("http://127.0.0.1:4557/AIPrediction", requestOptions)
        .then((response) => response.text())
        .then((result) => (this.AIResult = result))
        .catch((error) => console.log("error", error));

      //console.log(this.AIResult);
      this.text = this.AIResult;
      const myArray = this.text.split(" ");
      console.log(this.text);
      const temp = this.text.split("probability=")[1];
      console.log("temp is " + temp);
      this.probability = temp.split(" ")[0];
      this.list_of_result = [];
      this.i = 1;
      while (myArray[this.i].includes(";") === false) {
        this.list_of_result.push(myArray[this.i]);
        this.i = this.i + 1;
      }
      console.log(this.list_of_result);
      this.AIResult = this.list_of_result.join(" ");
    },
    myFunction() {},

    onFileSelected(event) {
      this.AIResult = "";
      this.probability = "";
      console.log(event);
      this.url = URL.createObjectURL(event.target.files[0]);
      const reader = new FileReader();

      reader.onloadend = () => {
        this.base64 = reader.result;
      };

      //console.log(event.target.files[0].name);
      this.filename = event.target.files[0].name;
      reader.readAsDataURL(event.target.files[0]);
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
* {
  box-sizing: border-box;
}

html {
  font-family: "Jost", sans-serif;
}

body {
  margin: 0;
}
p {
  margin: 3rem auto;
  text-align: center;
  width: 90%;
  max-width: 40rem;
  font-size: 1rem;
}
header {
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
  margin: 3rem auto;
  border-radius: 10px;
  padding: 1rem;
  background-color: #74e2b1;
  color: white;
  text-align: center;
  width: 90%;
  max-width: 40rem;
  font-size: 3rem;
}
h2 {
  font-size: 2rem;
  border-bottom: 4px solid #ccc;
  color: #4fc08d;
  margin: 0 0 1rem 0;
}
button:active {
  background-color: #e8e8e8;
  border-color: #eeeeee;
  box-shadow: 1px 1px 4px rgba(0, 0, 0, 0.26);
}
.greenButton {
  font: inherit;
  cursor: pointer;
  border: 1px solid #adfa93;
  background-color: #b1fd96;
  color: rgb(0, 0, 0);
  padding: 0.05rem 1rem;
  box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.26);
  border-radius: 20px;
  margin: 0 1rem;
}
</style>
