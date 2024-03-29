﻿function playSound() {
    // darkmode
    $("#light-background").css({
        opacity: 0,
        display: "block"
    }).stop().animate({
            opacity: 0.95
        },
        430);


    var player = new YT.Player("player",
        {
            videoId: "6i5hho2aD-E",
            events: {
                'onReady': onPlayerReady,
                'onStateChange': onPlayerStateChange
            },
            playerVars: {
                controls: 0,
                disablekb: 1,
                fs: 0,
                modestbranding: 1,
                showinfo: 0
            }
        });

    function onPlayerReady(event) {
        $("#jarvis").css({ opacity: 0, display: "block" }).stop().animate({ opacity: 1, zIndex: 10000 }, 100);
        $("#jarvis2").css({ zIndex: 10000 });
        event.target.playVideo();
    }

    var done = false;

    function onPlayerStateChange(event) {
        if (event.data == YT.PlayerState.PLAYING && !done) {
            setTimeout(stopVideo, 19000);
            done = true;
        }
    }

    function stopVideo() {
        player.stopVideo();
        $("#light-background").stop().fadeOut(400);
        $("#jarvis").stop().fadeOut(400);
        $("#player").remove();
        $("#jarvis").append("<div id='player'></div>");
        $("#jarvis2").css({ zIndex: -1 });
    }

}