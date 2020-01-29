<template>
    <div>
        <h1>Quantidade de cidades por Regiao</h1>
        <v-data-table :headers="headerRegiao"
                      :items="relatorioRegiao"
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
    import { RelatorioRegiao } from '../models/RelatorioRegiao';
    import axios from 'axios';

    @Component({})
    export default class CidadeView extends Vue {
        private loading: boolean = true;
        private showError: boolean = false;
        private errorMessage: string = 'Error while loading cidades.';
        private relatorioRegiao: RelatorioRegiao[] = [];
        private headerRegiao = [
            { text: 'Regiao', value: 'regiao', sortable: true },
            { text: 'Quantidade', value: 'count', sortable: true },
        ];

        private async created() {
            await this.fetchCidadesRegiao();
        }

        private async fetchCidadesRegiao() {
            try {
                const response = await axios.get<RelatorioRegiao[]>('api/Cidade/GetCidadeRegiao');
                this.relatorioRegiao = response.data;
            } catch (e) {
                this.showError = true;
                this.errorMessage = 'Erro ao ler as cidades: ' + e.message;
            }
            this.loading = false;
        }
    }
</script>