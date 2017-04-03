

var RegistrantBaseViewModel = function () {  // currently refactoring to extract the insert logic for the public frontend
    var self = this;
    self.error = ko.observable();   // base
    self.detail = ko.observable();  // base I think
    self.hospitals = ko.observableArray();
    
    function getHospitals() {   // base
        ajaxHelper(hospitalsUri, 'GET',self.error).done(function (data) {
            self.hospitals(data);
        });
    }

    
    // Fetch the initial data.
    getHospitals();       // base
};

var RegistrantRetrieveViewModel = function () {
    var self = this;
    RegistrantBaseViewModel.call(self);
    self.registrants = ko.observableArray();  // only needed for retrieves
    
    function getAllRegistrants() {      // retrieve only
        ajaxHelper(registrantsUri, 'GET', self.error).done(function (data) {
            self.registrants(data);
        });
    }

    self.getBookDetail = function (item) {      // retrieves
        ajaxHelper(registrantsUri + item.RegistrantId, 'GET', self.error).done(function (data) {
            self.detail(data);
        });
    }

    getAllRegistrants();  // only needed for retrieves
};

var RegistrantInsertViewModel = function () {
    var self = this;
    RegistrantBaseViewModel.call(self);

    self.newRegistrant = {    
        Name: ko.observable(),
        Hospital: ko.observable(),
        Age: ko.observable(),
        EmailAddress: ko.observable(),
        DaysStaying: ko.observable()
    }

    self.addRegistrant = function (formElement) {  
        var registrant = {
            Name: self.newRegistrant.Name(),
            HospitalId: self.newRegistrant.Hospital().HospitalId,
            Age: self.newRegistrant.Age(),
            EmailAddress: self.newRegistrant.EmailAddress(),
            DaysStaying: self.newRegistrant.DaysStaying()
        };

        ajaxHelper(registrantsUri, 'POST', self.error, registrant).done(function (item) {
            if (typeof self.registrants != 'undefined') {  // registrants will only be defined in admin-level modules
                self.registrants.push(item);
            }
        });
    }
};

var RegistrantAdminViewModel = function () {
    var self = this;
    RegistrantBaseViewModel.call(self);
    RegistrantRetrieveViewModel.call(self);
    RegistrantInsertViewModel.call(self);
};

ko.applyBindings(new RegistrantAdminViewModel());