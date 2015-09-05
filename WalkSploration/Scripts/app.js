var ViewModel = function () {
    var self = this;
    self.pois = ko.observableArray();
    self.error = ko.observable();

    var booksUri = '/api/home/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllPois() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            self.pois(data);
        });
    }

    // Fetch the initial data.
    getAllPois();

    self.detail = ko.observable();

    self.getPoiDetail = function (item) {
        ajaxHelper(booksPoi + item.Id, 'GET').done(function (data){
            self.detail(data);
        });
    }
};

ko.applyBindings(new ViewModel());