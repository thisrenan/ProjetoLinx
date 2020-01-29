<template>
    <div>
        <h1>Quantidade de cidades por UF</h1>
        <v-data-table :headers="headerUf"
                      :items="relatorioUf"
                      item-key="name"
                      class="elevation-1"
                      :search="search">
            <template v-slot:body.append>
            </template>
        </v-data-table>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import { RelatorioUf } from '../models/RelatorioUf';
    import axios from 'axios';

    @Component({})
    export default class CidadeView extends Vue {
        private loading: boolean = true;
        private showError: boolean = false;
        private errorMessage: string = 'Error while loading cidades.';
        private relatorioUf: RelatorioUf[] = [];
        private headerUf = [
            { text: 'UF', value: 'uf', sortable: true },
            { text: 'Quantidade', value: 'count', sortable: true },
        ];

        private async created() {
            await this.fetchCidadesUf();
        }

        private async fetchCidadesUf() {
            try {
                const response = await axios.get<RelatorioUf[]>('api/Cidade/GetCidadeUf');
                this.relatorioUf = response.data;
            } catch (e) {
                this.showError = true;
                this.errorMessage = 'Erro ao ler as cidades: ' + e.message;
            }
            this.loading = false;
        }
    }
</script>