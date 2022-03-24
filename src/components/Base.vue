<template>
  <div class="container">
    <AddMenu @addCard="addCard" />
    <CardContainer @deleteCard="deleteCard" :cards="coins"/>
    <StyledButton @click="updatePrice">Update</StyledButton>
  </div>
</template>

<script>
import { getCoins, getPrices, saveCoins } from "@/wrappers/dto";

export default {
  name: "Base",
  data() {
    return {
      coins: []
    }
  },
  methods: {
    deleteCard(name) {
      this.coins = this.coins.filter(coin => coin.name !== name);
    },
    addCard(name) {
      if(this.coins.find(coin => coin.name === name) || name.trim() === '') return;
      this.coins.push({name: name, price: '-'});
      this.updatePrice();
      saveCoins(this.coins);
    },
    updatePrice() {
      getPrices(this.coins).then(value => {
        for (let i = 0; i < value.length; i++) {
          this.coins.find(coin => coin.name === value[i].name).price = value[i].price;
        }
      });
    },
    setup() {
      const coins = getCoins();
      if (coins !== '')
        coins.forEach(coin => this.coins.push({name: coin, price: '-'}));
    }
  },
  mounted() {
    this.setup();
    this.updatePrice();
  }
};
</script>

<style lang="scss">
.container {
  margin: 0 auto;
  width: 80%;
  height: 100%;
}
.add-menu{
  margin-top: 80px;
  margin-bottom: 30px;
}
</style>
