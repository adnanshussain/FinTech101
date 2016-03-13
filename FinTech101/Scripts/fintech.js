$(function () {
    console.log("fintech ready!");

    $("#q1_go").on("click", function () {
        $('#result').html("Loading... Please wait...");

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
                debugger;
            }
        })
    });

    $("#q2_go").on("click", function () {
        $('#result').html("Loading... Please wait...");

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
                debugger;
            }
        })
    });

    $("#q3_go").on("click", function () {
        $('#result').html("Loading... Please wait...");

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
                debugger;
            }
        })
    });

    $("#q4_go").on("click", function () {
        $('#result').html("Loading... Please wait...");

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
                debugger;
            }
        })
    });
});