let tiempo = 5;//1500; //25 min en segundos
let intervalo = null;
let modoActual = "pomodoro";
const alarma = new Audio("notificacion.mp3");

function actualizarReloj(){
    let minutos = Math.floor(tiempo/60);
    let segundos = tiempo % 60;

    document.getElementById("reloj").innerText = (minutos < 10 ? "0":"") + minutos + ":" + (segundos< 10 ? "0": "") + segundos;
}

function iniciar(){
    if (intervalo) return;

    // activar audio (hack para desbloquear)
    alarma.play().then(() => {
        alarma.pause();
        alarma.currentTime = 0;
    }).catch(()=>{});

    intervalo = setInterval(() => {
        if(tiempo > 0){
            tiempo--;
            actualizarReloj();
        } else {
            clearInterval(intervalo);
            intervalo = null;

            alarma.currentTime = 0;
            alarma.play();

            cambiarModoAutomatico();
        }
    },1000);
}

function pausar(){
    clearInterval(intervalo);
    intervalo = null;
}

function reiniciar(){
    pausar();
    modoPomodoro();
}

//Inicializar
actualizarReloj();

function modoPomodoro(){
    pausar();
    tiempo = 5;//1500;

    actualizarReloj();
    modoActual = "pomodoro";
    document.getElementById("modoTexto").innerText = "Pomodoro";

    let menu = document.querySelector(".menu");
    menu.classList.remove("corto", "largo");
    menu.classList.add("pomodoro");
}

function modoCorto(){
    pausar();
    tiempo= 5//300;

    actualizarReloj();
    modoActual = "corto";
    document.getElementById("modoTexto").innerText = "Descanso corto";
    
    let menu = document.querySelector(".menu");
    menu.classList.remove("pomodoro", "largo");
    menu.classList.add("corto");
}

function modoLargo(){
    pausar();
    tiempo = 900;
    actualizarReloj();
    modoActual = "largo";
    let menu = document.querySelector(".menu");
    menu.classList.remove("pomodoro", "corto");
    menu.classList.add("largo");
}

function crearBloques() {
    const contenedor = document.querySelector(".tetris-bg");

    for (let i = 0; i < 40; i++) {
        let bloque = document.createElement("span");

        bloque.style.left = Math.random() * 100 + "vw";
        bloque.style.animationDuration = (Math.random() * 3 + 2) + "s";
        bloque.style.backgroundColor = coloresRandom();

        contenedor.appendChild(bloque);
    }
}

function coloresRandom() {
    const colores = ["#00ffff", "#ff00ff", "#ffff00", "#00ff00", "#ff4d4d"];
    return colores[Math.floor(Math.random() * colores.length)];
}

document.addEventListener("DOMContentLoaded", crearBloques);

function cambiarModoAutomatico() {
    if (modoActual === "pomodoro") {
        modoCorto();
    } else {
        modoPomodoro();
    }
    iniciar();
}