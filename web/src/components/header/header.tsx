import Link from "next/link";
import styles from "./header.module.css";

const Header = () => {
    return (
        <header id={styles.header}>
            <div id={styles.container}>
                <img src="../imgs/logo-header.png" alt="" id={styles.logo} />
                <div id={styles.contatos}>
                    <Link href="../home#catalogo" id={styles.botao}>Catálogo</Link>
                    <Link href="../login" id={styles.botao}> Login</Link>
                </div>
            </div>
        </header>
    )
}

export default Header;