<template>
  <div class="card">
    <h3>{{card.price}}</h3>
    <p>{{ card.name }}</p>
    <StyledButton @click="deleteCard(card.name)" class="btn">Delete</StyledButton>
  </div>
</template>

<script>
export default {
  name: "Card",
  props:{
    card:{
      type: Object,
      require: true
    }
  },
  data(){
    return{
    }
  },
  methods:{
    deleteCard(card){
      this.$emit('deleteCard', card)
    }
  }
};
</script>

<style lang="scss" scoped>
.card{
  width: 30%;
  height: 30%;
  min-width: 88px;
  min-height: 150px;
  max-width: 130px;
  border: 1px solid rgba(27, 31, 35, 0.15);
  border-radius: 20px;
  margin: 10px;
  text-align: center;
  .btn{

  }
}
</style>