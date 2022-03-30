
$(document).ready(function () {

    var grid = "#jqPatientInquiryGrid";
    var gridpager = "#jqPatientInquiryGridPager";

    var bodyElem = $('.content-wrapper');
    new ResizeSensor(bodyElem, function () {
        var bodyElemWidth = Math.round($('.content-wrapper').width());
        var newGridWidth = bodyElemWidth - 25;
        $(grid).jqGrid("setGridWidth", newGridWidth, true);
        $('.ui-jqgrid-bdiv').css('overflow', 'hidden');
    });


    $(grid).jqGrid({
        url: relativepath + "PatientInquiry/GetPatientInquiryList",
        mtype: "POST",
        styleUI: 'Bootstrap',
        datatype: "json",
        height: 'auto',
        jsonReader: jsonreader,
        colModel: [

            { label: 'PatienId', name: 'PatientId', key: true, width: 100, hidden: true, },
            { label: 'EncryptPatientId', name: 'EncryptPatientId', hidden: true, },
            { label: 'First Name', name: 'FirstName', width: 200, },
            { label: 'Last Name', name: 'LastName', width: 200, },
            { label: 'Gender', name: 'Gender', width: 200, hidden: true, },
            { label: 'Gender', name: 'GenderDescription', width: 200, },
            { label: 'Age', name: 'Age', width: 200, },
            { label: 'Guardian Name', name: 'GuardianName', width: 200, },
            { label: 'DOB', name: 'DateofBirth', width: 200, },
            { label: 'Problem', name: 'Problem', width: 200, },
            { label: 'Email', name: 'Email', width: 200, },
            { label: 'Phone Number', name: 'PhoneNumber', width: 200, },
            { label: 'Address', name: 'Address', width: 200, },
            { label: 'City', name: 'City', width: 200, },
            { label: 'Postal Code', name: 'PostalCode', width: 200, },
            { label: 'State', name: 'State', width: 200, },
            { label: 'Country', name: 'Country', width: 200, hidden: true, },
            { label: 'Country', name: 'CountryDesc', width: 200, },
            { label: 'Height', name: 'Height', width: 200, },
            { label: 'Weight', name: 'Weight', width: 200, },
            { label: 'Diabetes', name: 'Diabetes', width: 200, },
            { label: 'Cancer', name: 'Cancer', width: 200, },
            { label: 'Smoke', name: 'Doyousmoke', width: 200, },
            { label: 'Alchocol', name: 'Doyoudrinkalchocol', width: 200, },
            { label: 'Thyroid Problems', name: 'ThyroidProblems', width: 200, },
            { label: 'Heart problems', name: 'HeartProblems', width: 200, },
            { label: 'Lung Problems', name: 'LungProblems', width: 200, },
            { label: 'Blood Pressure Problems', name: 'BloodPressureProblems', width: 200, },
            { label: 'Kidney or Liver Problems', name: 'KidneyorLiverProblems', width: 200, },
            { label: ' Medical Conditions', name: 'MedicalConditions', width: 200, },
            { label: ' Allergy', name: 'Allergy', width: 200, },
            { label: 'Last Dose ', name: 'Lastdose', width: 200, },


        ],
        rownumbers: true,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        //editurl: relativepath + "Material/MaterialManipulation",
        pager: gridpager,
        caption: "PatientInquiry List"
    });
    $(grid).jqGrid('navGrid', gridpager, { edit: false, add: false, del: true, refresh: true, search: false },

        {},
        {},
        {
            url: relativepath + "PatientInquiry/Delete",
            closeOnEscape: true,
            reloadAfterSubmit: true,
            closeAfterDel: true,
            recreateFrom: true,

            delData: {
                patientId: function () {
                    var selRowId = $(grid).jqGrid('getGridParam', 'selrow');
                    var rowDatas = $(grid).jqGrid("getRowData", selRowId);
                    return rowDatas.PatientId;
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
                window.location = relativepath + "PatientInquiry/Add";
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
                    window.location = relativepath + "PatientInquiry/UpdatePatientInquiryDetail?id=" + rowData.EncryptPatientId;
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