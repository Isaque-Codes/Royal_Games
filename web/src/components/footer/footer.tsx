import styles from "./footer.module.css";

const Footer = () => {
    return (
        <footer id={styles.footer}>
            <div id={styles.itens_footer}>
                <img src="../imgs/logo-footer.png" alt="" id={styles.logo_footer} />
            </div>
            <div id={styles.contatos}>
                <p id={styles.contato}>royalgames@gmail.com</p>
                <p id={styles.contato}>(11) 99999-9999</p>
                <p id={styles.contato}>@RoyalGames</p>
            </div>
        </footer>
    )
}

export default Footer;