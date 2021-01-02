
function makeDatatable(selector, url, columns, drawCallback) {
    $(selector).DataTable({
        "ajax": {
            "url": url,
            "type": "POST",
            "datatype": "json",
        },
        "order": [],
        "columns": columns,
        "serverSide": "true",
        "order": [0, "asc"],
        "processing": "true",
        "buttons": [
            'copy', 'excel', 'pdf'
        ],
        //"columnDefs": columnDefs,
        //dom: 'lrtip',
        "language": {
            "decimal": "",
            "emptyTable": "Veri yok",
            "info": "_TOTAL_ kayıt içinden _START_ - _END_ arası gösteriliyor",
            "infoEmpty": "0 Kayıt",
            "infoFiltered": "(_MAX_ toplam kayıttan filtrelendi)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "_MENU_",
            "loadingRecords": "Yükleniyor...",
            "processing": "İşleniyor...",
            "search": "Ara:",
            "zeroRecords": "Sonuç Bulunamadı",
            "paginate": {
                "first": "İlk",
                "last": "Son",
                "next": "Sonraki",
                "previous": "Önceki"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        },
        "drawCallback": function (settings) {
            drawCallback();
        }

    });
}