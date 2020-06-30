(function() {
    $(function() {

        var _supplierService = abp.services.app.supplier;
        var _$modal = $('#SupplierCreateModal');
        var _$form = _$modal.find('form');

        $("#supplierTable").DataTable({ responsive: true });
        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshSupplierList();
        });

        $('.delete-supplier').click(function () {
            var supplierId = $(this).attr("data-supplier-id");
            var supplierName = $(this).attr('data-supplier-name');

            deleteSupplier(supplierId, supplierName);
        });

        $('.edit-supplier').click(function (e) {
            var supplierId = $(this).attr("data-supplier-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Supplier/EditSupplierModal?supplierId=' + supplierId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#SupplierEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var supplier = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            
            abp.ui.setBusy(_$modal);
            _supplierService.create(supplier).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new location!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshSupplierList() {
            location.reload(true); //reload page to see new location!
        }

        function deleteSupplier(supplierId, supplierName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), supplierName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _supplierService.delete({
                            id: supplierId
                        }).done(function () {
                            refreshSupplierList();
                        });
                    }
                }
            );
        }
    });
})();
