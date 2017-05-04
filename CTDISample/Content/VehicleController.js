
var app = angular.module('app', []);
var url = '/api/Values/';
app.factory('vehicleFactory', function ($http) {
    return {
        getVehicle: function () {
            return $http.get(url);
        },
        addVehicle: function (vehicle) {
            return $http.post(url, vehicle);
        },
        deleteVehicle: function (vehicle) {
            return $http.delete(url + vehicle.VEHICLE_ID);
        },
        updateVehicle: function (vehicle) {
            return $http.put(url + vehicle.VEHICLE_ID, vehicle);
        }
    };
});

app.controller('VehicleController', ['$scope', 'vehicleFactory', function ($scope, vehicleFactory) {
    $scope.vehicles = [];
    $scope.loading = true;
    $scope.addMode = false;

    $scope.toggleEdit = function () {
        this.vehicle.editMode = !this.vehicle.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    $scope.save = function () {
        $scope.loading = true;
        var vhl = this.vehicle;
        vehicleFactory.updateVehicle(vhl).success(function (data) {
            alert("Saved Successfully!!");
            vhl.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving Vehicle! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    $scope.add = function () {
        $scope.loading = true;
        vehicleFactory.addVehicle(this.newvhl).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.vehicles.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Adding Vehicle! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };
    $scope.delvehicle = function () {
        $scope.loading = true;
        var vhl = this.vehicle;
        vehicleFactory.deleteVehicle(vhl).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.vehicles, function (i) {
                if ($scope.vehicles[i].VEHICLE_ID === vhl.VEHICLE_ID) {
                    $scope.vehicles.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving Vehicle! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    $scope.cars = [
    { model: "Wagon R", color: "red" },
    { model: "Alto", color: "white" },
    { model: "Santro", color: "black" }
    ];

    vehicleFactory.getVehicle().success(function (data) {
        $scope.vehicles = data;
        $scope.loading = false;
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loading posts! " + data.ExceptionMessage;
        $scope.loading = false;
    });

}]);