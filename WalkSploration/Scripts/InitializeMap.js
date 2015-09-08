// Initialize Global Variables
var map;                                        // the actual map image to display
//var mapOptions;                               // holds the center, zoom and mapTypeId: bits
var geocoder = new google.maps.Geocoder();      // the function that will take an address and return geocoordinates
var position;                                   // creates the position variable

var image = {                                   // Creates custom Map Pin Image and location relative to info window
    url: "/Images/sneakerMarker.png",
    anchor: new google.maps.Point(20, 15)
};
var marker;                                     // Initializes marker object


function initializeMap() {

    // Creates the variable map, with the default lat and lng for Grand Circus
    map = new google.maps.Map(document.getElementById('map_canvas'), {
        center: { lat: 42.3347, lng: -83.0497 },
        zoom: 16
    });

    var infoWindow = new google.maps.InfoWindow({ map: map });

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        // "Hey Geolocation! Please go find the current position and set the current lat and lng to the lat and lng vars."
        navigator.geolocation.getCurrentPosition(function (position) {
            position = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            infoWindow.setPosition(position);
            infoWindow.setContent('Howdy, walker!');
            map.setCenter(position);
            
            function success(position) {
                var latitude = position.coords.latitude;
                var longitude = position.coords.longitude;

                outputLat.innerHTML = '<p>Latitude is ' + latitude + '°</p>;'
                outputLon.innerHTML = '<p>Longitude is ' + longitude + '°</p>';
            }
            // custom shoe marker
            marker = new google.maps.Marker({
                map: map,
                position: position,
                icon: image,
                animation: google.maps.Animation.DROP
            });
        },

        function () {
            handleLocationError(true, infoWindow, map.getCenter(), success());
        });
    }
    else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
}



// Default location if Geolocation is not Available
function handleLocationError(browserHasGeolocation, infoWindow, position) {
    infoWindow.setPosition(position);
    infoWindow.setContent(browserHasGeolocation ?
                          'Howdy, Grand Circus!' :
                          'Error: Your browser doesn\'t support geolocation.');
    marker = new google.maps.Marker({
        map: map,
        position: position,
        icon: image,
        animation: google.maps.Animation.DROP
    });
}

// Optional Bounce animation for Map Pin
function toggleBounce() {
    if (marker.getAnimation() !== null) {
        marker.setAnimation(null);
    } else {
        marker.setAnimation(google.maps.Animation.BOUNCE);
    }
}

// Adds a listener for the click event to place pin at Start Location
document.getElementById('submitWalk').addEventListener('click', function () {
    geocodeAddress(geocoder, map);
});

function geocodeAddress(geocoder, resultsMap) {
    var address = document.getElementById('address').value;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            resultsMap.setCenter(results[0].geometry.location);
            marker = new google.maps.Marker({
                map: resultsMap,
                position: results[0].geometry.location,
                icon: image
            });
        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}



