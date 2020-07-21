var soundFile = document.createElement("audio");
soundFile.preload = "auto";
var src = document.createElement("source");
src.src = "../sound/welcome.mp3";
soundFile.appendChild(src);

soundFile.load();
soundFile.volume = 0.0;
soundFile.play();

function playSound() {
    soundFile.currentTime = 0.00;
    soundFile.volume = 1;
    soundFile.play();
}

