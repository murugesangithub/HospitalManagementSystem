
$(document).ready(function () {
    $('input[type=datetime]').val('');
    $('input[type=datetime]').datepicker({
        dateFormat: "dd-mm-yy",
        minDate: 0,
        maxDate: 7,
        changeMonth: true,
        changeYear: true,
        yearRange: "-1:+0",
        beforeShowDay: function (date) {
            var day = date.getDay();
            return [(day != 0), ''];
        },
        onSelect: function (dateString, txtDate) {
            //alert("Selected Date: " + dateString + "\nTextBox ID: " + txtDate.id);
            GetAppointmentDetails(dateString);
        }
    });
    //jQuery.validator.methods.date = function (value, element) {
    //    if (value) {
    //        try {
    //            $.datepicker.parseDate('dd-mm-yy', value);
    //        } catch (ex) {
    //            return false;
    //        }
    //    }
    //    return true;
    //};


   // GetAppointmentDetails($('input[type=datetime]').val());

    //$('#ConsultingDoctor, #doctorsearchicon').on('click', function () {
    //    $('#DoctorModalPopup').modal();
    //    DoctorGridForAppointment();
    //});

   
});

function GetAppointmentDetails(date) {

    $.ajax({
        url: relativepath + '/Appointment/GetAppointmentTimeDetailByDate?date=' + date,
        type: "GET",
        success: function (result) {
            console.log(result);
            $('#TimeSlot').val('');
            $("#TimeSlot").children("option").show();
            $.each(result, function (index, value) {
                $("#TimeSlot").children("option[value=" + value + "]").hide()
            });
        },
    });
}