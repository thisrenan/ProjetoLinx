import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
          path: '/ExibicaoCidade',
          name: 'Manuten��o de Cidades',
          component: () => import('./views/ExibicaoCidade.vue'),
      },
      {
          path: '/CadastroCidade',
          name: 'Cadastro de Cidades',
          component: () => import('./views/CadastroCidade.vue'),
      },
      {
          path: '/RelatorioRegiao',
          name: 'Relat�rio Regiao',
          component: () => import('./views/RelatorioRegiao.vue'),
      },
      {
          path: '/RelatorioUf',
          name: 'Relat�rio UF',
          component: () => import('./views/RelatorioUf.vue'),
      },
  ],
});
