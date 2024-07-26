// wwwroot/js/utils.js

function removePrefixes(dataArray) {
    var cleanedData = {};
    dataArray.forEach(function (item) {
        // Assuming the prefix is followed by an underscore, you can adjust this logic as needed
        var newKey = item.name.split('_').pop();
        cleanedData[newKey] = item.value;
    });
    return cleanedData;
}
function capitalizeFirstChar(str) {
    return str.charAt(0).toUpperCase() + str.slice(1);
}

function populateForm(formSelector, data) {
    for (var key in data) {
        if (data.hasOwnProperty(key)) {
            var element = $(formSelector).find('[name="' + capitalizeFirstChar(key) + '"]');
            if (element.length > 0) {
                if (element.is('textarea')) {
                    element.val(data[key]);
                } 
                else if (element.is('input[type="checkbox"]')) {
                    element.prop('checked', data[key]=="false"?false : true);
                }
                else {
                    element.val(data[key]);
                }
            }
        }
    }
}