<template>
  <v-app>

    <v-navigation-drawer persistent :mini-variant="miniVariant" :clipped="clipped" v-model="drawer" enable-resize-watcher fixed app>
      <v-list>
        <v-list-item value="true" v-for="(item, i) in items" :key="i" :to="item.link">
          <v-list-item-action>
            <v-icon v-html="item.icon"></v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title"></v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar app :clipped-left="clipped" color="info" dark>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-btn class="d-none d-lg-flex" icon @click.stop="miniVariant = !miniVariant">
        <v-icon v-html="miniVariant ? 'chevron_right' : 'chevron_left'"></v-icon>
      </v-btn>
      <v-btn class="d-none d-lg-flex" icon @click.stop="clipped = !clipped">
        <v-icon>web</v-icon>
      </v-btn>
      <v-toolbar-title v-text="title"></v-toolbar-title>
      <v-spacer></v-spacer>
    </v-app-bar>

    <v-content>
      <router-view/>
    </v-content>

    <v-footer app>
      <span>&nbsp;Software Ateliers&nbsp;&copy;&nbsp;2019</span>
    </v-footer>

  </v-app>
</template>

<script lang="ts">
import ExibicaoCidade from '@/components/ExibicaoCidade.vue';
import { Component, Vue } from 'vue-property-decorator';

@Component({
  components: { ExibicaoCidade },
})
export default class App extends Vue {
  private clipped: boolean = true;
  private drawer: boolean = true;
  private miniVariant: boolean = false;
  private right: boolean = true;
  private title: string = 'Teste Linx';
  private items = [
      { title: 'Listagem de Cidades', icon: 'home', link: '/ExibicaoCidade' },
      { title: 'Cadastro de Cidade', icon: 'touch_app', link: '/CadastroCidade' },
      { title: 'Relatorio Regiao', icon: 'touch_app', link: '/RelatorioRegiao' },     
      { title: 'Relatorio UF', icon: 'touch_app', link: '/RelatorioUf' },     
  ];
}
</script>
