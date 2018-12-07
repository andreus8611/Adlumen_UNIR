'use strict';
adlumenApp.directive('indicatorsGraph', function () {

    function link(scope, element, attrs) {

        //watch the indicators to trigger the directive when the indicator change

        scope.$watch('indicator', function (newValue, oldValue) {
            //initialize arrays for the graph

            //fill the labels with the periods included between the stardate and finaldate of the indicator
            scope.labels = _.map(newValue.periods, function (period) { return period.nombre });
            scope.series = [];
            scope.data = [];

            //push the base of the indicator as first value to the serie of goals

            var serieAdata = [newValue.base]; //Programado

            //fill the series of goals with null for all the periods (labels)

            for (var i = 1; i < scope.labels.length - 1; i++) {
                serieAdata.push(null);
            }

            //push the goal of the indicator as the final value in the series of goals

            serieAdata.push(newValue.meta);

            //fill the series of achievements with null for all the periods of the indicator

            var serieBdata = _.map(newValue.periods, function (period) { return null }); //Actual

            //for each achievement in the indicator

            _.each(newValue.samples, function (sample) {

                //get the index of the period when the achievement was made it

                var index = _.indexOf(newValue.periods,
                    _.findWhere(newValue.periods, { idPeriodo: sample.idPeriodo }));

                //update the null value with the achievement value
                serieBdata[index] = sample.logro;

            });

            //fill all the arrays of the graphic
            scope.series = [scope.translation.ACTUAL, scope.translation.PROGRAMADO];
            scope.data.push(serieBdata); //Actual
            scope.data.push(serieAdata); //Programado

            scope.options = {
                legend: {
                    display: true,
                    position: 'bottom'
                },
                spanGaps: true
            };
        });

    };

    return {
        restrict: 'E',
        scope: {
            indicator: '=',
            translation: '='
        },
        link: link,
        templateUrl: 'app/templates/indicatorsGraph/indicatorsGraph.html'
    };

});