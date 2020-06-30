(function() {
    $(function() {

        var _salesmanService = abp.services.app.salesman;
        var _$modal = $('#SalesmanCreateModal');
        var _$form = _$modal.find('form');

        $("#salesmanTable").DataTable({ responsive: true });
        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshSalesmanList();
        });

        $('.delete-salesman').click(function () {
            var salesmanId = $(this).attr("data-salesman-id");
            var salesmanName = $(this).attr('data-salesman-name');

            deleteSalesman(salesmanId, salesmanName);
        });

        $('.edit-salesman').click(function (e) {
            var salesmanId = $(this).attr("data-salesman-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Salesman/EditSalesmanModal?salesmanId=' + salesmanId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#SalesmanEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var salesmans = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            
            abp.ui.setBusy(_$modal);
            _salesmanService.create(salesmans).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new location!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshSalesmanList() {
            location.reload(true); //reload page to see new location!
        }

        function deleteSalesman(salesmanId, salesmanName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), salesmanName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _salesmanService.delete({
                            id: salesmanId
                        }).done(function () {
                            refreshSalesmanList();
                        });
                    }
                }
            );
        }
    });
})();
