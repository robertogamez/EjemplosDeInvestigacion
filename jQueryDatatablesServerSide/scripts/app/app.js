/// <reference path="../jquery-1.10.2.js" />
/// <reference path="../DataTables/jquery.dataTables.js" />
$(function () {

    var table = $('#example').DataTable({
        "processing": true,
        "serverSide": true,
        "info": true,
        "stateSave": true,
        "searching": true,
        "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
        "ajax": {
            "url": "/Home/GetData",
            "type": "POST"
        },
        "columns": [
                {
                    'render': function (el, type, data) {

                        console.log(data);

                        var $check = $('<input />')
                            .attr('type', 'checkbox')
                            .attr('name', 'id[]')
                            .attr('checked', data.Login);

                        return $check.get(0).outerHTML;
                    }
                },
                { "data": "Name", searchable: true },
                { "data": "Age" },
                { "data": "DoB", searchable: true }
        ],
        "order": [[0, "asc"]]
    });


    $('#btnUpdate').on('click', function () {
        //var table = $('#example').DataTable();
        table.ajax.reload();
    });

    $('#example tbody').on('change', 'input[type="checkbox"]', function () {
        alert('Check click!');
        var $dataRow = $(this).closest('tr');
        console.log($dataRow);
        console.log(table.row($dataRow).data());
    });

    //$('#example tbody').on('click', 'tr', function () {
    //    alert(table.row(this).data());
    //    console.log($(this));
    //    console.log(table.row(this).data());
    //});

});