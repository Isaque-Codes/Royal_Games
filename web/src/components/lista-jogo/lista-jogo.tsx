import styles from "./lista-jogo.module.css";
import Link from "next/link";
import Jogo from "@/pages/jogo/[id]";
import { useEffect, useState } from "react";
import { excluirJogo, listarJogo } from "@/pages/api/jogoService";
import { erro, notificacao, toastConfirmarExclusao } from "@/utils/toast";
import { verificarAutenticacao } from "@/utils/auth";
import CardProduto from "../card-produto/card-produto";

interface Jogo {
    jogoID: number,
    nome: string,
    preco: number,
    descricao: string,
    categoria: string,
    imagemUrl: string,
    statusJogo: boolean
}

const ListaJogo = () => {

    const [jogos, setJogos] = useState<Jogo[]>([]);

    const [ordem, setOrdem] = useState("todos");
    //salvar o que for escrito pelo usuário
    const [pesquisa, setPesquisa] = useState("");
    //salva a info do usuário logado
    const [estaAutenticado, setEstaAutenticado] = useState(false);

    async function listar() {
        try {
            const lista = await listarJogo();
            setJogos(lista);
        } catch (error: any) {
            console.log(error.message)
        }
    }

    function confirmarExclusao(jogoId: number) {
        toastConfirmarExclusao(async () => {
            try {
                await excluirJogo(jogoId);

                setJogos((listaAtual) =>
                    listaAtual.map((jogo) =>
                        jogo.jogoID === jogoId
                            ? { ...jogo, statusJogo: false }
                            : jogo
                    )
                )

                notificacao("Jogo inativado!")
                listar();
            } catch (error: any) {
                erro(error.message)
            }
        })
    }

    useEffect(() => {
        setEstaAutenticado(verificarAutenticacao());
        listar();
    }, [])

    const jogosFiltrados = jogos.filter((jogo) =>
        jogo.nome.toLowerCase().includes(pesquisa.toLowerCase()))
        .sort((a, b) => {
            if (ordem === "menor_valor") {
                return a.preco - b.preco
            } else if (ordem === "maior_valor") {
                return b.preco - a.preco
            }
            return a.jogoID - b.jogoID;
        });

    return (
        <>
            <div id={styles.botoes_home}>
                <div>
                    <input type="text" name="pesquisa" id={styles.barra_pesquisa} placeholder="Pesquise..." value={pesquisa} onChange={(e) => { setPesquisa(e.target.value) }} />
                </div>
                <select className={styles.botao_filtrar} value={ordem} onChange={(e) => setOrdem(e.target.value)}>
                    Filtrar
                    <option value="menor_valor">menor valor</option>
                    <option value="maior_valor">maior valor</option>
                </select>
                <select name="categorias" id={styles.botao_categorias} className={styles.botao_filtrar}>
                    <option value="categoria">categoria</option>
                </select>

                {estaAutenticado && (
                    <div id={styles.botoes_edicao}>
                        <button className={styles.botao}>Excluir</button>
                        <Link className={styles.botao} href="/jogo">Editar</Link>
                    </div>)}
            </div>
            <div id={styles.cards_jogo}>
                {jogosFiltrados.length > 0 ? jogosFiltrados.map((item) => (
                    <CardProduto
                        key={item.jogoID}
                        jogoID={item.jogoID}
                        titulo={item.nome}
                        descricao={item.descricao}
                        preco={item.preco}
                        img={item.imagemUrl}
                        categoria={item.categoria}
                        onDelete={confirmarExclusao}
                        estaLogado={estaAutenticado}
                    />
                )) : (
                    <p>Carregando jogos...</p>
                )}
            </div>
            {estaAutenticado && (
                <div id={styles.listar_jogos}>
                    <button className={styles.seta}>
                        <img src="../seta-esquerda.png" alt="" />
                    </button>
                    <button className={styles.botao_lista}>1</button>
                    <button className={styles.botao_lista}>2</button>
                    <button className={styles.botao_lista}>3</button>
                    <button className={styles.botao_lista}>4</button>
                    <button className={styles.botao_lista}>5</button>
                    <button className={styles.seta}>
                        <img src="../seta-direita.png" alt="" />
                    </button>
                </div>)}
        </>
    )
}

export default ListaJogo;