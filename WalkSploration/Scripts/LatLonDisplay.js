
//function geoFindMe() {
//    var outputLat = document.getElementById("outLat");
//    var outputLon = document.getElementById("outLon");

//    if (!navigator.geolocation) {
//        output.innerHTML = "<p>Geolocation is not supported by your browser</p>";
//        return;
//    }

//    function success(position) {
//        var latitude = position.coords.latitude;
//        var longitude = position.coords.longitude;

//        outputLat.innerHTML = "<p>Latitude is " + latitude + "°</p>";
//        outputLon.innerHTML = "<p>Longitude is " + longitude + "°</p>";
//    };

//    function error() {
//        outputLat.innerHTML = "Unable to retrieve your location";
//        outputLon.innerHTML = " ";
//    };

//    outputLat.innerHTML = "<p>Locating…</p>";

//    navigator.geolocation.getCurrentPosition(success, error);
//}