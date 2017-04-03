var RegistrantBaseViewModel = function () {  // currently refactoring to extract the insert logic for the public frontend
    var self = this;
    self.registrants = ko.observableArray();  // only needed for retrieves
    self.error = ko.observable();   // base
    self.detail = ko.observable();  // base I think
    self.hospitals = ko.observableArray();
    self.newRegistrant = {      // only needed for inserts
        Name: ko.observable(),
        Hospital: ko.observable(),
        Age: ko.observable(),
        EmailAddress: ko.observable(),
        DaysStaying: ko.observable()
    }

    var registrantsUri = '/api/RegistrantModels/';  // base
    var hospitalsUri = 'api/HospitalModels/';       // base

    function ajaxHelper(uri, method, data) {        // base
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

    function getAllRegistrants() {      // retrieve only
        ajaxHelper(registrantsUri, 'GET').done(function (data) {
            self.registrants(data);
        });
    }

    function getHospitals() {   // base
        ajaxHelper(hospitalsUri, 'GET').done(function (data) {
            self.hospitals(data);
        });
    }

    self.getBookDetail = function (item) {      // retrieves
        ajaxHelper(registrantsUri + item.RegistrantId, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.addRegistrant = function (formElement) {  // inserts
        var registrant = {
            Name: self.newRegistrant.Name(),
            HospitalId: self.newRegistrant.Hospital().HospitalId,
            Age: self.newRegistrant.Age(),
            EmailAddress: self.newRegistrant.EmailAddress(),
            DaysStaying: self.newRegistrant.DaysStaying()
        };

        ajaxHelper(registrantsUri, 'POST', registrant).done(function (item) {
            if (typeof self.registrants != 'undefined') {  // registrants will only be defined in admin-level modules
                self.registrants.push(item);
            }
        });
    }

    // Fetch the initial data.
    getAllRegistrants();  // only needed for retrieves
    getHospitals();       // base
};

var RegistrantInsertViewModel = function () {
    var self = this;
    RegistrantBaseViewModel.call(self);


};

ko.applyBindings(new RegistrantBaseViewModel());