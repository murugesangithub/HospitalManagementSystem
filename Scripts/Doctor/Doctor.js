﻿
$(document).ready(function () {

    var grid = "#jqDoctorGrid";
    var gridpager = "#jqDoctorGridPager";

    var bodyElem = $('body');

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
            { label: 'First Name', name: 'FirstName', width: 200, },
            { label: 'Last Name', name: 'LastName', width: 200, },

               { label: 'Hospital Name', name: 'HospitalNameDesc', width: 200, hidden: true, },
            { label: 'HospitalName', name: 'HospitalNameDesc', width: 200, },

            //{ label: 'Mobile No', name: 'MobileNo', width: 200, },
            //{ label: 'Gender', name: 'Gender', width: 200, hidden: true, },
            //{ label: 'Gender', name: 'GenderDesc', width: 200, },
            //{ label: 'State', name: 'State', width: 200, hidden: true, },
            //{ label: 'State', name: 'StateDesc', width: 200, },
            //{ label: 'City', name: 'City', width: 200, hidden: true, },
            //{ label: 'City', name: 'CityDesc', width: 200, },
            //{ label: 'Specialist', name: 'Specialist', width: 200, hidden: true, },
            { label: 'Specialist', name: 'SpecialistDesc', width: 200, },


        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "Doctor List",

        ondblClickRow: function (rowId) {
            var rowData = $(grid).jqGrid("getRowData", rowId);
            ShowDoctorDetailPopup(rowData.DoctorDetailId, rowData.EncryptDoctorDetailId);
        }
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


    //icon


    $(grid).jqGrid('navButtonAdd', gridpager,
        {
            caption: "", buttonicon: "glyphicon glyphicon glyphicon-zoom-in", title: "Doctor Details",
            onClickButton: function () {
                var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                if (selRowId == null) {
                    $.jgrid.info_dialog('Warning', 'Please, select row', '', { styleUI: 'Bootstrap' });
                } else {
                    var rowData = $(grid).jqGrid("getRowData", selRowId);
                    ShowDoctorDetailPopup(rowData.DoctorDetailId, rowData.EncryptDoctorDetailId);
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


function ShowDoctorDetailPopup(DoctorDetailId, EncryptDoctorDetailId) {

    $('#DoctorDetailModalPopup').modal();
    $.ajax({
        url: relativepath + '/Doctor/GetDoctorDetail?id=' + EncryptDoctorDetailId,
        type: "GET",
        success: function (res) {
            console.log(res);
            var title = res.FirstName + " " + res.LastName;
            $('#ProfileTitle').text(title);
            $('#ProfileImage').attr('src', res.ProfileImage);
            $('#FirstName').val(res.FirstName);
            $('#LastName').val(res.LastName);
            $('#Email').val(res.Email);
            $('#HospitalName').val(res.HospitalNameDesc);
            $('#Gender').val(res.GenderDesc);
            $('#State').val(res.StateDesc);
            $('#City').val(res.CityDesc);
            $('#Specialistin').val(res.SpecialistDesc);
            $('#MobileNo').val(res.MobileNo);
            $('#Address').val(res.Address);
           

            if (res.ProfileImage == "") {
                $('#ProfileImage').attr('src', relativepath + "Images/default_profile.jpg");
            }
            
            //  alert(result);
        },
        error: function (err) {
            Notify_Validation(err.statusText);
        }
    });

}

$('#btnDoctorDetailModalPopupClose').click(function () {
    $('#DoctorDetailModalPopup').empty();

});