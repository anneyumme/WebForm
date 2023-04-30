$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        ajax: { url: '/admin/product/getall' },
        columns: [
            { data: 'id' },
            { data: 'model' },
            { data: 'description' },
            { data: 'price' },
            { data: 'name' },
            { data: 'brand.name' },
        ],
        searching: false,
        responsive: true
    });
}