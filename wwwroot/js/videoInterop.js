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
    },

    play: function (elementId) {
        const video = document.getElementById(elementId);

        if (!video) {
            return;
        }

        video.play();
    },

    pause: function (elementId) {
        const video = document.getElementById(elementId);

        if (!video) {
            return;
        }

        video.pause();
    }
};

window.diamondPose = {
    clearCanvas: function (canvasId) {
        const canvas = document.getElementById(canvasId);
        if (!canvas) return;

        const ctx = canvas.getContext("2d");
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    },

    drawMarkers: function (canvasId, markers) {
        const canvas = document.getElementById(canvasId);
        if (!canvas) return;

        const ctx = canvas.getContext("2d");
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        const map = {};
        for (const marker of markers) {
            map[marker.key] = marker;
        }

        const lines = [
            ["rear_shoulder", "lead_shoulder"],
            ["rear_hip", "lead_hip"],
            ["rear_shoulder", "rear_hip"],
            ["lead_shoulder", "lead_hip"],
            ["lead_hip", "lead_knee"],
            ["rear_hip", "rear_knee"],
            ["head", "hands"]
        ];

        ctx.lineWidth = 2;
        ctx.strokeStyle = "rgba(78, 161, 255, 0.85)";
        ctx.fillStyle = "rgba(78, 161, 255, 0.95)";
        ctx.font = "12px Arial";

        for (const [a, b] of lines) {
            if (map[a] && map[b]) {
                ctx.beginPath();
                ctx.moveTo(map[a].x, map[a].y);
                ctx.lineTo(map[b].x, map[b].y);
                ctx.stroke();
            }
        }

        for (const marker of markers) {
            ctx.beginPath();
            ctx.arc(marker.x, marker.y, 6, 0, Math.PI * 2);
            ctx.fill();

            ctx.fillStyle = "#ffffff";
            ctx.fillText(marker.label, marker.x + 10, marker.y - 10);
            ctx.fillStyle = "rgba(78, 161, 255, 0.95)";
        }
    }
};