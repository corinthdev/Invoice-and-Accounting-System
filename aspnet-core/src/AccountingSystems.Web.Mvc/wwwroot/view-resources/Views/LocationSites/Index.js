(function() {
    $(function() {

        var _locationSiteService = abp.services.app.locationSite;
        var _$modal = $('#LocationSiteCreateModal');
        var _$form = _$modal.find('form');

        $("#locationSiteTable").DataTable({ responsive: true });
        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshLocationSiteList();
        });

        $('.delete-locsite').click(function () {
            var siteId = $(this).attr("data-locsite-id");
            var SiteCode = $(this).attr('data-locsite-name');

            deleteLocSite(siteId, SiteCode);
        });

        $('.edit-locsite').click(function (e) {
            var siteId = $(this).attr("data-locsite-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'LocationSite/EditLocationSiteModal?siteId=' + siteId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#LocationSiteEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log(e); }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var locSite = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            
            abp.ui.setBusy(_$modal);
            _locationSiteService.create(locSite).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new location!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshLocationSiteList() {
            location.reload(true); //reload page to see new location!
        }

        function deleteLocSite(siteId, SiteCode) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), siteCode),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _locationSiteService.delete({
                            id: siteId
                        }).done(function () {
                            refreshLocationSiteList();
                        });
                    }
                }
            );
        }
    });
})();
