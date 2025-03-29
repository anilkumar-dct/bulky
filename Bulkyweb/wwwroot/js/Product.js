$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tbltable').DataTable({
        "ajax": {
            url: '/Admin/Products/GetAll', // ✅ Correct URL (case-sensitive)
            type: 'GET',
            dataType: 'json' },
        "columns": [
            { data: 'title' },
            { data: 'author' },
            { data: 'isbn' },
            { data: 'listPrice' },
            { data: 'category.name' },
            {
                data: 'id',
                render: function (data) {
                    return `
                        <div class="w-75 btn-group d-flex justify-content-center">
                            <a class="btn btn-primary rounded-2 btn-sm m-1" href="/Admin/Products/Edit/${data}">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a class="btn btn-danger rounded-2 btn-sm m-1" href="/Admin/Products/Delete/${data}">
                                <i class="bi bi-trash3"></i> Delete
                            </a>
                        </div>
                    `;
                }
            }
        ]
    });
}
//function loadDataTable() {
//    dataTable = $('#myTable').DataTable({
//        "ajax": {
//            "url": "/admin/products/getall",  // ✅ Correct syntax
//            "type": "GET",
//            "datatype": "json"
//        },
//        "columns": [
//            { data: 'name' },
//            { data: 'position' },
//            { data: 'salary' },
//            { data: 'office' }
//        ]
//    });
//}