import Link from "next/link";
import styles from "./card-produto.module.css";
import { formatarPreco } from "@/utils/formatacao";
type Jogo = {
    titulo: string,
    descricao: string,
    categoria: string,
    img: string,
    preco: number,
    jogoID: number,
    // Props que recebe função
    onDelete: (jogoId: number) => void,
    estaLogado: boolean
}

const CardCadastro = ({ titulo, descricao, img, preco, jogoID, onDelete, estaLogado }: Jogo) => {
    return (
        <article className={styles.card_jogo}>
            <Link href={"/detalhe-jogo/" + jogoID}>
                <img src={img} alt="Jogo vendido pela loja."
                    className={styles.img_jogo} />
            </Link>
            <h3 className={styles.titulo_jogo}>{titulo}</h3>
            <p className={styles.desc_jogo}>{descricao}</p>
            <div className={styles.campo_itens}>
                <p className={styles.valor_jogo}>{formatarPreco(preco)}</p>
                {estaLogado && (<>
                    <button onClick={() => onDelete(jogoID)} id={styles.botao_excluir}>
                        Excluir
                    </button>
                    <Link href="" id={styles.botao_excluir}>
                        Editar
                    </Link>
                </>
                )}
            </div>
        </article>
    )
}

export default CardCadastro;