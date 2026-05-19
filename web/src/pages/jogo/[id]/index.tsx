import Footer from "@/components/footer/footer";
import Header from "@/components/header/header"
import styles from "./jogo.module.css"
import { useEffect, useState } from "react";
import { listarGenero } from "../../api/generoService";
import { cadastrarJogo, editarJogo, listarPorId } from "../../api/jogoService";
import { erro, notificacao } from "@/utils/toast";
import Toast from "@/components/toast/toast";
import { useParams } from "next/navigation";
import { useRouter } from "next/router";
import { verificarAutenticacao } from "@/utils/auth";

interface Genero {
    generoID: number,
    nome: string
}

const Jogo = () => {

    const [generos, setGeneros] = useState<Genero[]>([]);
    const [nome, setNome] = useState<string>("");
    const [descricao, setDescricao] = useState<string>("");
    const [preco, setPreco] = useState<string>("");
    const [imagem, setImagem] = useState<File | null>(null);
    const [estaAutenticado, setEstaAutenticado] = useState(false)
    const router = useRouter();
    const id = router.query.id;


    /* useEffect(() => {
       if(!verificarAutenticacao()){
         router.push("/home")
         return;
       }else{
         setEstaAutenticado(true)
       }
       
       if(!router.isReady) return;
       listarGeneroEmJogo();
   
       if(id){
       carregarInformacoes();
      }
     }, [])
   
     if(!estaAutenticado){
       return null;
     }*/

    return (
        <>
            <Header />
            <Toast />
            <main id={styles.main_jogo}>
                <div id={styles.detalhesJogo}></div>
                <h1 className={styles.titulo}>Detalhes do Jogo</h1>
                <hr />
                <img src="" alt="imagem do jogo" />
                <h2 className={styles.nomeJogo}></h2>
            </main>
            <Footer />
        </>
    )
}

export default Jogo;