
$(document).ready(function () {

    var grid = "#jqPurchaseMedicineGrid";
    var gridpager = "#jqPurchaseMedicineGridPager";

    var bodyElem = $('body');
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

            { label: 'MedicineId', name: 'MedicineId', key: true, width: 200, hidden: true, },
            { label: 'EncryptMedicineId', name: 'EncryptMedicineId', hidden: true, },
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
            { label: 'Payment', name: 'PaymentType', width: 200, },
            { label: 'PaymentStatusMethod', name: 'PaymentStatusMethod', width: 200, hidden: true, },
            { label: 'Payment Status', name: 'PaymentStatus', width: 200, },



        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "Purchase Medicine List"
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
                MedicineId: function () {
                    var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    return rowData.MedicineId;
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
                    window.location = relativepath + "PurchaseMedicine/UpdatePurchaseMedicine?id=" + rowData.EncryptMedicineId;
                }
            }
        });



    //icon

    $(grid).jqGrid('navButtonAdd', gridpager,
        {
            caption: "", buttonicon: "glyphicon glyphicon glyphicon-zoom-in", title: "PurchaseMedicine Details",
            onClickButton: function () {
                var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                if (selRowId == null) {
                    $.jgrid.info_dialog('Warning', 'Please, select row', '', { styleUI: 'Bootstrap' });
                } else {
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    ShowPurchaseMedicineDetailPopup(rowData.MedicineId, rowData.EncryptMedicineId);
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

function ShowPurchaseMedicineDetailPopup(MedicineId, EncryptMedicineId) {

    $('#PurchaseMedicineDetailModalPopup').modal();
    $.ajax({
        url: relativepath + '/PurchaseMedicine/GetPurchaseMedicineDetail?id=' + EncryptMedicineId,
        type: "GET",
        success: function (res) {
            console.log(res);
            var title = res.SupplierName;
            $('#ProfileTitle').text(title);
            
            $('#SupplierName').val(res.SupplierName);
            $('#Code').val(res.Code);
            $('#Date').val(res.Date);
            $('#Category').val(res.CategoryDesc);
            $('#Medicine').val(res.MedicineDesc);
            $('#Quantity').val(res.Quantity);
            $('#Notes').val(res.Notes);
            $('#Discount').val(res.Discount);
            $('#GrandTotal').val(res.GrandTotal);
            $('#Payment').val(res.PaymentMethod);
            $('#PaymentStatus').val(res.PaymentStatusMethod);
            
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

$('#btnPurchaseMedicineDetailModalPopupClose').click(function () {
    $('#PurchaseMedicineDetailModalPopup').empty();

});