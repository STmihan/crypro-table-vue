<template>
  <div class="container">
    <Login/>
    <AddMenu @addCard="addCard" />
    <CardContainer @deleteCard="deleteCard" :cards="coins"/>
    <StyledButton @click="updatePrice">Update</StyledButton>
  </div>
</template>

<script>

import { mapActions, mapGetters, mapMutations, mapState } from "vuex";

export default {
  name: "Base",
  methods: {
    deleteCard(card) {
      const coins = this.coinsString.split(',');
      const c = coins.filter(coin => card.name !== coin);
      let str = '';
      c.forEach(v => str+=v + ',');
      str = str.slice(0, -1);
      this.setCoins(str);
    },
    addCard(card) {
      const coins = this.coinsString.split(',');
      if (card == null) return;
      if (coins.find(coin => coin === card.name)) return;
      this.setCoins(this.coinsString.length ? this.coinsString + "," + card.name : card.name);
      this.updatePrice();
    },
    updatePrice() {
      this.updatePriceAction();
    },
    ...mapActions({
      updatePriceAction: "updatePrices"
    }),
    ...mapMutations({
      setCoins: "setCoins"
    })
  },
  mounted() {
    this.setCoins("BTC,ETH");
  },
  computed: {
    ...mapState({
      coins: state => state.coins
    }),
    ...mapGetters({
      coinsString: 'coinsString'
    })
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
