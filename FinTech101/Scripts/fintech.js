﻿function initResults() {
    $('#result-error').html("");
    $('#result').html("Loading... Please wait...");
}

function resultWasError() {
    $("#result").html("");
    $('#result-error').html("There was an error processing the request.");
}

function fetchResult(qno, data) {
    initResults();

    $.ajax('/home/' + qno, {
        data: data,
        success: function (data, status, xhrObj) {
            console.log("ajax success");
            $('#result').html(data);
        },
        error: function (xhrObj, status, errorThrown) {
            resultWasError();
        }
    });
}

function postData(url, data, successFunc) {
    $.ajax(url, {
        type: "POST",
        data: data,
        complete: function(jqXHR, statusText) {
            // Called right at the fookin end
        },
        success: function (data, status, xhrObj) {
            console.log("ajax post success");
            if (successFunc)
                successFunc();
        },
        error: function (xhrObj, status, errorThrown) {
        }
    });
}

$(function () {
    console.log("fintech ready!");

    $("#set_selection").on("change", function () {
        window.location = "/home/fintech?setid=" + $(this).val();
    });

    $("#q1_go").on("click", function () {
        fetchResult('q1',
            {
                setID: $('#set_selection').val(),
                seID: $('#q1_se').val(),
                upOrDown: $('#q1_uod').val(),
                percent: $('#q1_percent').val(),
                fromYear: $('#q1_from_year').val(),
                toYear: $('#q1_to_year').val(),
            });
    });

    $("#q2_go").on("click", function () {
        fetchResult("q2",
            {
                setID: $('#set_selection').val(),
                seID: $('#q2_se').val(),
                year: $('#q2_year').val()
            });
    });

    $("#q3_go").on("click", function () {
        initResults();

        $.ajax('/home/q3', {
            data: {
                setID: $('#set_selection').val(),
                seID: $('#q3_se').val(),
                from_year: $('#q3_from_year').val(),
                to_year: $('#q3_to_year').val(),
                isPartial: true
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
                setID: $('#set_selection').val(),
                seID: $('#q4_se').val(),
                eventID: $('#q4_event').val(),
                daysBefore: $('#q4_days_before').val(),
                daysAfter: $('#q4_days_after').val()
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

    $("#q4_1_go").on("click", function () {
        initResults();

        $.ajax('/home/q4_1', {
            data: {
                setID: $('#set_selection').val(),
                eventID: $('#q4_1_event').val(),
                daysBefore: $('#q4_1_days_before').val(),
                daysAfter: $('#q4_1_days_after').val()
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

    $("#q4_2_go").on("click", function () {
        initResults();

        $.ajax('/home/q4_2', {
            data: {
                seID: $('#q4_2_se').val(),
                companyEventType: $('#q4_2_cet').val(),
                daysBefore: 1,
                daysAfter: $('#q4_2_days_after').val()
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
                setID: $('#set_selection').val(),
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

    $("#q7_go").on("click", function () {
        initResults();

        $.ajax('/home/q7', {
            data: {
                targetSetID: $('#set_selection').val(),
                targetSeID: $('#q7_target_se').val(),
                anchorSeID: $('#q7_anchor_se').val(),
                targetAfterDays: $('#q7_target_after_days').val(),
                anchorPercent: $('#q7_anchor_percent').val(),
                fromYear: $('#q7_from_year').val(),
                toYear: $('#q7_to_year').val()
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