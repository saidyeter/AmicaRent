(function (win, doc, $, undefined) {
    var timeCustomerTimer;

    var App = {
        Init: function () {
            var self = this;
            App.Helper.Import(self);
        },
        Helper: {
            Import: function (self) {
                var obj;
                for (obj in self) {
                    if (self.hasOwnProperty(obj)) {
                        var _method = self[obj];
                        if (_method.selector !== undefined && _method.init !== undefined) {
                            if ($(_method.selector).length) {
                                _method.init();
                            }
                        }
                    }
                }
            }
        },
        FormSelect: {
            selector: '.form_select',
            init: function () {
                var t = this;
                $(t.selector).each(function (i, item) {
                    $(item).selectric({
                        disableOnMobile: false,
                        nativeOnMobile: false,
                        arrowButtonMarkup    : '<b class="button"><i class="fas fa-caret-down"></i></b>',

                    });
                });
            }
        },
    };

    $(document).ready(function () {
        App.Init();
        win.App = App;
    });
})(window, document, jQuery);