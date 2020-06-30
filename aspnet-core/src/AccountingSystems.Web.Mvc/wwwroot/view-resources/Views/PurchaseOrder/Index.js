(function () {
    $(function () {

        $("#purchaseOrderListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshPurchaseOrderList();
        });
        function refreshPurchaseOrderList() {
            location.reload(true); //reload page to see new location!
        }
        $('.delete-purchaseOrder').click(function () {
            var purhcaseOrderId = $(this).attr("data-purchaseOrder-id");
            var purchaseOrderCode = $(this).attr('data-purchaseOrder-name');

            deletePurchaseOrder(purhcaseOrderId, purchaseOrderCode);
        });
        function deletePurchaseOrder(purhcaseOrderId, purchaseOrderCode) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), purchaseOrderCode),
                function (isConfirmed) {
                    if (isConfirmed) {
                        //Change this
                        _productService.delete({
                            id: purhcaseOrderId
                        }).done(function () {
                            refreshPurchaseOrderList();
                        });
                    }
                }
            );
        }
    });
})();
