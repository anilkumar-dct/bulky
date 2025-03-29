var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tbltable').DataTable({
        "ajax": {
            url: '/Admin/Products/GetAll', // ✅ Correct URL (case-sensitive)
            type: 'GET',
            dataType: 'json'
        },
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
                                
                           <button class="btn btn-danger rounded-2 btn-sm m-1 delete-btn" data-id="${data}">
                    <i class="bi bi-trash3"></i> Delete
                </button>
                        </div>
                    `;
                }
            }
        ]
    });
}
$(document).on('click', '.delete-btn', function () {
    const id = $(this).data('id');
    const url = `/Admin/Products/DeleteWithAlert/${id}`;

    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                },

            });
        }
    });
});

//Not working code
//Reason and solution
/*
========== DELETE FUNCTION FIXES ==========
1. TYPO FIX:
   - Changed 'DeteleWithAlert' to 'DeleteWithAlert'

2. EVENT BINDING:
   - Replaced <a href> with <button> + click handler
   - Used event delegation (.on()) for dynamic elements

3. AJAX IMPROVEMENTS:
   - Added proper success/error handling
   - Reloads DataTable after deletion (dataTable.ajax.reload())

4. CONTROLLER FIXES:
   - Consistent JSON response format
   - Added try-catch for error handling

KEY LESSONS:
- Always check function names for typos
- Use proper event binding for dynamic content
- Never use href for JavaScript actions
- Always refresh UI after data changes
*/
//function DeleleWithAlert(url) {
//    Swal.fire({
//        title: "Are you sure?",
//        text: "You won't be able to revert this!",
//        icon: "warning",
//        showCancelButton: true,
//        confirmButtonColor: "#3085d6",
//        cancelButtonColor: "#d33",
//        confirmButtonText: "Yes, delete it!"
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.ajax({
//                url: url,
//                type: "DELETE",
//                success: function (data) {
//                    if (data.success) {
//                        toastr.success(data.message);
//                        dataTable.ajax.reload(); // Reload the DataTable
//                    } else {
//                        toastr.error(data.message);
//                    }
//                },
//                error: function () {
//                    toastr.error("Error deleting product");
//                }
//            });
//        }
//    });
//}
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