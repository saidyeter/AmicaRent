(function (win, doc, $, undefined) {
    var Home = {
        Init: function () {
            var self = this;
            Home.Helper.Import(self);
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
        MainSlider: {
            selector: '.main_slider',
            init: function () {
                var t = this;

                $(t.selector).owlCarousel({
                    loop:true,
                    margin:20,
                    nav:false,
                    responsive:{
                        0:{
                            items:1
                        },
                        600:{
                            items:3
                        }
                    }
                })

            }
        },
        VehicleSlider: {
            selector: '.vehicle_slider',
            init: function () {
                var t = this;

                $(t.selector).owlCarousel({
                    loop:true,
                    margin:20,
                    nav:false,
                    responsive:{
                        0:{
                            items:1
                        },
                        600:{
                            items:3
                        }
                    }
                })

            }
        }
    };

    $(document).ready(function () {
        Home.Init();
        win.Home = Home;
    });
})(window, document, jQuery);
