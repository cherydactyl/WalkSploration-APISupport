function initMap() {
    var directionsDisplay = new google.maps.DirectionsRenderer;
    var directionsService = new google.maps.DirectionsService;
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 14,
        center: { lat: originLat, lng: originLng }
    });

    directionsDisplay.setMap(map);
    calculateAndDisplayRoute(directionsService, directionsDisplay);

    var infowindow = new google.maps.InfoWindow();
    var service = new google.maps.places.PlacesService(map);
    var place = googleId

    service.getDetails({
        placeId: place
    }, function (place, status) {
        if (status === google.maps.places.PlacesServiceStatus.OK){
            var marker = new google.maps.Marker({
                map: map,
                position: place.geometry.location
            });
            google.maps.event.addListener(marker, 'click', function () {
                infowindow.setContent('<strong>' + destination.name + '</strong>');
                infowindow.open(map, this);
            });
        }
    });
}

function calculateAndDisplayRoute(directionsService, directionsDisplay) {
    directionsService.route({
        origin: { lat: originLat, lng: originLng},
        destination: { lat: pointLat, lng: pointLng }, 

        travelMode: google.maps.TravelMode.WALKING
    }, function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            directionsDisplay.setDirections(response);
            directionsDisplay.setPanel(document.getElementById('left-panel'));
        } else {
            window.alert('Directions request failed due to ' + status);
        }
    });
}