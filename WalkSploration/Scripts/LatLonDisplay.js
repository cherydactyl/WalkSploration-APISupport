
function geoFindMe() {
    var outputLon = document.getElementById("lngbox");  // Set to the value of the object with the id "outLon"
    var outputLat = document.getElementById("latbox");  // Set to the value of the object with the id "outLat"

    if (!navigator.geolocation) {   // If geolocation isn't available, then print the following
        output.innerHTML = "<p>Geolocation is not supported by your browser</p>";
        return;
    }

    function success(position) {  // takes in var position that was defined in Views > Shared > _Layout.cshtml
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;

        outputLat.innerHTML = "<p>Latitude is " + latitude + "°</p>";
        outputLon.innerHTML = "<p>Longitude is " + longitude + "°</p>";
    };

    function error() {
        outputLat.innerHTML = "Unable to retrieve your location";
        outputLon.innerHTML = " ";
    };

    outputLat.innerHTML = "<p>Locating…</p>";

    navigator.geolocation.getCurrentPosition(success, error);
}
