import { createApp } from 'vue'
import App from './App'
import components from "@/components";
import store from "@/store";

const app = createApp(App);

components.forEach(c => app.component(c.name, c));

app.use(store).mount('#app');
