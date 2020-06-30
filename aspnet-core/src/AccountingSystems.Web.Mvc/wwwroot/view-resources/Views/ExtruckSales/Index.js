(function () {
    $(function () {

        $("#extruckSalesListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshExtruckSalesList();
        });
        function refreshExtruckSalesList() {
            location.reload(true); //reload page to see new location!
        }
        $('.delete-extruckSales').click(function () {
            var extruckId = $(this).attr("data-extruckSales-id");
            var extruckCode = $(this).attr('data-extruckSales-name');

            deleteExtruck(extruckId, extruckCode);
        });
        function deleteExtruck(extruckId, extruckCode) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), extruckCode),
                function (isConfirmed) {
                    if (isConfirmed) {
                        //Change this
                        _productService.delete({
                            id: extruckId
                        }).done(function () {
                            refreshExtruckSalesList();
                        });
                    }
                }
            );
        }
    });
})();
