var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Category/GetAll"
        },
        "columns": [
            {
                "data": "categoryName", "width": "60%"
            },
            {
                "data": "categoryId",
                "render": function (data) {
                    return `
                                    <div class="text-center">
            <a href="/Admin/Category/Edit/${data}" class="btn btn-success text-white" style="cursor: pointer">
                <i class="fas fa-edit"></i>
            </a>
            <a class="btn btn-danger text-white" style="cursor: pointer">
                <i class="fas fa-trash-alt"></i>
            </a>
        </div>
                            `;
                }, "width": "40%"
            }
        ]
    });
}