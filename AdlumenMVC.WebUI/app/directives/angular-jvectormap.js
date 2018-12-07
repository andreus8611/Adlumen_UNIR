'use strict';
adlumenApp.directive('angularJvectormap', [function () {

    function link(scope, element, attrs) {
        //set the height of the element parent of the map
        $(element).parent().height(340);

        //create array for the map's markers
        var _markers = [];

        //watch projects to trigger directives when the api returns the values
        scope.$watch('projects', function (newValue, oldValue) {
            
            //for each project if the state is formulated then set the marker color in aqua
            _.each(newValue, function (project) {
                if (project.idEstado === 1 && project.eliminado === false) {
                    _markers.push({ latLng: [project.latitude, project.longitude], name: project.nombre, style: { fill: '#00a65a' } })
                }
                //for each project if the state is active then set the marker color in green
                if (project.idEstado === 2 && project.eliminado === false) {
                    _markers.push({ latLng: [project.latitude, project.longitude], name: project.nombre, style: { fill: '#00c0ef' } })
                }
                //for each project if the state is closed then set the marker color in red
                if (project.eliminado === true) {
                    _markers.push({ latLng: [project.latitude, project.longitude], name: project.nombre, style: { fill: '#dd4b39' } })
                }
            });

            //if the markers are not empty then set the vectorMap of jvectormap
            if (!_.isEmpty(_markers)) {
                $(element).vectorMap({
                    map: 'world_mill',
                    normalizeFunction: 'polynomial',
                    hoverOpacity: 0.7,
                    hoverColor: false,
                    backgroundColor: 'transparent',
                    regionStyle: {
                        initial: {
                            fill: 'rgba(210, 214, 222, 1)',
                            "fill-opacity": 1,
                            stroke: 'none',
                            "stroke-width": 0,
                            "stroke-opacity": 1
                        },
                        hover: {
                            "fill-opacity": 0.7,
                            cursor: 'pointer'
                        },
                        selected: {
                            fill: 'yellow'
                        },
                        selectedHover: {
                        }
                    },
                    markerStyle: {
                        initial: {
                            fill: '#00a65a',
                            stroke: '#111'
                        }
                    },
                    markers: _markers
                });
            }

        });
        
    };

    return {
        restrict: 'E',
        scope: {
            projects: '='
        },
        link: link
    };
}]);