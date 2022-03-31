
$(document).ready(function () {

    var grid = "#jqPatientGrid";
    var gridpager = "#jqPatientGridPager";

    var bodyElem = $('.content-wrapper');
    new ResizeSensor(bodyElem, function () {
        var bodyElemWidth = Math.round($('.content-wrapper').width());
        var newGridWidth = bodyElemWidth - 25;
        $(grid).jqGrid("setGridWidth", newGridWidth, true);
        $('.ui-jqgrid-bdiv').css('overflow', 'hidden');
    });


    $(grid).jqGrid({
        url: relativepath + "Patients/GetPatientsList",
        mtype: "POST",
        styleUI: 'Bootstrap',
        datatype: "json",
        height: 'auto',
        jsonReader: jsonreader,
        colModel: [

            { label: 'PatientDetailId', name: 'PatientDetailId', key: true, width: 100, hidden: true, },
            { label: 'EncryptPatientDetailId', name: 'EncryptPatientDetailId', hidden: true, },
            

            { label: 'First Name', name: 'FirstName', width: 200, },
            { label: 'Last Name', name: 'LastName', width: 200, },
            { label: 'MaritalStatus', name: 'MaritalStatus', width: 200, hidden: true, },
            { label: 'Marital Status', name: 'MaritalStatusDescription', width: 200, },
            { label: 'Gender', name: 'Gender', width: 200, hidden: true, },
            { label: 'Gender', name: 'GenderDescription', width: 200, },
            { label: 'Age', name: 'Age', width: 200, },
            { label: 'Guardian Name', name: 'GuardianName', width: 200, },
            { label: 'DoB', name: 'DateofBirth', width: 200, },
            { label: 'Problem', name: 'Problem', width: 200, },
            { label: 'Email', name: 'Email', width: 200, },
            { label: 'Phone Number', name: 'PhoneNumber', width: 200, },
            { label: 'Address', name: 'Address', width: 200, },
            { label: 'City', name: 'City', width: 200, },
            { label: 'Postal Code', name: 'PostalCode', width: 200, },
            { label: 'State', name: 'State', width: 200, },
            { label: 'State', name: 'State', width: 200, hidden: true,},
            { label: 'Country', name: 'CountryDesc', width: 200, },

        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "Patient List"
    });
    $(grid).jqGrid('navGrid', gridpager, { edit: false, add: false, del: true, refresh: true, search: false },

        {},
        {},
        {
            url: relativepath + "Patients/Delete",
            closeOnEscape: true,
            reloadAfterSubmit: true,
            closeAfterDel: true,
            recreateFrom: true,

            delData: {
                patientDetailId: function () {
                    var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    return rowData.PatientDetailId;
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
                window.location = relativepath + "Patients/Add";
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
                    window.location = relativepath + "Patients/UpdatePatientDetail?id=" + rowData.EncryptPatientDetailId;
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