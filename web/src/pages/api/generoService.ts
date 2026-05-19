import { api } from "./api";

export async function cadastrarGenero(nome: string) {
    try {
        await api.post("Genero", { nome });
    } catch (error: any) {
        throw new Error(error.response.data);
    }
}

export async function listarGenero() {
    try {
        const response = await api.get("Genero");
        return response;
    } catch (error: any) {
        throw new Error(error.response.data);
    }
}