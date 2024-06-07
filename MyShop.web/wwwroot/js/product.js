var prodtble;
$(document).ready(function () {
    loaddata();
});

function loaddata() {
    prodtble = $("#prodtable").DataTable({
        layout: {
            topStart: {
                buttons: ['copy', 'csv', 'excel', 'pdf', 'print']
            }
        },
        "ajax": {
            "url": "/Admin/Products/GetData"
        },

        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <a href="Admin/Products/Edit/${data}" class="btn-success">Edit</a>
                    <a onClick=DeleteItem("/Admin/Products/DeleteProduct/${data}") class="btn-danger">Delete</a>
                    <a href="Admin/Products/Details/${data}" class="btn-info">Details</a>
                    
                    `

                }

            }
        ]
    });
}

function DeleteItem(url) {
    Swal.fire({
        title: "Are you sure to Delete this item ?",
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
                type: "Delete",
                success: function (data) {
                    if (data.success) {
                        prodtble.ajax.reload();
                        toaster.success(data.message);
                    } else {
                        toaster.error(data.message);
                    }
                }
            });
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });
}



