<template>
    <div>
        <h1>Listagem de Cidades</h1>
        <v-data-table :headers="headers"
                      :items="cidades"
                      item-key="name"
                      class="elevation-1"
                      :search="search">
            <template v-slot:body.append>
            </template>

            <template v-slot:item.action="{ item }">
                <v-icon small
                        @click="deleteItem(item)">
                    delete
                </v-icon>
            </template>

        </v-data-table>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import { Cidade } from '../models/Cidade';
    import axios from 'axios';

    @Component({})
    export default class CidadeView extends Vue {
        private loading: boolean = true;
        private showError: boolean = false;
        private errorMessage: string = 'Error while loading cidades.';
        private cidades: Cidade[] = [];
        private headers = [
            { text: 'Cidade', value: 'cidade', sortable: true },
            { text: 'Regiao', value: 'regiao', sortable: true },
            { text: 'Latitude', value: 'latitude', sortable: true },
            { text: 'Longitude', value: 'longitude', sortable: true },
            { text: 'IBGE', value: 'ibge', sortable: true },
            { text: 'UF', value: 'uf', sortable: true },
            { text: 'Remover', value: 'action', sortable: false },
        ];

        private async created() {
            await this.fetchCidades();
        }

        private async fetchCidades() {
            try {
                const response = await axios.get<Cidade[]>('api/Cidade/Get');
                this.cidades = response.data;
            } catch (e) {
                this.showError = true;
                this.errorMessage = 'Erro ao ler as cidades: ' + e.message;
            }
            this.loading = false;
        }

        private async deleteItem(item) {
            if (confirm('Tem certeza que deseja remover essa cidade?')) {
                axios.delete('api/Cidade/Remove/' + item.idCidade)
                    .then(result => {
                        let indice = this.cidades.indexOf(item)
                        this.cidades.splice(indice, 1)
                    })
                    .catch(err => {
                        //
                    });
            }
        }
    }
</script>