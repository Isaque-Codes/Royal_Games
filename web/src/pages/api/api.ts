import axios from "axios";

const apiLocal = "https://localhost:7057/api/";

const apiRemota = "";

//criar um endereco da api dentro do axios
export const api = axios.create({
    baseURL: apiLocal
})