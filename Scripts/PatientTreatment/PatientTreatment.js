

$(document).ready(function () {

    var grid = "#jqPatientTreatmentGrid";
    var gridpager = "#jqPatientTreatmentGridPager";

    var bodyElem = $('body');

    new ResizeSensor(bodyElem, function () {
        var bodyElemWidth = Math.round($('.content-wrapper').width());
        var newGridWidth = bodyElemWidth - 25;
        $(grid).jqGrid("setGridWidth", newGridWidth, true);
        $('.ui-jqgrid-bdiv').css('overflow', 'hidden');
    });


    $(grid).jqGrid({
        url: relativepath + "PatientTreatment/GetPatientTreatmentList",
        mtype: "POST",
        styleUI: 'Bootstrap',
        datatype: "json",
        height: 'auto',
        jsonReader: jsonreader,
        colModel: [

            { label: 'PatientId', name: 'PatientId', key: true, width: 100, hidden: true, },
            { label: 'EncryptPatientId', name: 'EncryptPatientId', hidden: true, },
            { label: 'Patient Name', name: 'PatientName', width: 200, },
            { label: 'Medicine Name', name: 'MedicineName', width: 200, hidden: true, },
            { label: 'Medicine Name', name: 'MedicineNameDescription', width: 200, },
            { label: 'Quantity', name: 'Quantity', width: 200, },
            { label: 'Dosage Description ', name: 'DosageDesc', width: 200, },
        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "Patient Treatment List"
    });

    //delete


    $(grid).jqGrid('navGrid', gridpager, { edit: false, add: false, del: true, refresh: true, search: false },

        {},
        {},
        {
            url: relativepath + "PatientTreatment/Delete",
            closeOnEscape: true,
            reloadAfterSubmit: true,
            closeAfterDel: true,
            recreateFrom: true,

            delData: {
                patientId: function () {
                    var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    return rowData.PatientId;
                }
            }
        },
        {},
        {}
    );

    //Add

    $(grid).jqGrid('navButtonAdd', gridpager,
        {
            caption: "", buttonicon: "glyphicon glyphicon-plus", title: "Add new row",
            onClickButton: function () {
                window.location = relativepath + "PatientTreatment/Add";
            },

        });

    //update

    $(grid).jqGrid('navButtonAdd', gridpager,
        {
            caption: "", buttonicon: "glyphicon glyphicon-edit", title: "Edit selected row",
            onClickButton: function () {
                var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                if (selRowId == null) {
                    $.jgrid.info_dialog('Warning', 'Please, select row', '', { styleUI: 'Bootstrap' });
                } else {
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    window.location = relativepath + "PatientTreatment/UpdatePatientTreatmentDetail?id=" + rowData.EncryptPatientId;
                }
            }
        });




    //icon

    $(grid).jqGrid('navButtonAdd', gridpager,
        {
            caption: "", buttonicon: "glyphicon glyphicon glyphicon-zoom-in", title: "Patient Treatment Details",
            onClickButton: function () {
                var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                if (selRowId == null) {
                    $.jgrid.info_dialog('Warning', 'Please, select row', '', { styleUI: 'Bootstrap' });
                } else {
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    ShowPatientTreatmentDetailPopup(rowData.PatientId, rowData.EncryptPatientId);
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


function ShowPatientTreatmentDetailPopup(PatienId, EncryptPatientId) {

    $('#PatientTreatmentDetailModalPopup').modal();
    $.ajax({
        url: relativepath + '/PatientTreatment/GetPatientTreatmentDetail?id=' + EncryptPatientId,
        type: "GET",
        success: function (res) {
            console.log(res);
            var title = res.PatientName ;
            $('#ProfileTitle').text(title);
            //$('#ProfileImage').attr('src', res.ProfileImage);
            $('#PatientName').val(res.PatientName);
            $('#MedicineName').val(res.MedicineNameDescription);
            $('#Quantity').val(res.Quantity);
            $('#DosageDesc').val(res.DosageDesc);
            $('#Remarks').val(res.Remarks);
            $('#RoomNumber').val(res.RoomNumberDescription);
            $('#RoomType').val(res.RoomTypeDescription);
            $('#NoofDays').val(res.Noofdays);
            $('#RoomPrice').val(res.RoomPrice);
          
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

$('#btnPatientTreatmentDetailModalPopupClose').click(function () {
    $('#PatientTreatmentDetailModalPopup').empty();

});