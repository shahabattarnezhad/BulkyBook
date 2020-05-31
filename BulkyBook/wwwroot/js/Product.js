var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            {
                "data": "productTitle", "width": "15%"
            },
            {
                "data": "productIsbn", "width": "15%"
            },
            {
                "data": "productPrice", "width": "15%"
            },
            {
                "data": "productAuthor", "width": "15%"
            },
            {
                "data": "category.categoryName", "width": "15%"
            },
            {
                "data": "productId",
                "render": function (data) {
                    return `
                <div class="text-center">
                    <a href="/Admin/Product/Edit/${data}" class="btn btn-success text-white" style="cursor: pointer">
                        <i class="fas fa-edit"></i>
                    </a>

                    <a onclick=Delete("/Admin/Product/Delete/${data}") class="btn btn-danger text-white" style="cursor: pointer">
                        <i class="fas fa-trash-alt"></i>
                    </a>
                </div>
                            `;
                }, "width": "40%"
            }
        ]
    });
}



function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}