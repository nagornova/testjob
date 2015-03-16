
app.factory('AddressService', function ($http, $q, $log, $rootScope) {
    var baseUrl = '/api/address';

    var service = {
        data: {
            currentaddress: {},
            addresses: [],
            selected:[],
            totalPages: 0,

            filterOptions: {
                filterText: '',
                externalFilter: 'searchText',
                useExternalFilter: true
            },
            sortOptions: {
                fields: ["ID_address"],
                directions: ["asc"]
            },
            pagingOptions: {
                pageSizes: [10, 20, 50, 100],
                pageSize: 10,
                currentPage: 1
            },
            filterTextCity: '',
            filterTextStreet: '',
            filterTextHouse: '',
            filterTextPostCode: '',
            filterTextDate: '',
            filterTextDate2: '',
            showFilter: true,
            showFooter: true,
            showGroupPanel: true,
            i18n: ["ru"]
        },
        find: function () {
            var params = {
                searchtext: service.data.filterOptions.filterText,
                searchtextCity: service.data.filterTextCity,
                searchtextStreet: service.data.filterTextStreet,
                searchtextHouse: service.data.filterTextHouse,
                searchtextPostCode: service.data.filterTextPostCode,
                searchtextDate: service.data.filterTextDate,
                searchtextDate2: service.data.filterTextDate2,
                page: service.data.pagingOptions.currentPage,
                pageSize: service.data.pagingOptions.pageSize,
                sortBy: service.data.sortOptions.fields[0],
                sortDirection: service.data.sortOptions.directions[0]
            };
            var deferred = $q.defer();
           // $http.get(baseUrl)
            $http.get(baseUrl, { params: params })
            .success(function (data) {
                service.data.addresses = data;
                deferred.resolve(data);

            }).error(function () {

                deferred.reject();

            });
            return deferred.promise;
        }
    }
    service.find();
    return service;
});