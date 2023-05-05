var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        ajax: { url: '/admin/user/getall' },
        columns: [
            { data: 'fullName', width: "12%" },
            { data: 'email' },
            { data: 'phoneNumber' },
            { data: 'streetAdress', width: "20%" },
            { data: 'role' },
            {
                data: { id: 'id', lockoutEnd: 'lockoutEnd' },        
                render: function (data)
                {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today)
                    {
                        return `<div class="w-75 btn-group" role="group">
                        <a onClick=Lock("/admin/user/LockUnlock?id=${data.id}") class="btn btn-success mx-2" style = "border-radius:8px" >
                            <i class="bi bi-unlock-fill"></i> Unlock
						</a>
                        <a href="/admin/user/Edit?userid=${data.id}" class="btn btn-primary mx-2" style = "border-radius:8px" >
                          <i class="bi bi-pencil-square"></i> Edit
						</a >
                        </div> `
                    }
                    else
                    {
                        return `<div class="w-75 btn-group" role="group">
                        <a onClick=Unlock("/admin/user/LockUnlock?id=${data.id}") class="btn btn-danger mx-2" style = "border-radius:8px" >
                            <i class="bi bi-lock-fill"></i> Lock
						</a>
                        <a href="/admin/user/Edit?userid=${data.id}" class="btn btn-primary mx-2" style = "border-radius:8px" >
                           <i class="bi bi-pencil-square"></i> Edit
						</a>
                        </div>`
                    }
                },
                width: "40%"
            }
        ],

        //searching: false,
        //responsive: true
    });
}

function Unlock(url) {
    $.ajax({
        url: url,
        type: "DELETE",
        success: function (data) {
            dataTable.ajax.reload();
        }
    })
    Swal.fire(
        'Good job!',
        'Unlock account successfully!',
        'success'
    )
}

function Lock(url) {
    $.ajax({
        url: url,
        type: "DELETE",
        success: function (data) {
            dataTable.ajax.reload();
        }
    })
    Swal.fire(
        'Good job!',
        'Lock account successfully',
        'success'
    )
}
