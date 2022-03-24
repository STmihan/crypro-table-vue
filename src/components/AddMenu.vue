<template>
  <div class="add-menu">
    <h3>
      Coin
    </h3>
    <div class="input-container">
      <form @submit.prevent>
        <StyledInput v-bind:value="name" @input="name = $event.target.value" placeholder="Coin" />
        <StyledButton v-on:keydown.enter="onSubmit" @click="onSubmit">Add</StyledButton>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "AddMenu",
  data(){
    return {
      name: ""
    }
  },
  methods: {
    onSubmit(){
      this.$emit('addCard', this.createCard())
    },
    createCard(){
      if (this.name == null || this.name.trim() === '') return null;
      const card = {name: this.name.toUpperCase(), price: '-'};
      this.name = '';
      return card;
    }
  }
};
</script>

<style lang="scss" scoped>
.add-menu {
  display: flex;
  flex-direction: column;
  .input-container{
    height: 30px;
    width: 100%;
  }
}
</style>