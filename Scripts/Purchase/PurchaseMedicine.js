
$(document).ready(function () {

    var grid = "#jqPurchaseMedicineGrid";
    var gridpager = "#jqPurchaseMedicineGridPager";

    var bodyElem = $('.content-wrapper');
    new ResizeSensor(bodyElem, function () {
        var bodyElemWidth = Math.round($('.content-wrapper').width());
        var newGridWidth = bodyElemWidth - 25;
        $(grid).jqGrid("setGridWidth", newGridWidth, true);
        $('.ui-jqgrid-bdiv').css('overflow', 'hidden');
    });


    $(grid).jqGrid({
        url: relativepath + "PurchaseMedicine/GetPurchaseMedicineList",
        mtype: "POST",
        styleUI: 'Bootstrap',
        datatype: "json",
        height: 'auto',
        jsonReader: jsonreader,
        colModel: [

            { label: 'PurchaseMedicineId', name: 'PurchaseMedicineId', key: true, width: 200, hidden: true, },
            { label: 'EncryptPurchaseMedicineId', name: 'EncryptPurchaseMedicineId', hidden: true, },
            { label: 'Supplier Name', name: 'SupplierName', width: 200, },
            { label: 'Code', name: 'Code', width: 200, },
            { label: 'Date', name: 'Date', width: 200, },

            { label: 'CategoryDesc', name: 'CategoryDesc', width: 200, hidden: true, },
            { label: 'Category', name: 'Category', width: 200, },
            { label: 'MedicineDesc', name: 'MedicineDesc', width: 200, hidden: true, },
            { label: 'Medicine', name: 'Medicine', width: 200, },

            { label: 'Quantity', name: 'Quantity', width: 200, },
            { label: 'Notes', name: 'Notes', width: 200, },
            { label: 'Discount', name: 'Discount', width: 200, },
            { label: 'Grand Total', name: 'GrandTotal', width: 200, },
            { label: 'PaymentDesc', name: 'PaymentDesc', width: 200, hidden: true, },
            { label: 'Payment', name: 'Payment', width: 200, },
            { label: 'PaymentStatusMethod', name: 'PaymentStatusMethod', width: 200, hidden: true, },
            { label: 'Status', name: 'Status', width: 200, },



        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "PurchaseMedicine List"
    });
    $(grid).jqGrid('navGrid', gridpager, { edit: false, add: false, del: true, refresh: true, search: false },

        {},
        {},
        {
            url: relativepath + "PurchaseMedicine/Delete",
            closeOnEscape: true,
            reloadAfterSubmit: true,
            closeAfterDel: true,
            recreateFrom: true,

            delData: {
                PatientAdmissionId: function () {
                    var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    return rowData.PurchaseMedicineId;
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
                window.location = relativepath + "PurchaseMedicine/Purchase";
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
                    window.location = relativepath + "PurchaseMedicine/UpdatePurchaseMedicine?id=" + rowData.EncryptPurchaseMedicineId;
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
