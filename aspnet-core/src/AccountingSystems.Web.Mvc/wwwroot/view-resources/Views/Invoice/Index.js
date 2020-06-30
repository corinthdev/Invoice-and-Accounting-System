(function () {
    $(function () {

        $("#invoiceListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshInvoiceList();
        });
        function refreshInvoiceList() {
            location.reload(true); //reload page to see new location!
        }
        $('.delete-invoice').click(function () {
            var invoiceId = $(this).attr("data-invoice-id");
            var invoiceCode = $(this).attr('data-invoice-name');

            deleteInvoice(invoiceId, invoiceCode);
        });
        function deleteInvoice(invoiceId, invoiceCode) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), invoiceCode),
                function (isConfirmed) {
                    if (isConfirmed) {
                        //Change this
                        _productService.delete({
                            id: invoiceId
                        }).done(function () {
                            refreshInvoiceList();
                        });
                    }
                }
            );
        }
    });
})();
