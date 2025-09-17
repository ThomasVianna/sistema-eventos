async function carregarEventos() {
    const response = await fetch('http://localhost:8099/api/evento');
    const eventos = await response.json();
    const container = document.getElementById('eventos');
    container.innerHTML = '';
    eventos.forEach(e => {
        const div = document.createElement('div');
        div.className = 'evento';
        const data = new Date(e.dataHora);
        div.innerHTML = `
            <h3>${e.titulo}</h3>
            <p><strong>Descrição:</strong> ${e.descricao}</p>
            <p><strong>Data/Hora:</strong> ${data.toLocaleString('pt-BR')}</p>
            <p><strong>Palestrante:</strong> ${e.palestrante}</p>
            <p><strong>Vagas:</strong> ${e.vagas}</p>
        `;
        container.appendChild(div);
    });
}

async function criarEvento(e) {
    e.preventDefault();
    const titulo = document.getElementById('titulo').value;
    const descricao = document.getElementById('descricao').value;
    const dataHora = document.getElementById('dataHora').value;
    const palestrante = document.getElementById('palestrante').value;
    const vagas = document.getElementById('vagas').value;

    await fetch('http://localhost:8099/api/evento', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            titulo,
            descricao,
            dataHora,
            palestrante,
            vagas: parseInt(vagas)
        })
    });

    document.getElementById('formEvento').reset();
    carregarEventos();
}

document.addEventListener('DOMContentLoaded', () => {
    carregarEventos();
    document.getElementById('formEvento').addEventListener('submit', criarEvento);
});
