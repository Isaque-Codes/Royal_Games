import styles from "./cadastro.module.css"
import Footer from "@/components/footer/footer";
import Header from "@/components/header/header";
import CardCadastro from "@/components/card-cadastro/card-cadastro";

const Cadastro = () => {
    return (
        <>
            <Header />
            <main id={styles.main}>
                {/* SECAO CADASTRO */}
                <section id={styles.cadastro} className="layout_guide">
                    <h1 id={styles.titulo_cadastro}>Cadastrar novo jogo</h1>
                    <form id={styles.form} action="">
                        <div id={styles.cadastro_esquerda}>
                            <div id={styles.nome} className={styles.div_form}>
                                <label htmlFor="">Nome</label>
                                <input type="text" />
                            </div>
                            <div id={styles.esquerda_meio}>
                                <div id={styles.valor} className={styles.div_form}>
                                    <label htmlFor="">Valor</label>
                                    <input type="number" />
                                </div>
                                <div id={styles.genero} className={styles.div_form}>
                                    <label htmlFor="">Gênero</label>
                                    <input type="text" />
                                </div>
                                <div id={styles.class_indic} className={styles.div_form}>
                                    <label htmlFor="">Classificação Indicativa</label>
                                    <input type="text" />
                                </div>
                            </div>
                            <div id={styles.esquerda_baixo}>
                                <div id={styles.plataforma} className={styles.div_form}>
                                    <label htmlFor="">Plataforma</label>
                                    <input type="text" />
                                </div>
                                <div id={styles.imagem} className={styles.div_form}>
                                    <label htmlFor="">Imagem</label>
                                    <input type="text" />
                                </div>
                            </div>
                        </div>
                        <div id={styles.cadastro_direita} className={styles.div_form}>
                            <label htmlFor="">Descrição</label>
                            <input type="text" />
                        </div>
                    </form>
                    <button id={styles.btn_cadastro}>Cadastrar</button>
                </section>

                {/* SECAO LISTA JOGOS */}

                <h2 id={styles.titulo_lista}>Lista de jogos</h2>
                <div id={styles.pesquisa}>
                    <input type="text" />
                    <button>Menor Preço</button>
                    <button>Categoria</button>
                </div>
            </main>

            <Footer />
        </>
    )
}

export default Cadastro;