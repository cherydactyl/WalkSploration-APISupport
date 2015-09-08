
//function geoFindMe() {
//    var outputLat = document.getElementById("outLan");
//    var outputLat = document.getElementById("outLon");

//    function success(position) {
//        var latitude = position.coords.latitude;
//        var longitude = position.coords.longitude;

//        outputLat.innerHTML = '<p>Latitude is ' + latitude + '°</p>';
//        outputLon.innerHTML = '<p>Longitude is ' + longitude + '°</p>';
//    };

//    function error() {
//        output.innerHTML = "Unable to retrieve your location";
//    };

//    navigator.geolocation.getCurrentPosition(success, error);
//}



//function success(position) {
//    var latitude = position.coords.latitude;
//    var longitude = position.coords.longitude;
//    output.innerHTML = '<p>Latitude is ' + latitude + '° <br>Longitude is ' + longitude + '°</p>';
//    var img = new Image();
//    img.src = "https://maps.googleapis.com/maps/api/staticmap?center=" + latitude + "," + longitude + "&zoom=13&size=300x300&sensor=false";
//    output.appendChild(img);
//};






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

        outputLat.innerHTML = "<p>Latitude is " + latitude + "°</p>";
        outputLon.innerHTML = "<p>Longitude is " + longitude + "°</p>";

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