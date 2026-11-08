document.addEventListener("DOMContentLoaded", function () {
    // Seleccionamos todas las etiquetas <details> de la página
    const todasLasPreguntas = document.querySelectorAll("details");

    todasLasPreguntas.forEach((pregunta) => {
        // Escuchamos cada vez que una pregunta se abre o cierra
        pregunta.addEventListener("toggle", function () {

            // Si la pregunta actual se está abriendo...
            if (pregunta.open) {
                // Recorremos todas las demás preguntas
                todasLasPreguntas.forEach((otraPregunta) => {
                    // Si la otra pregunta no es la que acabamos de abrir, la cerramos
                    if (otraPregunta !== pregunta) {
                        otraPregunta.removeAttribute("open");
                    }
                });
            }
        });
    });
});