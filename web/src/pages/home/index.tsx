import Footer from "@/components/footer/footer";
import Header from "@/components/header/header";
import styles from "./home.module.css";
import ListaJogo from "@/components/lista-jogo/lista-jogo";

const Home = () => {
    return (
        <>
            <Header />
            <main id={styles.home}>
                <div className={styles.banner}>
                    <div className={styles.texto_banner}>
                        <p className={styles.titulo}>Conheça nossos jogos!</p>
                        <p className={styles.texto}>
                            Navegue por títulos de todas as gerações, descubra plataformas,
                            gêneros e detalhes completos antes de escolher sua próxima aventura.
                            Seu próximo jogo favorito começa aqui.
                        </p>
                    </div>
                    <img src="../imgs/cyberpunk.png" alt="" id={styles.imagem_banner} />
                </div>
                <div id={styles.catalogo}>
                    <p className={styles.titulo}>Catálogo de Jogos</p>
                    <hr id={styles.linha}></hr>
                    <ListaJogo />
                </div>
            </main>
            <Footer />
        </>
    )
}

export default Home;