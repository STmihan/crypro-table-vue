<template>
  <div v-if="cards.length" class="cards-container">
    <hr>
    <div class="cards-list">
      <Card @deleteCard="deleteCard" :card="card" :key="card.name" v-for="card in cards"/>
    </div>
    <hr>
  </div>
</template>

<script>
export default {
  name: "CardContainer",
  props: {
    cards: {
      type: Array,
      require: true
    }
  },
  data() {
    return {

    }
  },
  methods: {
    deleteCard(card) {
      this.$emit('deleteCard', card)
    }
  }
};
</script>

<style lang="scss" scoped>
hr{
  border: 1.3px solid rgba(27, 31, 35, 0.15);
  background-color: rgba(27, 31, 35, 0.15);
  border-radius: 2px;
}
.cards-list{
  margin: 0 auto;
  width: 80%;
  padding: 10px;
  display: flex;
  flex-wrap: wrap;
}
</style>