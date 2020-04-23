<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
      style="overflow-y: hidden;">
      <div class="d-flex align-center">
        <v-img
          alt="Logo"
          class="shrink mr-2"
          contain
          src="https://www.clipartwiki.com/clipimg/full/83-835364_office-iconset-vexels-transparent-light-bulb-icon-png.png"
          transition="scale-transition"
          width="40"
        />
        <v-toolbar-title style="font-size:2rem">Light Sensor</v-toolbar-title>
      </div>

      <v-spacer></v-spacer>

      <v-btn
        href="https://github.com/mikomister/vue-kafka-grps-dotnet-iot"
        target="_blank"
        text
      >
        <span class="mr-2">Github</span>
        <v-icon>mdi-open-in-new</v-icon>
      </v-btn>
    </v-app-bar>

    <v-content>
      <LightSensor/>
    </v-content>
  </v-app>
</template>

<script>
import LightSensor from './components/LightSensor';

export default {
  name: 'App',

  components: {
    LightSensor,
  },

  data: () => ({
  }),
};
</script>


