
$(document).ready(function () {

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
    jQuery.validator.methods.date = function (value, element) {
        if (value) {
            try {
                $.datepicker.parseDate('dd-mm-yy', value);
            } catch (ex) {
                return false;
            }
        }
        return true;
    };


    GetAppointmentDetails($('input[type=datetime]').val());

    $('#ConsultingDoctor, #doctorsearchicon').on('click', function () {
        $('#DoctorModalPopup').modal();
        DoctorGridForAppointment();
    });

    function DoctorGridForAppointment() {

        var grid = "#jqDoctorGridAppointment";
        var gridpager = "#jqDoctorGridAppointmentPager";

        var bodyElem = $('body');

        new ResizeSensor(bodyElem, function () {
            var bodyElemWidth = Math.round($('.content-wrapper').width());
            var newGridWidth = bodyElemWidth - 100;
            $(grid).jqGrid("setGridWidth", newGridWidth, true);
            $('.ui-jqgrid-bdiv').css('overflow', 'hidden');
        });


        $(grid).jqGrid({
            url: relativepath + "Doctor/GetDoctorListForAppointment",
            mtype: "POST",
            styleUI: 'Bootstrap',
            datatype: "json",
            height: 'auto',
            jsonReader: jsonreader,
            colModel: [

                { label: 'DoctorDetailId', name: 'DoctorDetailId', key: true, width: 100, hidden: true, },
                { label: 'EncryptDoctorDetailId', name: 'EncryptDoctorDetailId', width: 100, hidden: true, },
                {
                    label: ' ',
                    name: 'ProfileImage',
                    width: 50,
                    search: false,
                    align: 'center',
                    formatter: function (cellvalue, options, rowObject) {
                        var img = "<img src=" + relativepath + "Images/default_profile.jpg alt='Profile Image' class='rounded-circle' width='50' >"
                        if (cellvalue.length > 0) {
                            img = "<img src='" + cellvalue + "' alt='Profile Image' class='rounded-circle' width='50' />";
                        }
                        return img;
                    }
                },
                { label: 'First Name', name: 'FirstName', width: 200,  valign:"middle"},
                { label: 'Last Name', name: 'LastName', width: 200, },
                { label: 'Specialist', name: 'SpecialistDesc', width: 200, },

            ],
            rownumbers: true,
            viewrecords: true,
            rowNum: 5,
            rowList: [5, 10, 15, 20, 25],
            //editurl: relativepath + "Material/MaterialManipulation",
            pager: gridpager,
            caption: "Doctor List",
            onSelectRow: function (id, status) {

                var gridRow = $(this).getRowData(id);
                var doctorname = gridRow.FirstName + " " + gridRow.LastName;
                $('#DoctorId').val(gridRow.DoctorDetailId);
                $('#ConsultingDoctor').val(doctorname);
                //$('#DoctorModalPopup').empty();
                $('#DoctorModalPopup').modal('toggle');

            }
        });
        $(grid).jqGrid('navGrid', gridpager, { edit: false, add: false, del: false, refresh: true, search: false },

            {},
            {},
            {},
            {},
            {}
        );

    }

  
});

function GetAppointmentDetails(date) {

    $.ajax({
        url: relativepath + '/Appointment/GetAppointmentTimeDetailByDate?date=' + date,
        type: "GET",
        success: function (result) {
            console.log(result);
            $("[id*='spnRbl_']").show();
            $.each(result, function (index, value) {
                $("[id='spnRbl_" + value + "']").hide();
            });
        },
    });
}