import axios from "axios";


const api = 'a95992a47639a84e615747d806241b2b00d7514529d74a6ec85e0b4c5c1cf008';


export async function getPrices(coins) {
  if (coins.trim() === '') return null;
  const data = [];
  const url = 'https://min-api.cryptocompare.com/data/pricemulti?fsyms=' + coins + '&tsyms=USD&api_key=' + api;
  let response;
  try {
    response = await axios.get(url);
    console.log(response);
    for (const coin of coins.split(',')) {
      const priceInUSD = response.data[coin]['USD'];
      data.push({name: coin, price: priceInUSD});
    }
  } catch (error) {
  }

  return data;
}



export function getCoins() {
  const x = localStorage.getItem(LS_KEY)

  return x != null && x.trim() !== '' ? x.split(',') : '';
}

export function coinsToString(coins) {

}