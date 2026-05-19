import secureLocalStorage from "react-secure-storage";

export function verificarAutenticacao() {
    const token = secureLocalStorage.getItem("Token");

    return !!token;
    //token passa a ser booleano
    //se existir info dentro do token retorna true
}