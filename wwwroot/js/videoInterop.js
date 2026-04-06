window.diamondVideo = {
    seekTo: function (elementId, seconds) {
        const video = document.getElementById(elementId);

        if (!video) {
            return;
        }

        const target = Math.max(0, Number(seconds) || 0);

        if (video.readyState >= 1) {
            video.currentTime = target;
            return;
        }

        const onLoaded = () => {
            video.currentTime = target;
            video.removeEventListener("loadedmetadata", onLoaded);
        };

        video.addEventListener("loadedmetadata", onLoaded);
    }
};