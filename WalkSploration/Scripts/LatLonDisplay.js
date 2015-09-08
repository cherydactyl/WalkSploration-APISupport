function geoFindMe() {
    var outputLat = document.getElementById("outLat");
    var outputLon = document.getElementById("outLon");

    if (!navigator.geolocation) {
        output.innerHTML = "<p>Geolocation is not supported by your browser</p>";
        return;
    }

    function success(position) {
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;

        outputLat.innerHTML = latitude;
        outputLon.innerHTML = longitude;

        document.getElementById("startLatitude").value = lattitude;
        document.getElementById("startLongitude").value = longitude;
    };

    function error() {
        outputLat.innerHTML = "Unable to retrieve your location";
        outputLon.innerHTML = " ";
    };

    outputLat.innerHTML = "<p>Locating…</p>";

    navigator.geolocation.getCurrentPosition(success, error);
    return new {
        latitude: outputLat,
        longitude: outputLon
    }
}

function setFormLat() {
    document.getElementById("startLatitude").value = loc.latitude;
}

function setFormLon() {
    document.getElementById("startLongitude").value = loc.longitude;
}