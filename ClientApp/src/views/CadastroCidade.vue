<template>
    <v-form ref="form"
            v-model="valid"
            lazy-validation>
        <v-text-field v-model="cidade"
                      :counter="100"
                      :rules="nameRules"
                      label="Name"
                      required></v-text-field>

        <v-text-field v-model="regiao"
                      :counter="100"
                      :rules="regiaoRules"
                      label="Regiao"
                      required></v-text-field>

        <v-text-field v-model="latitude"
                      :rules="latitudeRules"
                      label="Latitude"
                      placeholder="-999.999.999.999"
                      required></v-text-field>

        <v-text-field v-model="longitude"
                      :rules="longitudeRules"
                      label="longitude"
                      placeholder="-999.999.999.999"
                      required></v-text-field>

        <v-text-field v-model="ibge"
                      :rules="ibgeRules"
                      label="IBGE"
                      placeholder="9999999"
                      required></v-text-field>

        <v-autocomplete ref="UF"
                        v-model="uf"
                        :rules="ufRules"
                        :items="estados"
                        label="UF"
                        placeholder="selecione o estado..."
                        required></v-autocomplete>

        <v-btn :disabled="!valid"
               color="success"
               class="mr-4"
               @click="formSubmit">
            Salvar
        </v-btn>

        <v-btn color="error"
               class="mr-4"
               @click="reset">
            Reset Form
        </v-btn>
    </v-form>
</template>


<script>
    import axios from 'axios';
     import { Component, Vue } from 'vue-property-decorator';

    export default {
        data: () => ({
            postBody: '',
            output: '',
            valid: true,
            estados: ['AC', 'AL', 'AM', 'AP', 'BA', 'CE', 'DF', 'ES', 'GO', 'MA', 'MG', 'MS', 'MT', 'PA', 'PB', 'PE', 'PI', 'PR', 'RJ', 'RN', 'RO', 'RR', 'RS', 'SC', 'SE', 'SP', 'TO'],
            name: '',
            nameRules: [
                v => !!v || 'Nome da cidade obrigatorio',
                v => (v && v.length <= 100) || 'Nome da cidade deve ter menos de 100 caracteres',
            ],
            regiao: '',
            regiaoRules: [
                v => !!v || 'Regiao obrigatorio',
                v => (v && v.length <= 100) || 'Regiao deve ter menos de 100 caracteres',
            ],
            latitude: '',
            latitudeRules: [
                v => !!v || 'Latitude obrigatorio',
            ],
            longitude: '',
            longitudeRules: [
                v => !!v || 'Longitude obrigatorio',
            ],
            ibge: '',
            ibgeRules: [
                v => !!v || 'IBGE obrigatorio',
            ],
            uf: '',
            ufRules: [
                v => !!v || 'UF obrigatorio',
            ],
        }),

        methods: {
            reset() {
                this.$refs.form.reset()
            },
            validate() {
                if (this.$refs.form.validate()) {
                    this.snackbar = true
                }
            },

            formSubmit() {
                console.log('teste');
                axios.post('api/Cidade/Post', { cidade: this.cidade, regiao: this.regiao, latitude: this.latitude, longitude: this.longitude, uf: this.uf, ibge: this.ibge }).then(result => {
                    alert("Cidade cadastrada com sucesso!");
                    this.$refs.form.reset()
                })
            },
        },
    }
</script>