(function ($) {
    function processForm(e) {
        var dict = {
            Preference: this["preferences"].value
        };

        $.ajax({
            url: 'https://localhost:44307/api/preferences',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function (data, textStatus, jQxhr) {
                alert("Your preference has been added."),

                    $('#response pre').html(data);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        });
        $('#my-form').empty();
        e.preventDefault();
    }
    $('#my-form').submit(processForm);

})(jQuery);


function GetPreferences() {

    $.ajax({
        url: 'https://localhost:44307/api/preferences',
        dataType: 'json',
        type: 'Get',
        success: function (data, textStatus, jQxhr) {
            $('tbody').empty();
            var preferences = "";
            preferences += "<tr>";
            preferences += "<th>Preferences:</th>";
            preferences += "</tr>";
            $.each(data, function (index, value) {


                preferences += "<tr>";
                preferences += "<td>" + value.Preference + "</td>";
                preferences += "<td><button type ='button' onclick='GetSingleMovie(" + value.getElementById + ")'>Details</button>";
                preferences += "<td><button type='button' onclick='DeleteMovie(" + value.getElementById + ")'>Delete</button>";
                preferences += "</tr>";


            });
            preferences += "<tr>";
            preferences += "<td><button type='button' onclick='MakeForm()'>Add New Preference</button>";
            preferences += "</tr>"
            $('#PreferenceBody').append(newMovie);
            $('#my-form').empty();
            $('#edit').empty();

        }

    });

}
function MakeForm() {
    var newForm = "";
    newForm += "<input type='text' name='Preference' placeholder='Preference' />";
    newForm += "<button type='submit'>Submit</button>";
    $('#my-form').append(newForm);
    $('tbody').empty();


}
function GetSinglePreferences(id) {
    $.ajax({
        url: 'https://localhost:44307/api/preferences/' + id,
        dataType: 'json',
        type: 'Get',
        success: function (data, textStatus, jQxhr) {
            var searchedPreference = "";
            searchedPreference += "<tr>";
            searchedPreference += "<td>" + data.Preferences + "</td>";
            searchedPreference += "</tr>";
            $('#PreferenceBody').html(searchedPreference);
        }
    })
        .then(MakeTheFrom(id));

}
function MakeTheFrom(id) {
    var editForm = "";
    editForm += " <input type='text'id='preference'name='preference'placeholder='Title'/>";
    editForm += "<button type='button' onclick='UpdatePreference(" + id + ")'>Update</button>";
    $('#edit').append(editForm);


}

function UpdatePreferences(id) {
    var editPreferences = {
        "Preferences": document.getElementById('preferences').value,
    };

    $.ajax({
        type: 'PUT',
        url: 'https://localhost:44307/api/preferences/' + id,
        dataType: 'json',
        data: editMovie,
        success: function () {
            $('#edit').empty();

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
            console.log(editMovie);
        }
    });

}
function DeletePreferences(id) {
    $.ajax({
        url: 'https://localhost:44307/api/preferences/' + id,
        dataType: 'json',
        type: 'Delete',
        success: function (data, textStatus, jQxhr) {
            alert("Preference has been removed.")
            $('tbody').empty();
        }

    })

}