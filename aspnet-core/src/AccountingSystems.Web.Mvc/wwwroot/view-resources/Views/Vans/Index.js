(function() {
    $(function() {

        var _vanService = abp.services.app.van;
        var _salesmanService = abp.services.app.salesman;
        var _$modal = $('#VanCreateModal');
        var _$form = _$modal.find('form');

        $("#vanTable").DataTable({ responsive: true });
        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshVanList();
        });

        $('#SalesCode').change(function (e) {

            var salesmanCode = $("#SalesCode").val();

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Salesman/GetSalesmanName?salesmanCode=' + salesmanCode,
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (result) {
                    $('#SalesmanName').val(result.name).focus();
                    $('#SalesmanId').val(result.id);
                },
                error: function (e) { }
            });
        });

        $('.delete-van').click(function () {
            var vanId = $(this).attr("data-van-id");
            var vanName = $(this).attr('data-van-name');

            deleteVan(vanId,vanName);
        });

        $('.edit-van').click(function (e) {
            var vanId = $(this).attr("data-van-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Van/EditVanModal?vanId=' + vanId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#VanEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var van = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            
            abp.ui.setBusy(_$modal);
            _vanService.create(van).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new location!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshVanList() {
            location.reload(true); //reload page to see new location!
        }

        function deleteVan(vanId, vanName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), vanName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _vanService.delete({
                            id: vanId
                        }).done(function () {
                            refreshVanList();
                        });
                    }
                }
            );
        }
    });
})();
