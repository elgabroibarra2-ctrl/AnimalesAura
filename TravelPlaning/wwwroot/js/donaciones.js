document.addEventListener("DOMContentLoaded", function () {
    const formDonacion = document.getElementById("form-donacion");
    const mensajeError = document.getElementById("error-donacion");
    const areaConfirmacion = document.getElementById("confirmacion-resumen");
    const resumenTexto = document.getElementById("resumen-texto");

    formDonacion.addEventListener("submit", function (evento) {
        // Prevenimos el envío real al servidor según lo indicado en la rúbrica
        evento.preventDefault();

        // 1. Selección y lectura de datos mediante el DOM
        const inputNombre = document.getElementById("nombre").value.trim();
        const selectMonto = document.getElementById("monto").value;

        // 2. Validación básica
        if (inputNombre === "" || selectMonto === "") {
            mensajeError.style.display = "block";
            areaConfirmacion.style.display = "none";
            return;
        }

        mensajeError.style.display = "none";

        // 3. Construcción del Objeto JavaScript requerido por la rúbrica
        const donacionUsuario = {
            donante: inputNombre,
            montoDonado: parseFloat(selectMonto),
            moneda: "MXN",
            fechaRegistro: new Date().toLocaleString(),
            idTransaccion: "DON-" + Math.floor(Math.random() * 1000000)
        };

        // Imprimimos el objeto en la consola del navegador para comprobación técnica
        console.log("Objeto JavaScript generado:", donacionUsuario);

        // 4. Cambios observables en la interfaz (DOM)
        resumenTexto.innerHTML = `
            <strong>ID Transacción:</strong> ${donacionUsuario.idTransaccion}<br />
            <strong>Donante:</strong> ${donacionUsuario.donante}<br />
            <strong>Monto:</strong> $${donacionUsuario.montoDonado} ${donacionUsuario.moneda}<br />
            <strong>Fecha:</strong> ${donacionUsuario.fechaRegistro}
        `;

        areaConfirmacion.style.display = "block";
        formDonacion.reset();
    });
});