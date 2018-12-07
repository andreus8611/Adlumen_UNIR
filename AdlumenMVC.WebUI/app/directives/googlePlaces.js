'use strict';
adlumenApp.directive('googlePlaces', ['uiGmapGoogleMapApi', function(uiGmapGoogleMapApi ) {
    return {
        restrict: 'E',
        replace: true,
        // transclude:true,
        scope: { location: '=' },
        template: '<input id="google_places_ac" name="google_places_ac" type="text" class="input-block-level" size="50" placeholder="Buscar ubicación" />',
        link: function(scope, elm, attrs) {
            uiGmapGoogleMapApi.then(function(maps) {
                var autocomplete = new google.maps.places.Autocomplete($("#google_places_ac")[0], {});
                google.maps.event.addListener(autocomplete, 'place_changed', function() {
                    var place = autocomplete.getPlace();
                    //$scope.location = place.geometry.location.lat() + ',' + place.geometry.location.lng();
                    scope.$apply(function() {
                        scope.location = place;
                    });
                });
            });
        }
    }
}]);