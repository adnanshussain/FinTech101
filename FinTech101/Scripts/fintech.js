function initResults() {
    $('#result-error').html("");
    $('#result').html("Loading... Please wait...");
}

function resultWasError() {
    $("#result").html("");
    $('#result-error').html("There was an error processing the request.");
}

$(function () {
    console.log("fintech ready!");

    $("#q1_go").on("click", function () {
        initResults();

        $.ajax('/home/q1', {
            data: {
                companyID: $('#q1_company').val(),
                upOrDown: $('#q1_uod').val(),
                percent: $('#q1_percent').val(),
                year: $('#q1_year').val()
            },
            success: function (data, status, xhrObj) {
                console.log("ajax success");
                $('#result').html(data);
            },
            error: function (xhrObj, status, errorThrown) {
                resultWasError();
            }
        })
    });

    $("#q2_go").on("click", function () {
        initResults();

        $.ajax('/home/q2', {
            data: {
                companyID: $('#q2_company').val(),
                year: $('#q2_year').val()
            },
            success: function (data, status, xhrObj) {
                console.log("ajax success");
                $('#result').html(data);
            },
            error: function (xhrObj, status, errorThrown) {
                resultWasError();
            }
        })
    });

    $("#q3_go").on("click", function () {
        initResults();

        $.ajax('/home/q3', {
            data: {
                companyID: $('#q3_company').val(),
                from_year: $('#q3_from_year').val(),
                to_year: $('#q3_to_year').val()
            },
            success: function (data, status, xhrObj) {
                console.log("ajax success");
                $('#result').html(data);
            },
            error: function (xhrObj, status, errorThrown) {
                resultWasError();
            }
        })
    });

    $("#q4_go").on("click", function () {
        initResults();

        $.ajax('/home/q4', {
            data: {
                eventID: $('#q4_event').val(),
                weeksBefore: $('#q4_weeks_before').val(),
                weeksAfter: $('#q4_weeks_after').val(),
                companyID: $('#q4_company').val()
            },
            success: function (data, status, xhrObj) {
                console.log("ajax success");
                $('#result').html(data);
            },
            error: function (xhrObj, status, errorThrown) {
                resultWasError();
            }
        })
    });

    $("#q5_go").on("click", function () {
        initResults();

        $.ajax('/home/q5', {
            data: {
                percent: $('#q5_percent').val(),
                from_year: $('#q5_from_year').val(),
                to_year: $('#q5_to_year').val()
            },
            success: function (data, status, xhrObj) {
                console.log("ajax success");
                $('#result').html(data);
            },
            error: function (xhrObj, status, errorThrown) {
                resultWasError();
            }
        })
    });
});