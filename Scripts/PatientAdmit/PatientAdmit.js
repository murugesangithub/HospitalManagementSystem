
$(document).ready(function () {

    var grid = "#jqPatientAdmitGrid";
    var gridpager = "#jqPatientAdmitGridPager";

    var bodyElem = $('.content-wrapper');
    new ResizeSensor(bodyElem, function () {
        var bodyElemWidth = Math.round($('.content-wrapper').width());
        var newGridWidth = bodyElemWidth - 25;
        $(grid).jqGrid("setGridWidth", newGridWidth, true);
        $('.ui-jqgrid-bdiv').css('overflow', 'hidden');
    });


    $(grid).jqGrid({
        url: relativepath + "PatientAdmission/GetPatientAdmissionList",
        mtype: "POST",
        styleUI: 'Bootstrap',
        datatype: "json",
        height: 'auto',
        jsonReader: jsonreader,
        colModel: [

            { label: 'PatientAdmissionId', name: 'PatientAdmissionId', key: true, width: 200, hidden: true, },
            { label: 'EncryptPatientAdmissionId', name: 'EncryptPatientAdmissionId', hidden: true, },
            { label: 'Doctor Name', name: 'DoctorName', width: 200, },
            { label: 'Admission Date', name: 'AdmissionDate', width: 200, },
            { label: 'Planned Procedure', name: 'PlannedProcedure', width: 200, },

            { label: 'Email', name: 'Email', width: 200, },

            { label: 'Address', name: 'Address', width: 200, },

            { label: 'Item Number', name: 'ItemNumber', width: 200, },
            { label: 'Gender', name: 'Gender', width: 200, },
            { label: 'Patient Name', name: 'PatientName', width: 200, },
            { label: 'State', name: 'State', width: 200, },
            { label: 'DOB', name: 'DateofBirth', width: 200, },
            { label: 'City', name: 'City', width: 200, },
            { label: 'Guardian Name', name: 'GuardianName', width: 200, },
            { label: 'Marital Status', name: 'MaritalStatus', width: 200, },
            { label: 'Patient', name: 'Patient', width: 200, },
            { label: 'Phone Number', name: 'PhoneNumber', width: 200, },
            { label: 'Contact', name: 'Contact', width: 200, },
            { label: 'Postal Code', name: 'PostalCode', width: 200, },



        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "PatientAdmission List"
    });
    $(grid).jqGrid('navGrid', gridpager, { edit: false, add: false, del: true, refresh: true, search: false },

        {},
        {},
        {
            url: relativepath + "PatientAdmission/Delete",
            closeOnEscape: true,
            reloadAfterSubmit: true,
            closeAfterDel: true,
            recreateFrom: true,

            delData: {
                PatientAdmissionId: function () {
                    var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    return rowData.PatientAdmissionId;
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
                window.location = relativepath + "PatientAdmission/PatientAdmit";
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
                    window.location = relativepath + "PatientAdmission/UpdatePatientAdmission?id=" + rowData.EncryptPatientAdmissionId;
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
