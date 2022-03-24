import axios from "axios";

const LS_KEY = "coins"

const api = 'a95992a47639a84e615747d806241b2b00d7514529d74a6ec85e0b4c5c1cf008';


export async function getPrices(coins) {
  console.log(coins);
  if (coins.length === 0) return [];
  const data = [];
  const url = 'https://min-api.cryptocompare.com/data/pricemulti?fsyms=' + coinsToString(coins) + '&tsyms=USD&api_key=' + api;
  let response;
  try {
    response = await axios.get(url);
  } catch (error) {
  }
  for (const coin of coins) {
    const priceInUSD = response.data[coin.name]['USD'];
    data.push({name: coin.name, price: priceInUSD});
  }
  return data;
}

export function getCoins() {
  let x = localStorage.getItem(LS_KEY);
  if (x == null) return '';
  x = x.trim();

  return x !== '' ? x.split(',') : '';
}

export function saveCoins(coins) {
  const str = coinsToString(coins);
  localStorage.setItem(LS_KEY, str);
}

export function coinsToString(coins) {
  let str = '';
  coins.forEach(c => str+=c.name + ',');
  str = str.slice(0, -1);
  return str;
}