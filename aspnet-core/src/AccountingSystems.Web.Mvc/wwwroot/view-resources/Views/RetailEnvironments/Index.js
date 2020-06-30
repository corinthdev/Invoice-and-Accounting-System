(function() {
    $(function() {

        var _retailenvService = abp.services.app.retailEnvironment;
        var _$modal = $('#RetailEnvCreateModal');
        var _$form = _$modal.find('form');

        $("#retailenvTable").DataTable({ responsive: true });

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshREList();
        });

        $('.delete-retailenv').click(function () {
            var retailenvId = $(this).attr("data-retailenv-id");
            var retailenvName = $(this).attr('data-retailenv-name');

            deleteRE(retailenvId, retailenvName);
        });

        $('.edit-retailenv').click(function (e) {
            var retailenvId = $(this).attr("data-retailenv-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'RetailEnvironment/EditRetailEnvironmentModal?retailenvId=' + retailenvId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#RetailEnvEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var retailenvs = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            
            abp.ui.setBusy(_$modal);
            _retailenvService.create(retailenvs).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new location!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshREList() {
            location.reload(true); //reload page to see new location!
        }

        function deleteRE(retailenvId, retailenvName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), retailenvName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _retailenvService.delete({
                            id: retailenvId
                        }).done(function () {
                            refreshREList();
                        });
                    }
                }
            );
        }
    });
})();
