
$(document).ready(function () {

    var grid = "#jqAppointmentGrid";
    var gridpager = "#jqAppointmentGridPager";

    var bodyElem = $('body');

    new ResizeSensor(bodyElem, function () {
        var bodyElemWidth = Math.round($('.content-wrapper').width());
        var newGridWidth = bodyElemWidth - 25;
        $(grid).jqGrid("setGridWidth", newGridWidth, true);
        $('.ui-jqgrid-bdiv').css('overflow', 'hidden');
    });


    $(grid).jqGrid({
        url: relativepath + "Appointment/GetAppointmentList",
        mtype: "POST",
        styleUI: 'Bootstrap',
        datatype: "json",
        height: 'auto',
        jsonReader: jsonreader,
        colModel: [

            { label: 'Token Number', name: 'TokenNumber', key: true, width: 100, hidden: true, },
            { label: 'EncryptTokenNumber', name: 'EncryptTokenNumber', hidden: true, },

            { label: 'First Name', name: 'FirstName', width: 200, },
            { label: 'Last Name', name: 'LastName', width: 200, },
            { label: 'Gender', name: 'Gender', width: 200,hidden:true, },
            { label: 'Gender ', name: 'GenderDescription', width: 200, },
            { label: 'Age', name: 'Age', width: 200, },        
            { label: 'DOB', name: 'DateofBirth', width: 200, },
            { label: 'Problem', name: 'Problem', width: 200, },
            { label: 'Email', name: 'Email', width: 200, },
            { label: 'Phone Number', name: 'PhoneNumber', width: 200, },
            { label: 'Appointment Date', name: 'DateofAppointment', width: 200, },
            { label: 'Address', name: 'Address', width: 200, },
            { label: 'ConsultingDoctor', name: 'ConsultingDoctor', width: 200, },
            { label: 'TimeSlot', name: 'TimeSlot', width: 200, hidden: true, },
            { label: 'TimeSlot', name: 'TimeSlotDesc', width: 200, },
            { label: 'Department', name: 'Department', width: 200, hidden: true, },
            { label: 'Department', name: 'DepartmentDesc', width: 200, },
        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "Appointment List"
    });
    $(grid).jqGrid('navGrid', gridpager, { edit: false, add: false, del: true, refresh: true, search: false },

        {},
        {},
        {
            url: relativepath + "Appointment/Delete",
            closeOnEscape: true,
            reloadAfterSubmit: true,
            closeAfterDel: true,
            recreateFrom: true,

            delData: {
                tokenNumber: function () {
                    var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    return rowData.TokenNumber;
                }
            }
        },
        {},
        {}
    );

    $(grid).jqGrid('navButtonAdd', gridpager,
        {
            caption: "", buttonicon: "glyphicon glyphicon-plus", title: "Add new row",
            onClickButton: function () {
                window.location = relativepath + "Appointment/Add";
            },

        });
    $(grid).jqGrid('navButtonAdd', gridpager,
        {
            caption: "", buttonicon: "glyphicon glyphicon-edit", title: "Edit selected row",
            onClickButton: function () {
                var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                if (selRowId == null) {
                    $.jgrid.info_dialog('Warning', 'Please, select row', '', { styleUI: 'Bootstrap' });
                } else {
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    window.location = relativepath + "Appointment/UpdateAppointmentDetail?id=" + rowData.EncryptTokenNumber;
                }
            }
        });


    //icon

    $(grid).jqGrid('navButtonAdd', gridpager,
        {
            caption: "", buttonicon: "glyphicon glyphicon glyphicon-zoom-in", title: "Appointment Details",
            onClickButton: function () {
                var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                if (selRowId == null) {
                    $.jgrid.info_dialog('Warning', 'Please, select row', '', { styleUI: 'Bootstrap' });
                } else {
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    ShowAppointmentDetailPopup(rowData.TokenNumber, rowData.EncryptTokenNumber);
                }
            }
        });




    $(grid).jqGrid('filterToolbar', {
        stringResult: true,
        searchOnEnter: false,
        defaultSearch: "cn",
        beforeSearch: function () {
            modifySearchingFilter.call(this, ' ');
        }
    });
});



//icon

function ShowAppointmentDetailPopup(TokenNumber, EncryptTokenNumber)
{

    $('#AppointmentDetailModalPopup').modal();
    $.ajax({
        url: relativepath + '/Appointment/GetAppointmentDetail?id=' + EncryptTokenNumber,
        type: "GET",
        success: function (res) {
            console.log(res);
            var title = res.FirstName + " " + res.LastName;
            $('#ProfileTitle').text(title);
            //$('#ProfileImage').attr('src', res.ProfileImage);
            $('#FirstName').val(res.FirstName);
            $('#LastName').val(res.LastName);
            $('#Email').val(res.Email);
            $('#Gender').val(res.GenderDescription);
            $('#Age').val(res.Age);
            $('#DateofAppointment').val(res.DateofAppointment);
            $('#DateofBirth').val(res.DateofBirth);
            $('#Problem').val(res.Problem);
            $('#PhoneNumber').val(res.PhoneNumber);
            $('#Address').val(res.Address);
            $('#ConsultingDoctor').val(res.ConsultingDoctor);
            $('#TimeSlot').val(res.TimeSlotDesc);
            $('#Department').val(res.DepartmentDesc);
            
            //if (res.ProfileImage == "") {
            //    $('#ProfileImage').attr('src', relativepath + "Images/default_profile.jpg");
            //}
            
            //  alert(result);
        },
        error: function (err) {
            Notify_Validation(err.statusText);
        }
    });

}

$('#btnAppointmentDetailModalPopupClose').click(function () {
    $('#AppointmentDetailModalPopup').empty();

});