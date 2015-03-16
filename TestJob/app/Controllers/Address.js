app.controller('AddressController', function ($scope, AddressService, $routeParams, $log) {
    $scope.data = AddressService.data;
        
    $scope.$watch('data.sortOptions', function (newVal, oldVal) {
        $log.log("sortOptions changed: " + newVal);
        if (newVal !== oldVal) {

            $scope.data.pagingOptions.currentPage = 1;
            AddressService.find();
        };
    }, true);

    $scope.$watch('data.pagingOptions', function (newVal, oldVal) {
        $log.log("page changed: " + newVal);
        if (newVal !== oldVal) {
            AddressService.find();
        }
    }, true);

    $scope.$watch('data.filterOptions', function (newVal, oldVal) {
        $log.log("filters changed: " + newVal);
        $("#reset").click(function () { $scope.data.filterOptions.filterText = "" });
        if (newVal !== oldVal ) {
            $scope.data.pagingOptions.currentPage = 1;
            AddressService.find();
        }

    }, true);    

    $scope.$watch('data.filterTextCity', function (newVal, oldVal) {
        $log.log("filterTextCity changed: " + $scope.data.filterTextCity);
        $("#reset").click(function () { $scope.data.filterTextCity = "" });
        if (newVal !== oldVal ) {
            $scope.data.pagingOptions.currentPage = 1;
            AddressService.find();
        }
    }, true);
    $scope.$watch('data.filterTextStreet', function (newVal, oldVal) {
        $log.log("filterTextStreet changed: " + $scope.data.filterTextStreet);
        $("#reset").click(function () { $scope.data.filterTextStreet = "" });
        if (newVal !== oldVal ) {
            $scope.data.pagingOptions.currentPage = 1;
            AddressService.find();
        }
    }, true);


    $scope.$watch('data.filterTextPostCode', function (newVal, oldVal) {
        $log.log("filterTextPostCode changed: " + $scope.data.filterTextPostCode);
        $("#reset").click(function () { $scope.data.filterTextPostCode = "" });
        if (newVal !== oldVal ) {
            $scope.data.pagingOptions.currentPage = 1;
            AddressService.find();
        }
    }, true);
    $scope.$watch('data.filterTextDate', function (newVal, oldVal) {
        $log.log("filterTextDate changed: " + $scope.data.filterTextDate);
        $("#reset").click(function () { $scope.data.filterTextDate = "" });
        //$('#reservationtime').daterangepicker();
        //$('#reservationtime').daterangepicker({
        //    timePicker: true,
        //    timePickerIncrement: 15,
        //    format: 'YYYY-MM-DDTHH:mm:ss',
        //    singleDatePicker: false,
        //    opens: ('center'),
        //    startDate: '2000-01-01',
        //    endDate: '2015-03-01'
        //}, function (start, end, label) {
        //    console.log(start.toISOString(), end.toISOString(), label);
        //});
        //$('#reservationtime').on('apply.daterangepicker', function (ev, picker) {
        //    console.log(picker.startDate.format('YYYY-MM-DD'));
        //    console.log(picker.endDate.format('YYYY-MM-DD'));
        //    AddressService.find();
        //});
        if (newVal !== oldVal ) {
            $scope.data.pagingOptions.currentPage = 1;
            AddressService.find();
        }
    }, true);
    $scope.$watch('data.filterTextDate2', function (newVal, oldVal) {
        $log.log("filterTextDate2 changed: " + $scope.data.filterTextDate2);
        $("#reset").click(function () { $scope.data.filterTextDate2 = "" });
     
        if (newVal !== oldVal) {
            $scope.data.pagingOptions.currentPage = 1;
            AddressService.find();
        }
    }, true);
   


    $scope.$watch('data.filterTextHouse', function (newVal, oldVal) {
        //$('#house').slider({
        //    formater: function (value) {
        //        return 'Current value: ' + value;
        //    }
        //});
        $("#reset").click(function () { $scope.data.filterTextHouse =""});
        //$("#getVal").click(function () {
            //$("#house").on("slide", function (slideEvt) {
            //    $("#houseSliderVal").text(slideEvt.value);
            //});
            //$log.log("Value 1 = " + $("#house").data('slider').getValue());
            //$scope.data.filterTextHouse = $("#house").data('slider').getValue();
            $log.log("filterTextHouse changed: " + $scope.data.filterTextHouse);
        // });
        if (newVal !== oldVal) {
            $scope.data.pagingOptions.currentPage = 1;
            AddressService.find();
        }
    }, true);



    $scope.gridOptions = {
        data: 'data.addresses.Content',
        showFilter: false,
        multiSelect: false,
        selectedItems: $scope.data.selected,
        enablePaging: true,
        showFooter: true,
        totalServerItems: 'data.addresses.TotalRecords',
        pagingOptions: $scope.data.pagingOptions,
        filterOptions: $scope.data.filterOptions,
        useExternalSorting: true,
        sortInfo: $scope.data.sortOptions,
        plugins: [new ngGridFlexibleHeightPlugin()],       
        columnDefs: [
                   // { field: 'ID_address', displayName: 'ID' },
                    { field: 'Country', displayName: 'Country'},                    
                    { field: 'City', displayName: 'City' },
                    { field: 'Street', displayName: 'Street' },
                    {field: 'House', displayName: 'House'},
                    { field: 'PostCode', displayName: 'Post Code' },
                    { field: 'Date', displayName: 'Date' }
        ],
        afterSelectionChange: function (selection, event) {
            $log.log("selection: alert('pagingOptions');");
        }
    };
});


