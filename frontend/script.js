const form = document.getElementById('formEvento');
const eventosDiv = document.getElementById('eventos');

// Função para renderizar eventos
function renderEventos(eventos) {
    eventosDiv.innerHTML = '';
    if (!eventos.length) {
        eventosDiv.innerHTML = '<p>Nenhum evento cadastrado.</p>';
        return;
    }
    eventos.forEach(ev => {
        const card = document.createElement('div');
        card.className = 'evento-card';
        card.innerHTML = `
            <h2>${ev.titulo}</h2>
            <p><strong>Descrição:</strong> ${ev.descricao}</p>
            <p><strong>Data e Hora:</strong> ${new Date(ev.dataHora).toLocaleString('pt-BR')}</p>
            <p><strong>Palestrante:</strong> ${ev.palestrante}</p>
            <p><strong>Vagas:</strong> ${ev.vagas}</p>
        `;
        eventosDiv.appendChild(card);
    });
}

// Buscar eventos da API
async function buscarEventos() {
    try {
        const resp = await fetch('http://localhost:8099/eventos');
        if (!resp.ok) throw new Error('Erro ao buscar eventos');
        const eventos = await resp.json();
        renderEventos(eventos);
    } catch (e) {
        eventosDiv.innerHTML = '<p style="color:red;">Erro ao carregar eventos.</p>';
    }
}

// Enviar novo evento para a API
form.addEventListener('submit', async (e) => {
    e.preventDefault();
    const evento = {
        titulo: form.titulo.value.trim(),
        descricao: form.descricao.value.trim(),
        dataHora: form.dataHora.value,
        palestrante: form.palestrante.value.trim(),
        vagas: Number(form.vagas.value)
    };
    try {
        const resp = await fetch('http://localhost:8099/eventos', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(evento)
        });
        if (!resp.ok) throw new Error('Erro ao criar evento');
        form.reset();
        buscarEventos();
    } catch (e) {
        alert('Erro ao criar evento. Verifique os dados e tente novamente.');
    }
});

// Inicializar
buscarEventos();
