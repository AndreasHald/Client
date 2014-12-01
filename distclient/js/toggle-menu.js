
    function toggle() {
        if (document.getElementById("menu-side").style.width == "0%") {
            document.getElementById("menu-side").style.width = "20%";
            document.getElementById("wrap").style.visibility = "visible";
            document.getElementById("wrap").style.transitionDelay = "0.8s";
        }
        else {
            document.getElementById("menu-side").style.width = "0%";
            document.getElementById("wrap").style.visibility = "hidden";
            document.getElementById("wrap").style.transitionDelay = "0s";
        }
    }
