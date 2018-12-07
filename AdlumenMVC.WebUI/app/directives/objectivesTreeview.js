'use strict';
adlumenApp.directive('getObjectives', function () {

    function link(scope, element, attrs) {

        var objectives, nodes;

        if (attrs.ngClick || attrs.href === '' || attrs.href === '#') {
            element.on('click', function (e) {
                e.preventDefault();
            });
        }

        //function to set the childs of the parent objective
        var setChildNodes = function (array, objective, childs) {

            var value = false;

            //check if the array object is an array

            if (_.isArray(array)) {

                //find the object of the array who will have the childs objectives

                var filteredObjective = _.findWhere(array, { idObjetivo: objective.idObjetivo });

                //check if the filteredObjective is undefined, means that the objective is not in this node level

                if (_.isUndefined(filteredObjective)) {

                    //search the objective parent of the childs in the next node level

                    _.each(array, function (item) {
                        //check if the object already have childs
                        if (_.has(item, "childs")) {
                            //if it does then call setChildNodes to search in the next level
                            if (setChildNodes(item.childs, objective, childs)) {
                                return;
                            }
                        }
                    });
                }
                    //if the objective is in this level then asign to the parent objective his childs and set the value to true to returned it
                else {
                    //we identify the index of the parent objective and add his childs
                    array[_.indexOf(array, filteredObjective)].childs = childs;
                    //set the value to return to true
                    value = true;
                }


            }

            return value;

        };

        scope.$watch(attrs.uiObjectives, function (value) {
            objectives = value;

            //Initialize nodes with the general goals

            nodes = _.where(objectives, { idPadre: 0 });

            //lunch function
            initObjectives();
            scope.childs = nodes;
        });

        //function to iterate trough all the objectives

        function initObjectives() {

            _.each(objectives, function (objective, index) {

                //we get the childs of the objective

                var childs = _.where(objectives, { idPadre: objective.idObjetivo });

                //if childs is not empty (this mean that the objective has childs) 
                //then we call the function where we will asign the childs objectives to his parents objectives

                if (!_.isEmpty(childs)) {
                    setChildNodes(nodes, objective, childs);
                }

            });

        };

        scope.setObjective = function (objective) { scope.treeviewObjective = objective; }
    };

    return {
        restrict: 'E',
        link: link,
        templateUrl: 'app/templates/objDirective/objdirective.html'
    };

});