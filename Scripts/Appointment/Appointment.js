
$(document).ready(function () {

    var grid = "#jqAppointmentGrid";
    var gridpager = "#jqAppointmentGridPager";

    var bodyElem = $('.content-wrapper');
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

            { label: 'TokenNumber', name: 'TokenNumber', key: true, width: 100, hidden: true, },
            { label: 'EncryptTokenNumber', name: 'EncryptTokenNumber', hidden: true, },

            { label: 'FirstName', name: 'FirstName', width: 200, },
            { label: 'LastName', name: 'LastName', width: 200, },
            { label: 'Gender', name: 'Gender', width: 200,hidden:true, },
            { label: 'GenderDescription', name: 'GenderDescription', width: 200, },
            { label: 'Age', name: 'Age', width: 200, },        
            { label: 'DateofBirth', name: 'DateofBirth', width: 200, },
            { label: 'Problem', name: 'Problem', width: 200, },
            { label: 'Email', name: 'Email', width: 200, },
            { label: 'PhoneNumber', name: 'PhoneNumber', width: 200, },
            { label: 'DateofAppointment', name: 'DateofAppointment', width: 200, },
            { label: 'Address', name: 'Address', width: 200, },
            { label: 'ConsultingDoctor', name: 'ConsultingDoctor', width: 200, },
            { label: 'TimeSlot', name: 'TimeSlot', width: 200, hidden: true, },
            { label: 'TimeSlotDesc', name: 'TimeSlotDesc', width: 200, },
            { label: 'Department', name: 'Department', width: 200, hidden: true, },
            { label: 'DepartmentDesc', name: 'DepartmentDesc', width: 200, },
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

   
    $(grid).jqGrid('filterToolbar', {
        stringResult: true,
        searchOnEnter: false,
        defaultSearch: "cn",
        beforeSearch: function () {
            modifySearchingFilter.call(this, ' ');
        }
    });
});