const form = document.getElementById('formEvento');
const eventosDiv = document.getElementById('eventos');
const submitBtn = document.getElementById('submitBtn');
let isSubmitting = false;

// Função para renderizar eventos
function renderEventos(eventos) {
    eventosDiv.innerHTML = '';
    if (!eventos.length) {
        eventosDiv.innerHTML = '<p class="text-center">Nenhum evento cadastrado.</p>';
        return;
    }
    eventos.forEach(ev => {
        const card = document.createElement('div');
        card.className = 'evento-card';
        card.innerHTML = `
            <h2>${ev.titulo}</h2>
            <p><strong>Descrição:</strong> ${ev.descricao}</p>
            <p><strong>Data e Hora:</strong> ${new Date(ev.dataHora).toLocaleString('pt-BR', { dateStyle: 'medium', timeStyle: 'short' })}</p>
            <p><strong>Palestrante:</strong> ${ev.palestrante}</p>
            <p><strong>Vagas:</strong> ${ev.vagas}</p>
            <button class="delete-btn" aria-label="Deletar evento ${ev.titulo}" onclick="deletarEvento(${ev.id})">Deletar</button>
        `;
        eventosDiv.appendChild(card);
    });
}

// Buscar eventos da API
async function buscarEventos() {
    try {
        eventosDiv.innerHTML = '<p class="text-center">Carregando eventos...</p>';
        const resp = await fetch('http://localhost:8099/eventos');
        if (!resp.ok) throw new Error(`Erro ${resp.status}: Não foi possível buscar eventos`);
        const eventos = await resp.json();
        renderEventos(eventos);
    } catch (e) {
        eventosDiv.innerHTML = `<p class="text-center" style="color: #ff4d4d;">Erro: ${e.message}</p>`;
    }
}

// Enviar novo evento para a API
form.addEventListener('submit', async (e) => {
    e.preventDefault();
    if (isSubmitting) return;

    isSubmitting = true;
    submitBtn.setAttribute('aria-busy', 'true');
    submitBtn.querySelector('.button-text').classList.add('sr-only');
    submitBtn.querySelector('.loading-spinner').classList.remove('sr-only');

    const evento = {
        titulo: form.titulo.value.trim(),
        descricao: form.descricao.value.trim(),
        dataHora: form.dataHora.value,
        palestrante: form.palestrante.value.trim(),
        vagas: Number(form.vagas.value)
    };

    // Validação adicional
    if (evento.titulo.length < 3) {
        document.getElementById('titulo-error').textContent = 'O título deve ter pelo menos 3 caracteres.';
        document.getElementById('titulo-error').classList.remove('sr-only');
        resetSubmitButton();
        return;
    }
    if (new Date(evento.dataHora) < new Date()) {
        document.getElementById('dataHora-error').textContent = 'A data do evento deve ser futura.';
        document.getElementById('dataHora-error').classList.remove('sr-only');
        resetSubmitButton();
        return;
    }

    try {
        const resp = await fetch('http://localhost:8099/eventos', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(evento)
        });
        if (!resp.ok) throw new Error(`Erro ${resp.status}: Não foi possível criar o evento`);
        form.reset();
        clearErrors();
        buscarEventos();
    } catch (e) {
        alert(`Erro: ${e.message}`);
    } finally {
        resetSubmitButton();
    }
});

// Função para deletar evento
async function deletarEvento(id) {
    if (!confirm('Tem certeza que deseja deletar este evento?')) return;
    try {
        const resp = await fetch(`http://localhost:8099/eventos/${id}`, {
            method: 'DELETE'
        });
        if (!resp.ok) throw new Error(`Erro ${resp.status}: Não foi possível deletar o evento`);
        buscarEventos();
    } catch (e) {
        alert(`Erro: ${e.message}`);
    }
}

// Limpar erros de validação
function clearErrors() {
    ['titulo', 'descricao', 'dataHora', 'palestrante', 'vagas'].forEach(field => {
        const errorElement = document.getElementById(`${field}-error`);
        errorElement.textContent = '';
        errorElement.classList.add('sr-only');
    });
}

// Resetar botão de submit
function resetSubmitButton() {
    isSubmitting = false;
    submitBtn.setAttribute('aria-busy', 'false');
    submitBtn.querySelector('.button-text').classList.remove('sr-only');
    submitBtn.querySelector('.loading-spinner').classList.add('sr-only');
}

// Inicializar
buscarEventos();