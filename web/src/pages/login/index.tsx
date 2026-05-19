import { useState } from "react";
import styles from "./login.module.css";
import { login } from "../api/authService";
import { useRouter } from "next/navigation";
import { ToastContainer, toast } from 'react-toastify';

const Login = () => {

    const [email, setEmail] = useState<string>("");
    const [senha, setSenha] = useState<string>("");

    const router = useRouter();
    const notificacao = (msg: string) => toast.success(msg);
    const erro = (msg: string) => toast.error(msg);

    async function autenticar(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        try {
            await login(email, senha);
            notificacao("Login bem sucedido!")

            //espera 2 segundos para redirecionar para a login
            setTimeout(() => {
                router.push("/home");
            }, 2000); // 2 segundos

        } catch (error: any) {
            erro(error.message);
        }
    }

    return (
        <>
            <ToastContainer />
            <main className="layout_guide" id={styles.main}>
                <section id={styles.esquerda}>
                    <figure id={styles.fig1}>
                        <img src="../imgs/mulher-login.png" alt="Imagem de personagem feminina com temática cyberpunk à esquerda do formulário de login" />
                    </figure>
                </section>
                <section id={styles.direita}>
                    <figure id={styles.fig2}>
                        <img src="../imgs/logo-header.png" alt="Imagem da logo do Royal Games acima dos campos de login" />
                    </figure>
                    <form id={styles.form} onSubmit={autenticar}>
                        <div>
                            <label htmlFor="">E-mail</label>
                            <input className={styles.input} type="text" name="email" placeholder="email@exemplo.com" required
                                value={email} onChange={(e) => setEmail(e.target.value)} />
                        </div>
                        <div id="ajuste">
                            <label htmlFor="">Senha</label>
                            <input className={styles.input} type="password" name="senha" placeholder="*******" required
                                value={senha} onChange={(e) => setSenha(e.target.value)} />
                        </div>
                        <button type="submit">Entrar</button>
                    </form>
                </section>
            </main>
        </>
    )
}

export default Login;