import { api } from "./api";


type JogoFormulario = {
    nome: string,
    descricao: string,
    preco: string,
    plataforma: string,
    imagem: File | null,
    classificacaoId: number[],
    generoId: number[]
}

interface JogoListagem {
    nome: string,
    descricao: string,
    preco: string,
    generoId: number[],
    classificacaoId: number[],
    plataforma: string,
    imagemUrl: string,
    statusJogo: boolean
}

export async function cadastrarJogo(dados: JogoFormulario) {
    try {
        const formData = new FormData();

        formData.append("nome", dados.nome);
        formData.append("descricao", dados.descricao);
        formData.append("preco", dados.preco);
        formData.append("plataforma", dados.plataforma);
        if (dados.imagem) {
            formData.append("imagem", dados.imagem);
        }
        dados.generoId.forEach((id) => {
            formData.append("generoIds", id.toString());
        })
        dados.classificacaoId.forEach((id) => {
            formData.append("classificacaoIds", id.toString());
        })


        await api.post("Jogos", formData);

    } catch (error: any) {
        throw new Error(error.response.data);
    }
}

export async function listarJogo() {
    try {
        const response = await api.get("Jogo");



        const jogosAtivos = response.data.filter(
            (jogo: JogoListagem) => jogo.statusJogo === true
        );

        const jogos = jogosAtivos.map((jogo: JogoListagem) => ({
            ...jogo,
            imagemUrl: `${api.defaults.baseURL}${jogo.imagemUrl}`
        }));

        return jogos;

    } catch (error: any) {
        throw new Error(error.response.data);
    }
}

export async function listarPorId(id: number) {
    try {
        const response = await api.get("Jogo/" + id);

        const jogo = {
            ...response.data,
            imagemUrl: `${api.defaults.baseURL}${response.data.imagemUrl}`
        };

        return jogo;

    } catch (error: any) {
        throw new Error(error.response.data)
    }
}

export async function excluirJogo(jogoId: number) {
    try {
        await api.delete("Jogo/" + jogoId)
    } catch (error: any) {
        throw new Error(error.response.data)
    }
}

export async function editarJogo(jogoId: number, dados: JogoFormulario) {
    try {
        const formData = new FormData();

        formData.append("nome", dados.nome);
        formData.append("descricao", dados.descricao);
        formData.append("preco", dados.preco);
        formData.append("plataforma", dados.plataforma);
        if (dados.imagem) {
            formData.append("imagem", dados.imagem);
        }
        dados.generoId.forEach((id) => {
            formData.append("generoIds", id.toString());
        })
        dados.classificacaoId.forEach((id) => {
            formData.append("classificacaoIds", id.toString());
        })

        await api.put("Jogo/" + jogoId, formData)

    } catch (error: any) {
        throw new Error(error.response.data);
    }
}