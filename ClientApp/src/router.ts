import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
          path: '/ExibicaoCidade',
          name: 'Manutenção de Cidades',
          component: () => import('./views/ExibicaoCidade.vue'),
      },
      {
          path: '/CadastroCidade',
          name: 'Cadastro de Cidades',
          component: () => import('./views/CadastroCidade.vue'),
      },
      {
          path: '/RelatorioRegiao',
          name: 'Relatório Regiao',
          component: () => import('./views/RelatorioRegiao.vue'),
      },
      {
          path: '/RelatorioUf',
          name: 'Relatório UF',
          component: () => import('./views/RelatorioUf.vue'),
      },
  ],
});
