import styles from "./login.module.css"

const Login = () => {
    return (
        <>
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
                    <form id={styles.form} action="">
                        <div>
                            <label htmlFor="">E-mail</label>
                            <input className={styles.input} type="email" />
                        </div>
                        <div id="ajuste">
                            <label htmlFor="">Senha</label>
                            <input className={styles.input} type="password" />
                        </div>
                        <button>Entrar</button>
                    </form>
                </section>
            </main>
        </>
    )
}

export default Login;