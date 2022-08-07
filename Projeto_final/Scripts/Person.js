

function person_add() {
    let cod = document.getElementById("codigo").value
    let cpf = document.getElementById("cpf").value
    let name = document.getElementById("nome").value
    let tel = document.getElementById("telefone").value
    cpf = cpf.slice(0,4)

  
    if ((cpf.length & name.length) > 0) {
        alert("Pessoa cadastrada com sucesso Codigo:" + cod + "/" + cpf)
    }
}
    