<template>
    <v-card>
        <v-card-title>
            Listagem de Cidades
            <v-spacer></v-spacer>
            <v-text-field v-model="search"
                          append-icon="search"
                          label="Search"
                          single-line
                          hide-details></v-text-field>
        </v-card-title>
        <v-data-table :headers="headers"
                      :items="cidades"
                      :search="search"></v-data-table>

        <template v-slot:item.cidade="{ item }">
            <td>{{ item.cidade | cidade }}</td>
        </template>

        <template v-slot:item.regiao="{ item }">
            <td>{{ item.regiao | regiao }}</td>
        </template>

        <template v-slot:item.latitude="{ item }">
            <td>{{ item.latitude | latitude }}</td>
        </template>

        <template v-slot:item.longitude="{ item }">
            <td>{{ item.longitude | longitude }}</td>
        </template>

        <template v-slot:item.ibge="{ item }">
            <td>{{ item.ibge | ibge }}</td>
        </template>

        <template v-slot:item.uf="{ item }">
            <td>{{ item.uf | uf }}</td>
        </template>
    </v-card>
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
        ];

        private async created() {
            await this.fetchCidades();
        }

        private async fetchCidades() {
            try {
                const response = await axios.get<Cidade[]>('api/Cidade');
                this.cidades = response.data;
            } catch (e) {
                this.showError = true;
                this.errorMessage = 'Erro ao ler as cidades: ${e.message}.';
            }
            this.loading = false;
        }
    }
</script>