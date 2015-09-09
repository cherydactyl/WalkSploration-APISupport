function geoFindMe() {
    // Initializes Global Variables - (Because they're outside of a function)
var map;                                        // the actual map image to display
var geocoder = new google.maps.Geocoder();      // the function that will take an address and return geocoordinates     - 9.5 update, we are not currently using this
var position;                                   // creates the position variable                                        - Will hold the lat and lon
var image = {                                   // Creates custom Map Pin Image and location relative to info window
    url: "/Images/sneakerMarker.png",                   // url = the location in our file where the image is stored
    anchor: new google.maps.Point(20, 15)               // anchor = this point is relative to where the actual center is of the lat and lon
};
var marker;                                     // Initializes marker object (Our shoe)
var infowindow;

var outputLat = document.getElementById("outLat");
var outputLon = document.getElementById("outLon");

    if (!navigator.geolocation) {
        output.innerHTML = "<p>Geolocation is not supported by your browser</p>";
        return;
    }

    function success(position) {
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;

        //outputLat.innerHTML = "<p>" + latitude + "°</p>";
        //outputLon.innerHTML = "<p>" +  + longitude + "°</p>";

        document.getElementById("startLatitude").value = latitude;
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

// Initalize Map with Geolocation
function initializeMap() {

    // Map Object - printed in <div id = 'map_canvas'>
    var map = new google.maps.Map(document.getElementById('map_canvas'), {
        center: { lat: 42.3347, lng: -83.0497 },
        zoom: 16
    });

    if (navigator.geolocation) {
        // if the browser supports geolocation
        // "Hey Geolocation! Please go find the current position and set the current lat and lng to the lat and lng vars."
        navigator.geolocation.getCurrentPosition(function (position) {
            position = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            map.setCenter(position);                    // re-center the map over our current position

            // Create the Marker to be dropped
            marker = new google.maps.Marker({
                map: map,                               // the map it's on is called map
                position: position,                     // the position is at the var position
                icon: image,                            // the icon displayed is the var image that we defined earlier
                animation: google.maps.Animation.DROP   // makes the marker drop in
            });

            infoWindow = new google.maps.InfoWindow({ map: map });
            infoWindow.setPosition(position);           // now my infoWindow is where ever the heck we are
            infoWindow.setContent('Howdy, walker!');    // the message the infowindow will display
        },
        function () {           // the function for this is defined below
            handleLocationError(true, infoWindow, map.getCenter(), success());
        });
    }
    else {
        // Browser doesn't support Geolocation we have a fall through case to
        // re-center the map and drop a pin on Grand Circus.
        // It displays a separate message, 'Howdy, Grand Circus!'
        handleLocationError(false, infoWindow, map.getCenter());
    }

    // Default location if Geolocation is not Available
    function handleLocationError(browserHasGeolocation, infoWindow, position) {
        infoWindow = new google.maps.InfoWindow({ map: map });
        infoWindow.setPosition(position);
        infoWindow.setContent(browserHasGeolocation ?
                              'Howdy, Grand Circus!' :
                              'Error: Your browser doesn\'t support geolocation.');
        var marker = new google.maps.Marker({
            map: map,
            position: position,
            icon: image,
            animation: google.maps.Animation.DROP
        });
    }
}
