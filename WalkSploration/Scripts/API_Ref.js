////API refernce link for Google Maps Places Libraries
////https://maps.googleapis.com/maps/api/js?libraries=places

//var uri = 'api/location';

//$(document).ready(function () {
//    // Send an AJAX request
//    $.getJSON(apiuri)
//        .done(function (data) {
//            // On success, 'data' contains a list of locations.
//            $.each(data, function (key, item) {
//                // Add a list item for the location.
//                $('<li>', { text: formatItem(item) }).appendTo($('#locations'));
//            });
//        });
//});

//function formatItem(item) {
//    return item.Name + item.GeoCoordinate;
//}

//function find() {
//    var id = $('#place_ID').val();
//    $.getJSON(uri + '/' + id)
//        .done(function (data) {
//            $('#location').text(formatItem(data));
//        })
//        .fail(function (jqXHR, textStatus, err) {
//            $('#location').text('Error: ' + err);
//        });
//}



//var map;
//var infowindow;

//// Initializer for map with no user input. Centers over Grand Circus 
//function initialize() {
//    var myLatLng = new google.maps.LatLng(42.3347, -83.0497);

//    map = new google.maps.Map(document.getElementById('map'), {
//        center: myLatLng,
//        zoom: 16
//    });

//    infowindow = new google.maps.InfoWindow();

//    var service = new google.maps.places.PlacesService(map);
//    service.nearbySearch(request, callback);

//    var request = {
//        location: myLatLng,
//        radius: '500',
//        types: ['store']
//    };

//}

////second version of initializer function
////function initialize() {
////    var myLatLng = new google.maps.LatLng(42.3347, -83.0497);

////    var map = new google.maps.Map(document.getElementById('map'), {
////        center: myLatLng,
////        zoom: 16
////    });

////    var infowindow = new google.maps.InfoWindow({map: map});

////    // Try HTML5 geolocation.
////    if (navigator.geolocation) {
////        navigator.geolocation.getCurrentPosition(function(position) {
////            var pos = {
////                lat: position.coords.latitude,
////                lng: position.coords.longitude
////            };

////            infoWindow.setPosition(pos);
////            infoWindow.setContent('Location found.');
////            map.setCenter(pos);
////        }, function() {
////            handleLocationError(true, infoWindow, map.getCenter());
////        });
////    } else {
////        // Browser doesn't support Geolocation
////        handleLocationError(false, infoWindow, map.getCenter());
////    }
////}

////commented out/diabled; was for debugging
////function handleLocationError(browserHasGeolocation, infoWindow, pos) {
////    infoWindow.setPosition(pos);
////    infoWindow.setContent(browserHasGeolocation ?
////                          'Error: The Geolocation service failed.' :
////                          'Error: Your browser doesn\'t support geolocation.');

////}

//function callback(results, status) {
//    if (status == google.maps.places.PlacesServiceStatus.OK) {
//        for (var i = 0; i < results.length; i++) {
//            var place = results[i];
//            createMarker(results[i]);
//        }
//    }
//}

//function createMarker(places) {
//    var bounds = new google.maps.LatLngBounds();
//    var placesList = document.getElementById('places');
//    for (var i = 0, place; place = places[i]; i++) {
//        var image = {
//            url: place.icon,
//            size: new google.maps.Size(71, 71),
//            origin: new google.maps.Point(0, 0),
//            anchor: new google.maps.Point(17, 34),
//            scaledSize: new google.maps.Size(25, 25)
//        };
//        var marker = new google.maps.Marker({
//            map: map,
//            icon: image,
//            title: place.name,
//            //position: place.geometry.location
//            position: myLatLng
//        });
//        placesList.innerHTML += '<li>' + place.name + '</li>';
//        bounds.extend(place.geometry.location);
//    }
//    map.fitBounds(bounds);
//}

