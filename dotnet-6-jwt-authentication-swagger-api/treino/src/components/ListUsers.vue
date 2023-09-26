<script>
async function getUsers() {
  let url = "users.json";
  try {
    let res = await fetch(url);
    return await res.json();
  } catch (error) {
    console.log(error);
  }
}

export default {
  mounted() {
    console.log("Carregou a pagina");
    this.getAll(); // 0
  },
  methods: {
    getAll() {
      let urlApi = "https://localhost:57022/Users";
      fetch(urlApi, {
        method: "GET",
        headers: {
          Accept: "application/json, text/plain, */*",
          "Content-Type": "application/json",
        },
      })
        .then(async (response) => {
          const data = await response.json();

          data.forEach((element) => {
            console.log(element.firstName);
            console.log(element.username);
          });
          this.rows = data;
          return data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
  data: () => ({
    columns: ["firstName", "id", "signo"],
    rows: [],
  }),
};
</script>

<template>
  <table id="secondTable">
    <thead>
      <tr>
        <th v-for="col in columns">{{ col }}</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="row in rows">
        <td v-for="col in columns">{{ row[col] }}</td>
      </tr>
    </tbody>
  </table>
</template>

<style>
table,
th,
td {
  border: 1px solid;
}
</style>
