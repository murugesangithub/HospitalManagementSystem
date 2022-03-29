

$(document).ready(function () {

    var grid = "#jqBillingGrid";
    var gridpager = "#jqBillingGridPager";

    var bodyElem = $('.content-wrapper');
    new ResizeSensor(bodyElem, function () {
        var bodyElemWidth = Math.round($('.content-wrapper').width());
        var newGridWidth = bodyElemWidth - 25;
        $(grid).jqGrid("setGridWidth", newGridWidth, true);
        $('.ui-jqgrid-bdiv').css('overflow', 'hidden');
    });


    $(grid).jqGrid({
        url: relativepath + "Billing/GetBillingList",
        mtype: "POST",
        styleUI: 'Bootstrap',
        datatype: "json",
        height: 'auto',
        jsonReader: jsonreader,
        colModel: [
            { label: 'PatientId', name: 'PatientId', key: true, width: 100, hidden: true, },
            { label: 'EncryptPatientId', name: 'EncryptPatientId', hidden: true, },
            { label: 'Patient Name', name: 'PatientName', width: 200, },
            { label: 'Department', name: 'DepartmentDesc', width: 200, },
            { label: 'Doctor Name', name: 'DoctorName', width: 200, },
            { label: 'Admit Date', name: 'AdmitDate', width: 200, },
            { label: 'Discharge Date', name: 'DischargeDate', width: 200, },
            { label: 'Service ', name: 'ServiceDesc', width: 200, },
            { label: 'Discount', name: 'Discount', width: 200, },
            { label: 'Total Amount', name: 'TotalAmount', width: 200, },
            { label: 'Payment Method', name: 'PaymentMethod', width: 200, },
            { label: 'Payment Status ', name: 'PaymentStatusMethod', width: 200, },
        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "Billing List"
    });
    $(grid).jqGrid('navGrid', gridpager, { edit: false, add: false, del: true, refresh: true, search: false },

        {},
        {},
        {
            url: relativepath + "Billing/Delete",
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

    $(grid).jqGrid('navButtonAdd', gridpager,
        {
            caption: "", buttonicon: "glyphicon glyphicon-plus", title: "Add new row",
            onClickButton: function () {
                window.location = relativepath + "Billing/Add";
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
                    window.location = relativepath + "Billing/UpdateBillingDetail?id=" + rowData.EncryptPatientId;
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