$(function () {

    //$.datepicker.setDefaults($.datepicker.regional['tr']);

    //Date picker
    $('.datepicker').datepicker({
        autoclose: true,
        language: "tr",
        firstDay: 1,
        format: 'dd-mm-yyyy',  // Date Format used

    })

    //$('.select2').select2()
})

function readURL(input, targetSelector) {
    $(targetSelector).html("");

    if (input.files) {
        var filesAmount = input.files.length;

        for (i = 0; i < filesAmount; i++) {
            var reader = new FileReader();

            reader.onload = function (event) {
                var img = $('<img class="previewImg" style="max-width:300px;max-height:300px;">');
                img.attr('src', event.target.result);
                img.appendTo(targetSelector);
            }

            reader.readAsDataURL(input.files[i]);
        }
    }
}

function bindPreview(inputSelector, imgSelector) {
    $(inputSelector).change(function () {
        readURL(this, imgSelector);
    });
}
function onVehicleChanged() {
    var selector = "#Arac_ID";
    var url = "/Root/AracDetails";
    var asimucreti_selector = "#arac_asimucreti";

    $(selector).change(function () {
        $.ajax({
            url: url,
            type: "POST",
            data: {
                id: $(selector).val()
            },
            success: function (result) {
                $(asimucreti_selector).html(result.asimucreti)
            }
        });
    });

}

function onCustomerChanged() {
    console.log("1");
    
    var selector = "#Cari_ID";
    var url = "/Root/CariDetails";
    var tckn_selector = "#cari_tckn";
    var telno_selector = "#cari_telno";
    var ehliyetno_selector = "#cari_ehliyetno";
    var mail_selector = "#cari_mail";
    var adres_selector = "#cari_adres";
    var tahsilatlar_selector = "#tahsilatlar"
    $(selector).change(function () {
        console.log("2", selector, $(selector).val());
        $.ajax({
            url: url,
            type: "POST",
            data: {
                id: $(selector).val()
            },
            success: function (result) {
                console.log(result);
                $(tckn_selector).html(result.tckn)
                $(telno_selector).html(result.telno)
                $(ehliyetno_selector).html(result.ehliyetno)
                $(mail_selector).html(result.mail)
                $(adres_selector).html(result.adres)
                $(tahsilatlar_selector).html("")
                if (result.tahsilatlar.length > 0) {
                    $.each(result.tahsilatlar, function (i, item) {
                        var line =
                            $('<tr>').append(
                                $('<td>').text(item.baslangicTarihi),
                                $('<td>').text(item.kiralamaSuresi),
                                $('<td>').text(item.plaka),
                                $('<td>').text(item.kalanBorc)
                            );
                        $(tahsilatlar_selector).append(line);
                    });
                }
            },
            error: function (err) {
                console.log(err);

            }
        });
    });

}

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
    //console.log("makeSelect2", selector,url);
    $(selector).select2({
        //geri açılacak
        //minimumInputLength: 2,
        allowClear: true,
        ajax: {
            url: url,
            dataType: 'json',
            type: 'GET',
            data: function (params) {
                //console.log(params);
                return {
                    q: params.term
                };
            },
            processResults: function (data, params) {
                //console.log(data);
                //console.log(params);
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
