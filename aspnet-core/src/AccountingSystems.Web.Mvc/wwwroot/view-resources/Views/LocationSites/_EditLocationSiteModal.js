(function ($) {

    var _locationSiteService = abp.services.app.locationSite;
    var _$modal = $('#LocationSiteEditModal');
    var _$form = $('form[name=LocationSiteEditForm]');

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var locSite = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

        abp.ui.setBusy(_$form);
        _locationSiteService.update(locSite).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited location!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);