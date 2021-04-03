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



function assignInputChange(inputSelectors, notEmptyCallback, emptyCallback) {
    $(inputSelectors).each(function (index, item) {
        $(item).on("change paste keyup", function () {
            var empty = true;
            $(inputSelectors).each(function (index, item) {
                //console.log($(item).val());
                if (!$(item).val() || $(item).val().length !== 0) {
                    empty = false;
                }
            })
            if (empty === false) {
                notEmptyCallback()
            }
            else {
                emptyCallback()
            }

        });
    });
}
function displayElementRegardingToInputs(elementSelector, inputSelectors) {
    assignInputChange(
        inputSelectors,
        function () { $(elementSelector).removeClass("madeHidden") },
        function () { $(elementSelector).addClass("madeHidden") }
    )
}
function setValTrueRegardingToInputs(elementSelector, inputSelectors) {
    assignInputChange(
        inputSelectors,
        function () { $(elementSelector).val("true") },
        function () { $(elementSelector).val("false") }
    )
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
    var selector = "#Cari_ID";
    var url = "/Root/CariDetails";
    var tckn_selector = "#cari_tckn";
    var telno_selector = "#cari_telno";
    var ehliyetno_selector = "#cari_ehliyetno";
    var mail_selector = "#cari_mail";
    var adres_selector = "#cari_adres";
    var tahsilatlar_selector = "#tahsilatlar"
    $(selector).change(function () {
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
    $(selector).select2({
        allowClear: true,
        ajax: {
            url: url,
            dataType: 'json',
            type: 'GET',
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

    $(selector).select2({
        //geri açılacak
        //minimumInputLength: 2,
        allowClear: true,
        ajax: {
            url: url,
            dataType: 'json',
            type: 'Get',
            data: function (params) {
                //console.log(params.term, $(markaSelector).val());
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



async function ChangeLocation(aracId) {
    var locationsUrl = '/Root/LokasyonList'
    var changeLocationUrl = '/Arac/ChangeLocation'

    var response = await fetch(locationsUrl);
    var locations = await response.json(); // parses JSON response into native JavaScript objects

    //var select = (`<select class="form-control" id="Lokasyon_ID" ></select>`);
    var select = '<select class="form-control" id="Lokasyon_ID" >'
    locations.items.forEach(value => {
        select += `<option value="${value.id}">${value.text}</option>`
    })
    select += "</select>"

    var title = "Lokasyon Değiştir"
    var modal = $(`

        <div class="modal fade" id="modal-default">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">${title}</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                                <label id="lo-id">Lokasyonlar</label>
                                ${select}
                         </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Kapat</button>
                        <button type="button" class="btn btn-primary" id='change-location'>Kaydet</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
`);
    modal.find('#change-location').on('click', async (e) => {
        var locationId = modal.find('#Lokasyon_ID').val()
        var requestBody = {
            aracId,
            locationId
        }
        var response = await fetch(changeLocationUrl, {
            method: 'POST', // *GET, POST, PUT, DELETE, etc.
            mode: 'cors', // no-cors, *cors, same-origin
            cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
            credentials: 'same-origin', // include, *same-origin, omit
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
            redirect: 'follow', // manual, *follow, error
            referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
            body: JSON.stringify(requestBody) // body data type must match "Content-Type" header
        });
        var data = await response.json(); // parses JSON response into native JavaScript objects
        modal.modal('hide');
        if (data.isSuccess) {
            location.reload()
        } else {
            alert("Lokasyon değiştirme HATALI.");
        }
    })

    modal.modal('show');
}