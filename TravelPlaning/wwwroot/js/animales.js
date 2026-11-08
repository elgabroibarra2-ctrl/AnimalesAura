document.addEventListener("DOMContentLoaded", function () {
    // Seleccionamos los botones y todas las tarjetas de animales
    const btnTodos = document.getElementById("btn-todos");
    const btnPerritos = document.getElementById("btn-perritos");
    const btnGatitos = document.getElementById("btn-gatitos");
    const tarjetasAnimales = document.querySelectorAll(".animal");

    // Función que hace el trabajo de filtrar
    function filtrarAnimales(tipoBusqueda) {
        tarjetasAnimales.forEach(tarjeta => {
            const tipoAnimal = tarjeta.getAttribute("data-tipo");

            if (tipoBusqueda === "todos" || tipoAnimal === tipoBusqueda) {
                tarjeta.style.display = "block"; // Muestra la tarjeta
            } else {
                tarjeta.style.display = "none"; // Oculta la tarjeta
            }
        });
    }

    // Asignamos la función a los clics de los botones
    btnTodos.addEventListener("click", () => filtrarAnimales("todos"));
    btnPerritos.addEventListener("click", () => filtrarAnimales("perrito"));
    btnGatitos.addEventListener("click", () => filtrarAnimales("gatito"));
});