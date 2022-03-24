
$(document).ready(function () {

    var grid = "#jqMedicineGrid";
    var gridpager = "#jqMedicineGridPager";

    var bodyElem = $('.content-wrapper');
    new ResizeSensor(bodyElem, function () {
        var bodyElemWidth = Math.round($('.content-wrapper').width());
        var newGridWidth = bodyElemWidth - 25;
        $(grid).jqGrid("setGridWidth", newGridWidth, true);
        $('.ui-jqgrid-bdiv').css('overflow', 'hidden');
    });


    $(grid).jqGrid({
        url: relativepath + "Medicine/GetMedicineList",
        mtype: "POST",
        styleUI: 'Bootstrap',
        datatype: "json",
        height: 'auto',
        jsonReader: jsonreader,
        colModel: [

            { label: 'MedicineId', name: 'MedicineId', key: true, width: 100, hidden: true, },
            { label: 'EncryptMedicineId', name: 'EncryptMedicineId', hidden: true, },           
            { label: 'MedicineName', name: 'MedicineName', width: 200, },         
            { label: 'Category', name: 'Category', width: 200, hidden: true, },
            { label: 'CategoryDesc', name: 'CategoryDesc', width: 200, },
            { label: 'CompanyName', name: 'CompanyName', width: 200, },     
            { label: 'PurchaseDate', name: 'PurchaseDate', width: 200, },
            { label: 'Price', name: 'Price', width: 200, },
            { label: 'ExpiredDate', name: 'ExpiredDate', width: 200, },
            { label: 'Stock', name: 'Stock', width: 200, },

        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "Medicine List"
    });
    $(grid).jqGrid('navGrid', gridpager, { edit: false, add: false, del: true, refresh: true, search: false },

        {},
        {},
        {
            url: relativepath + "Medicine/Delete",
            closeOnEscape: true,
            reloadAfterSubmit: true,
            closeAfterDel: true,
            recreateFrom: true,

            delData: {
                patientDetailId: function () {
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
                window.location = relativepath + "Medicine/Add";
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
                    window.location = relativepath + "Medicine/UpdateMedicineDetail?id=" + rowData.EncryptMedicineId;
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