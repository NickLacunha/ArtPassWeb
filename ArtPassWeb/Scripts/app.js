﻿var ViewModel = function () {
    var self = this;
    self.registrants = ko.observableArray();
    self.error = ko.observable();

    var registrantsUri = '/api/RegistrantModels/';

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

    function getAllRegistrants() {
        ajaxHelper(registrantsUri, 'GET').done(function (data) {
            self.registrants(data);
        });
    }

    // Fetch the initial data.
    getAllRegistrants();
};

ko.applyBindings(new ViewModel());