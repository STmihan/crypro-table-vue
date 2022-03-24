import { createStore } from "vuex";
import { getPrices } from "@/wrappers/dto";

const api = 'a95992a47639a84e615747d806241b2b00d7514529d74a6ec85e0b4c5c1cf008';
const LS_KEY = "coins"

export default createStore({
  state: {
    isAuth: false,
    username:'',
    coins: [],
    jwt: ""
  },
  getters: {
    coinsString: state => {
      let str = '';
      if(state.coins.length === 0) return str;
      state.coins.forEach(c => str+=c.name + ',');
      str = str.slice(0, -1);
      return str;
    }
  },
  mutations: {
    setAuth(state, set) {state.isAuth = set},
    setUsername(state, set) {state.username = set},
    setCoins(state, coinsString) {
      state.coins = [];
      if(coinsString.trim() === '') return;
      const coins = coinsString.split(',');
      coins.forEach(coin => state.coins.push({name: coin, price: '-'}));
    },
    setToken(state, token) {state.jwt = token},
    setCoinPrice(state, coin)
    {
      state.coins.find(c => c.name === coin.name).price = coin.price;
    }
  },
  actions: {
    updatePrices({commit, getters}) {
      getPrices(getters.coinsString).then(pairs => {
        if(pairs == null || pairs.length === 0) return;
        for (const pair of pairs) {
          commit("setCoinPrice", {name: pair.name, price: pair.price});
        }
      });
    }
  },
  modules: {

  }
})
