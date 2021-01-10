$(function () {

    //$.datepicker.setDefaults($.datepicker.regional['tr']);

    //Date picker
    $('.datepicker').datepicker({
        autoclose: true,
        language: "tr",
        firstDay: 1,
        format: 'dd-mm-yyyy',  // Date Format used

    })

    $('.select2').select2()


})

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





function makeSelect2(selector, url) {
    $(selector).select2({
        //geri açılacak
        //minimumInputLength: 2,
        allowClear: true,
        ajax: {
            url: url,
            dataType: 'json',
            type: 'Get',
            data: function (params) {
                return {
                    q: params.term
                };
            },
            processResults: function (data, params) {
                return {
                    results: data.items
                }
            },
        },
        language: {
            inputTooShort: function (args) {
                // args.minimum is the minimum required length
                // args.input is the user-typed text
                return (args.minimum - args.params.term.length) + " karakter daha giriniz.";
            },
            inputTooLong: function (args) {
                // args.maximum is the maximum allowed length
                // args.input is the user-typed text
                return "You typed too much";
            },
            errorLoading: function () {
                return "Sonuçlar alınırken hata oluştu!";
            },
            loadingMore: function () {
                return "Sonuçlar yükleniyor.";
            },
            noResults: function () {
                return "Sonuç bulunamadı.";
            },
            searching: function () {
                return "Aranıyor...";
            },
            maximumSelected: function (args) {
                // args.maximum is the maximum number of items the user may select
                return "Error loading results";
            }
        }

    })

}


function makeModelSelect2(selector, url, markaSelector) {
    console.log("selector", selector, "url", url, "markaSelector", markaSelector);
    $(selector).select2({
        //geri açılacak
        //minimumInputLength: 2,
        allowClear: true,
        ajax: {
            url: url,
            dataType: 'json',
            type: 'Get',
            data: function (params) {
                console.log(params.term, $(markaSelector).val());
                return {
                    q: params.term,
                    markaId: $(markaSelector).val()
                };
            },
            processResults: function (data, params) {
                return {
                    results: data.items
                }
            },
        },
        language: {
            inputTooShort: function (args) {
                // args.minimum is the minimum required length
                // args.input is the user-typed text
                return (args.minimum - args.params.term.length) + " karakter daha giriniz.";
            },
            inputTooLong: function (args) {
                // args.maximum is the maximum allowed length
                // args.input is the user-typed text
                return "You typed too much";
            },
            errorLoading: function () {
                return "Sonuçlar alınırken hata oluştu!";
            },
            loadingMore: function () {
                return "Sonuçlar yükleniyor.";
            },
            noResults: function () {
                return "Sonuç bulunamadı.";
            },
            searching: function () {
                return "Aranıyor...";
            },
            maximumSelected: function (args) {
                // args.maximum is the maximum number of items the user may select
                return "Error loading results";
            }
        }

    })

}
