function initializeMap() {

    // HEY! make me a map that will center over the lat and lon I want
    // printed out in the object with the id 'map_canvas'
    map = new google.maps.Map(document.getElementById('map_canvas'), {
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
        marker = new google.maps.Marker({
            map: map,
            position: position,
            icon: image,
            animation: google.maps.Animation.DROP
        });
    }
}