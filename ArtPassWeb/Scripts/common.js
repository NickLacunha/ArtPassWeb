function ajaxHelper(uri, method, error, data) {
    error('');
    return $.ajax({
        type: method,
        url: uri,
        dataType: 'json',
        contentType: 'application/json',
        data: data ? JSON.stringify(data) : null
    }).fail(function (jqXHR, textStatus, errorThrown) {
        error(errorThrown);
    });
}

// todo: define this conditionally
var registrantsUri = '/api/RegistrantModels/';
var hospitalsUri = '/api/HospitalModels/';