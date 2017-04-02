var ViewModel = function () {
    var self = this;
    self.registrants = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.hospitals = ko.observableArray();
    self.newRegistrant = {
        Name: ko.observable(),
        Hospital: ko.observable(),
        Age: ko.observable(),
        EmailAddress: ko.observable(),
        DaysStaying: ko.observable()
    }

    var registrantsUri = '/api/RegistrantModels/';
    var hospitalsUri = 'api/HospitalModels/';

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

    function getHospitals() {
        ajaxHelper(hospitalsUri, 'GET').done(function (data) {
            self.hospitals(data);
        });
    }

    self.getBookDetail = function (item) {
        ajaxHelper(registrantsUri + item.RegistrantId, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.addRegistrant = function (formElement) {
        var registrant = {
            Name: self.newRegistrant.Name(),
            HospitalId: self.newRegistrant.Hospital().HospitalId,
            Age: self.newRegistrant.Age(),
            EmailAddress: self.newRegistrant.EmailAddress(),
            DaysStaying: self.newRegistrant.DaysStaying()
        };

        ajaxHelper(registrantsUri, 'POST', registrant).done(function (item) {
            self.registrants.push(item);
        });
    }

    // Fetch the initial data.
    getAllRegistrants();
    getHospitals();
};

ko.applyBindings(new ViewModel());