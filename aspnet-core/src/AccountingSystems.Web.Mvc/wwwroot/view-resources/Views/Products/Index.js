(function() {
    $(function() {

        var _productService = abp.services.app.product;
        var _$modal = $('#ProductCreateModal');
        var _$form = _$modal.find('form');

        $("#productTable").DataTable({ responsive: true });
        _$form.validate({
        });

        $("#nextBtn").click(function () {
            $("#nextTab").addClass("active");
            $("#firstTab").removeClass("active");
        });

        $('#RefreshButton').click(function () {
            refreshProductList();
        });

        $('#SuppCode').change(function (e) {

            var supplierCode = $("#SuppCode").val();

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Supplier/GetSupplierName?supplierCode=' + supplierCode,
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (result) {
                    $('#SupplierName').val(result.name).focus();
                    $('#SupplierId').val(result.id);
                },
                error: function (e) { }
            });
        });

        $('.delete-product').click(function () {
            var productId = $(this).attr("data-product-id");
            var productName = $(this).attr('data-product-name');

            deleteProduct(productId, productName);
        });

        $('.edit-product').click(function (e) {
            var productId = $(this).attr("data-product-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Product/EditProductModal?productId=' + productId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#ProductEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var product = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            
            abp.ui.setBusy(_$modal);
            _productService.create(product).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new location!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshProductList() {
            location.reload(true); //reload page to see new location!
        }

        function deleteProduct(productId, productName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), productName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _productService.delete({
                            id: productId
                        }).done(function () {
                            refreshProductList();
                        });
                    }
                }
            );
        }
    });
})();
