var dataTable;
$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else {
        if (url.includes("completed")) {
            loadDataTable("completed");
        }
        else {
            if (url.includes("approved")) {
                loadDataTable("approved");
            }
            else {
                if (url.includes("pending")) {
                    loadDataTable("pending");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
    }
    });

function loadDataTable(status) {
    dataTable = $('#myTable').DataTable({
        ajax: { url: '/admin/order/getall?Status=' + status },
        columns: [
            { data: 'id' },
            { data: 'name' },
            { data: 'phoneNumber', width: "20%" },
            { data: 'applicationUser.email' },
            { data: 'orderCreate' },
            { data: 'orderTotal' },
            { data: 'orderStatus' },
            { data: 'paymentStatus' },
            { data: 'paymentType' },

            {
                data: 'id',
                render: function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/order/Details?Orderid=${data}" class="btn btn-primary mx-2" style="border-radius:8px">
                            <i class="bi bi-pencil-square"></i>
						</a>                      
                          </div>`
                },
                width: "40%"
            }
        ],

        //searching: false,
        //responsive: true
    });
}

function sendForm(event) {
    event.preventDefault();
    Swal.fire({
        title: 'Do you want to be sure to order?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, order it!'
    }).then((result) => {
        if (result.isConfirmed) {
            const myForm = document.getElementById('myForm');
            myForm.submit();         
        }
    })
}
