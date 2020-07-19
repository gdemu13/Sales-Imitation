<template>
  <div class="confirm-box">
    <div class="user-box">
      <input type="text" v-model="txtPromo" required />
      <label>პრომო კოდი</label>
    </div>
    <button class="btn btn-5" @click="check()">შემოწმება</button>
    <div class="products">
      <div class="product-item">
        <label for>{{prod1.name}}</label>
        <br />
        <img :src="prod1.imageUrl" alt />
        <br />
      </div>
      <div class="product-item">
        <label for>{{prod2.name}}</label>
        <br />
        <img :src="prod2.imageUrl" alt />
        <br />
      </div>
      <button
        v-if="prod1.id"
        class="btn btn-5"
        style="position: absolute;bottom: -20px; left: 92px;"
        @click="submit(prod1.id)"
      >დადასტურება</button>
      <button
        v-if="prod2.id"
        class="btn btn-5"
        style="position: absolute;bottom: -20px; right: 92px;"
        @click="submit(prod1.id)"
      >დადასტურება</button>
    </div>
  </div>
</template>

<script>
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";

Vue.use(VueAxios, axios);

export default {
  name: "confirm-sale",
  data: function() {
    return {
      txtPromo: "",
      prod1: {},
      prod2: {}
    };
  },
  methods: {
    check() {
      var self = this;
      Vue.axios.get("/api/Sales/CheckCode/" + this.txtPromo).then(response => {
        console.log(response.data);
        self.prod1 = response.data.product1;
        self.prod2 = response.data.product2;
      });
    },
    submit(id) {
      var self = this;
      Vue.axios
        .post("/api/Sales/confirm", { code: self.txtPromo, productID: id })
        .then(response => {
          if (response.data.isSuccess) {
            self.txtPromo = "";
            self.prod1 = {};
            self.prod2 = {};
            alert("პროდუქტის გაყიდვა დადასტურდა");
          } else alert(response.data.message);
        });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.btnprod1 {
  position: absolute;
  bottom: 0;
  right: 92px;
}

.btnprod2 {
  position: absolute;
  bottom: 0;
  right: 92px;
}

.confirm-box {
  position: absolute;
  text-align: center;
  top: 50%;
  left: 50%;
  width: 600px;
  padding: 40px;
  padding-bottom: 65px;
  transform: translate(-50%, -50%);
  background: rgba(0, 0, 0, 0.5);
  box-sizing: border-box;
  box-shadow: 0 15px 25px rgba(0, 0, 0, 0.6);
  border-radius: 10px;
}

.confirm-box .user-box {
  position: relative;
}

.product-item {
  widows: 300px;
  float: left;
}

.product-item img {
  width: 250px;
}
.product-item label {
  color: white;
}

.confirm-box .user-box input {
  width: 100%;
  padding: 10px 0;
  font-size: 16px;
  color: #fff;
  margin-bottom: 30px;
  border: none;
  border-bottom: 1px solid #fff;
  outline: none;
  background: transparent;
}
.confirm-box .user-box label {
  position: absolute;
  top: 0;
  left: 0;
  padding: 10px 0;
  font-size: 16px;
  color: #fff;
  pointer-events: none;
  transition: 0.5s;
}

.confirm-box .user-box input:focus ~ label,
.confirm-box .user-box input:valid ~ label {
  top: -20px;
  left: 0;
  /* color: #03e9f4; */
  font-size: 12px;
}

@import url(https://fonts.googleapis.com/css?family=Roboto:400, 100, 900);
* {
  box-sizing: inherit;
  -webkit-transition-property: all;
  transition-property: all;
  -webkit-transition-duration: 0.6s;
  transition-duration: 0.6s;
  -webkit-transition-timing-function: ease;
  transition-timing-function: ease;
}

.buttons {
  display: -webkit-box;
  display: flex;
  -webkit-box-orient: vertical;
  -webkit-box-direction: normal;
  flex-direction: column;
  height: 100%;
  -webkit-box-pack: center;
  justify-content: center;
  text-align: center;
  width: 100%;
}

.container {
  -webkit-box-align: center;
  align-items: center;
  display: -webkit-box;
  display: flex;
  -webkit-box-orient: vertical;
  -webkit-box-direction: normal;
  flex-direction: column;
  -webkit-box-pack: center;
  justify-content: center;
  padding: 1em;
  text-align: center;
}
@media (min-width: 600px) {
  .container {
    -webkit-box-orient: horizontal;
    -webkit-box-direction: normal;
    flex-direction: row;
    -webkit-box-pack: justify;
    justify-content: space-between;
  }
}

h1 {
  color: #fff;
  font-size: 1.25em;
  font-weight: 900;
  margin: 0 0 2em;
}
@media (min-width: 450px) {
  h1 {
    font-size: 1.75em;
  }
}
@media (min-width: 760px) {
  h1 {
    font-size: 3.25em;
  }
}
@media (min-width: 900px) {
  h1 {
    font-size: 5.25em;
    margin: 0 0 1em;
  }
}

p {
  color: #fff;
  font-size: 12px;
}
@media (min-width: 600px) {
  p {
    left: 50%;
    position: absolute;
    -webkit-transform: translate(-50%, 0);
    transform: translate(-50%, 0);
    top: 90%;
  }
}
@media (max-height: 500px) {
  p {
    left: 0;
    position: relative;
    top: 0;
    -webkit-transform: translate(0, 0);
    transform: translate(0, 0);
  }
}
p a {
  background: rgba(255, 255, 255, 0);
  border-bottom: 1px solid;
  color: #fff;
  line-height: 1.4;
  padding: 0.25em;
  text-decoration: none;
}
p a:hover {
  background: white;
  color: #e1332d;
}

.btn {
  color: #fff;
  cursor: pointer;
  font-size: 16px;
  font-weight: 400;
  line-height: 45px;
  margin: 0 0 2em;
  max-width: 160px;
  position: relative;
  text-decoration: none;
  text-transform: uppercase;
  width: 100%;
}
@media (min-width: 600px) {
  .btn {
    margin: 0 1em 2em;
  }
}
.btn:hover {
  text-decoration: none;
}

.btn-1 {
  background: #e02c26;
  font-weight: 100;
}
.btn-1 svg {
  height: 45px;
  left: 0;
  position: absolute;
  top: 0;
  width: 100%;
}
.btn-1 rect {
  fill: none;
  stroke: #fff;
  stroke-width: 2;
  stroke-dasharray: 422, 0;
  -webkit-transition: all 0.35s linear;
  transition: all 0.35s linear;
}

.btn-1:hover {
  background: rgba(225, 51, 45, 0);
  font-weight: 900;
  letter-spacing: 1px;
}
.btn-1:hover rect {
  stroke-width: 5;
  stroke-dasharray: 15, 310;
  stroke-dashoffset: 48;
  -webkit-transition: all 1.35s cubic-bezier(0.19, 1, 0.22, 1);
  transition: all 1.35s cubic-bezier(0.19, 1, 0.22, 1);
}

.btn-2 {
  letter-spacing: 0;
  background: #19427f;
}

.btn-2:hover,
.btn-2:active {
  letter-spacing: 5px;
}

.btn-2:after,
.btn-2:before {
  -webkit-backface-visibility: hidden;
  backface-visibility: hidden;
  border: 1px solid rgba(255, 255, 255, 0);
  bottom: 0px;
  content: " ";
  display: block;
  margin: 0 auto;
  position: relative;
  -webkit-transition: all 280ms ease-in-out;
  transition: all 280ms ease-in-out;
  width: 0;
}

.btn-2:hover:after,
.btn-2:hover:before {
  -webkit-backface-visibility: hidden;
  backface-visibility: hidden;
  border-color: #fff;
  -webkit-transition: width 350ms ease-in-out;
  transition: width 350ms ease-in-out;
  width: 70%;
}

.btn-2:hover:before {
  bottom: auto;
  top: 0;
  width: 70%;
}

.btn-3 {
  background: #e3403a;
  border: 1px solid #da251f;
  box-shadow: 0px 2px 0 #d6251f, 2px 4px 6px #e02a24;
  font-weight: 900;
  letter-spacing: 1px;
  -webkit-transition: all 150ms linear;
  transition: all 150ms linear;
}

.btn-3:hover {
  background: #e02c26;
  border: 1px solid rgba(0, 0, 0, 0.05);
  box-shadow: 1px 1px 2px rgba(255, 255, 255, 0.2);
  color: #ec817d;
  text-decoration: none;
  text-shadow: -1px -1px 0 #c2211c;
  -webkit-transition: all 250ms linear;
  transition: all 250ms linear;
}

.btn-4 {
  border: 1px solid;
  overflow: hidden;
  position: relative;
}
.btn-4 span {
  z-index: 20;
}
.btn-4:after {
  background: #fff;
  content: "";
  height: 155px;
  left: -75px;
  opacity: 0.2;
  position: absolute;
  top: -50px;
  -webkit-transform: rotate(35deg);
  transform: rotate(35deg);
  -webkit-transition: all 550ms cubic-bezier(0.19, 1, 0.22, 1);
  transition: all 550ms cubic-bezier(0.19, 1, 0.22, 1);
  width: 50px;
  z-index: -10;
}

.btn-4:hover:after {
  left: 120%;
  -webkit-transition: all 550ms cubic-bezier(0.19, 1, 0.22, 1);
  transition: all 550ms cubic-bezier(0.19, 1, 0.22, 1);
}

.btn-5 {
  background: #19427f;
  border: 0 solid;
  box-shadow: inset 0 0 20px rgba(255, 255, 255, 0);
  outline: 1px solid;
  outline-color: rgba(255, 255, 255, 0.5);
  outline-offset: 0px;
  text-shadow: none;
  -webkit-transition: all 1250ms cubic-bezier(0.19, 1, 0.22, 1);
  transition: all 1250ms cubic-bezier(0.19, 1, 0.22, 1);
}

.btn-5:hover {
  border: 1px solid;
  box-shadow: inset 0 0 20px rgba(255, 255, 255, 0.5),
    0 0 20px rgba(255, 255, 255, 0.2);
  outline-color: rgba(255, 255, 255, 0);
  outline-offset: 15px;
  text-shadow: 1px 1px 2px #427388;
}
</style>
