(function () {
    $(function () {

        $("#creditMemoListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshCreditMemoList();
        });
        function refreshCreditMemoList() {
            location.reload(true); //reload page to see new location!
        }
        $('.delete-creditmemo').click(function () {
            var creditMemoId = $(this).attr("data-creditmemo-id");
            var creditMemoCode = $(this).attr('data-creditmemo-name');

            deleteCreditMemo(creditMemoId, creditMemoCode);
        });
        function deleteCreditMemo(creditMemoId, creditMemoCode) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), creditMemoCode),
                function (isConfirmed) {
                    if (isConfirmed) {
                        //Change this
                        _productService.delete({
                            id: creditMemoId
                        }).done(function () {
                            refreshCreditMemoList();
                        });
                    }
                }
            );
        }
    });
})();
