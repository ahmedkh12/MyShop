

var dtble;
$(document).ready(function (){
    loaddata();
});


function loaddata() {
    dtble = $("#cattable").DataTable({
      
        "ajax": {
            "url":"/Admin/Categories/GetData"
        },

        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "createdAdd" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <a href="${window.location.href}/Edit/${data}" class="btn-success">Edit</a>
                    <a href="${window.location.href}/Delete/${data}" class="btn-danger">Delete</a>
                    <a href="${window.location.href}/Details/${data}" class="btn-info">Details</a>
                    
                    `

                }

            }
        ],

        layout: {
            topStart: {
                buttons: ['copy', 'csv', 'excel', 'pdf', 'print']
            }
        },


    });
}

