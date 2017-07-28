$(function () {
    
    $("#jqGrid").jqGrid({
        url: 'GetSuppliers',
        datatype: 'json',
        mtype: 'Get',
        colNames: ['ID', 'Name', 'Address', 'Description', 'MobileNumber'],
        colModel: [
            { key: true, hidden: true, name: 'SupplierId', index: 'SupplierId', editable: true },
            { key: false, name: 'SupplierNmae', index: 'SupplierNmae', editable: true },
            { key: false, name: 'Address', index: 'Address', editable: true },
            { key: false, name: 'Description', index: 'Description', editable: true },
            { key: false, name: 'mobileNumber', index: 'mobileNumber', editable: true }
        ],
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Supplier Records',
        emptyrecords: 'No Supplier Records are Available to Display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#jqControls', { edit: true, add:false, del: true, search: false, refresh: true },
        {
            zIndex: 100,
            url: "Edit",
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete Student... ? ",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });
});
