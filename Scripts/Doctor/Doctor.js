
$(document).ready(function () {

    var grid = "#jqDoctorGrid";
    var gridpager = "#jqDoctorGridPager";

    var bodyElem = $('.content-wrapper');
    new ResizeSensor(bodyElem, function () {
        var bodyElemWidth = Math.round($('.content-wrapper').width());
        var newGridWidth = bodyElemWidth - 25;
        $(grid).jqGrid("setGridWidth", newGridWidth, true);
        $('.ui-jqgrid-bdiv').css('overflow', 'hidden');
    });


    $(grid).jqGrid({
        url: relativepath + "Doctor/GetDoctorList",
        mtype: "POST",
        styleUI: 'Bootstrap',
        datatype: "json",
        height: 'auto',
        jsonReader: jsonreader,
        colModel: [

            { label: 'DoctorDetailId', name: 'DoctorDetailId', key: true, width: 200, hidden: true, },
            { label: 'EncryptDoctorDetailId', name: 'EncryptDoctorDetailId', key: true, width: 200, hidden: true, },
            { label: 'FirstName', name: 'FirstName', width: 200, },
            { label: 'LastName', name: 'LastName', width: 200, },

            { label: 'Email', name: 'Email', width: 200, },

            { label: 'Address', name: 'Address', width: 200, },

            { label: 'MobileNo', name: 'MobileNo', width: 200, },
            { label: 'Gender', name: 'Gender', width: 200, hidden: true, },
            { label: 'GenderDesc', name: 'GenderDesc', width: 200, },
            { label: 'State', name: 'State', width: 200, hidden: true, },
            { label: 'StateDesc', name: 'StateDesc', width: 200, },
            { label: 'City', name: 'City', width: 200, hidden: true, },
            { label: 'CityDesc', name: 'CityDesc', width: 200, },
            { label: 'Specialist', name: 'Specialist', width: 200, hidden: true, },
            { label: 'SpecialistDesc', name: 'SpecialistDesc', width: 200, },


        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "Doctor List"
    });
    $(grid).jqGrid('navGrid', gridpager, { edit: false, add: false, del: true, refresh: true, search: false },

        {},
        {},
        {
            url: relativepath + "Doctor/Delete",
            closeOnEscape: true,
            reloadAfterSubmit: true,
            closeAfterDel: true,
            recreateFrom: true,

            delData: {
                DoctorDetailId: function () {
                    var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    return rowData.DoctorDetailId;
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
                window.location = relativepath + "Doctor/Add";
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
                    window.location = relativepath + "Doctor/UpdateDoctorDetail?id=" + rowData.EncryptDoctorDetailId;
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
