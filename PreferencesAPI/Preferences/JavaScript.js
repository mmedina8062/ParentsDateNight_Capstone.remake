function($) {
    function processForm(e) {
        var dict = {
            Preferences: this["preferences"].value
        };

        $.ajax({
            url: 'https://localhost:44307/api/preferences',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function (data, textStatus, jQxhr) {
                alert("Preference Added"),

                $('#response pre').html(data);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        });

        e.preventDefault();
    }

    $('#my-form').submit(processForm);
}) (jQuery);

function GetPreferences() {
    $.ajax({
        url: 'https://localhost:44307/api/preferences',
        dataType: 'json',
        type: 'Get',
        success: function (data, textStatus, jQxhr) {
            $('tbody').empty();
            var preference = "";
            preference += "<tr>";
            preference += "<th>Preferences:</th>";
            preference += "</tr>";
        }
    });
}