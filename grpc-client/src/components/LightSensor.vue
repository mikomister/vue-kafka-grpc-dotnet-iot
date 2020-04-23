<template>
    <v-simple-table fixed-header>
        <template v-slot:default>
            <thead>
            <tr>
                <th class="text-left">Illumination</th>
                <th class="text-left">Date and Time</th>
            </tr>
            </thead>
            <tbody>
            <tr v-for="item in light_sensor_messages.slice().reverse()" :key="item.name">
                <td>{{ item.data=="1" ? "dark":"light" }}</td>
                <td>{{ item.time }}</td>
            </tr>
            </tbody>
        </template>
    </v-simple-table>
</template>

<script>
    import {
        LightSensorMessagesRequest,
        LightSensorMessage,
        LigthSensorClient
    } from "../grpcClient"

    export default {
        data() {
            return {
                light_sensor_messages: [
                    {'data': 0, 'time': 'tested'}
                ]
            }
        },
        methods: {
            getSensorMessages: function () {
                var client = new LigthSensorClient(window.location.href.slice(0, -1));

                var request = new LightSensorMessagesRequest();
                var metadata = {'data': 'no reply', 'time': 'no reply'};
                var stream = client.getLightSensorStream(request, metadata);
                stream.on('data', (response) => {
                    try {
                        this.light_sensor_messages.push(response.toObject());
                    } catch (e) {
                        console.log(e);
                    }
                });
                stream.on('status', function (status) {
                    console.log(status.code);
                    console.log(status.details);
                    console.log(status.metadata);
                });
                stream.on('end', function (end) {
                    console.log("gRPC stream ending.", end)
                });
            }
        },
        mounted() {
            this.getSensorMessages()
        }
    }

</script>
