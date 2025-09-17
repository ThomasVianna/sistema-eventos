async function carregarEventos() {
    const response = await fetch('http://localhost:8099/api/evento');
    const eventos = await response.json();
    const container = document.getElementById('eventos');
    container.innerHTML = '';
    eventos.forEach(e => {
        const div = document.createElement('div');
        div.className = 'evento';
        div.innerHTML = `<h3>${e.titulo}</h3><p>${e.descricao}</p><p>${e.dataHora}</p>`;
        container.appendChild(div);
    });
}

carregarEventos();
