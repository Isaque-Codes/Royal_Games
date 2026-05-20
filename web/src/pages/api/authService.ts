import { api } from "./api";
import secureLocalStorage from "react-secure-storage";

export async function login(Email: string, Senha: string) {
    try {
        const response = await api.post("Autenticacao/login", { Email, Senha });
         console.log("Funcionou!");
         console.log(response.data.token);
        const token = response.data.token;

        localStorage.setItem("nomeToken", token);
        secureLocalStorage.setItem("Token", token);

    } catch (error: any) {
        console.error("Erro:", error.response?.data || error.message);
        throw new Error("Email ou senha inválidos");
    }
}