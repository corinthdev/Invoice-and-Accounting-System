(function () {
    $(function () {

        $("#debitMemoListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshDebitMemoList();
        });
        function refreshDebitMemoList() {
            location.reload(true); //reload page to see new location!
        }
        $('.delete-debitMemo').click(function () {
            var debitMemoId = $(this).attr("data-debitMemo-id");
            var debitMemoCode = $(this).attr('data-debitMemo-name');

            deleteDebitMemo(debitMemoId, debitMemoCode);
        });
        function deleteDebitMemo(debitMemoId, debitMemoCode) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), debitMemoCode),
                function (isConfirmed) {
                    if (isConfirmed) {
                        //Change this
                        _productService.delete({
                            id: debitMemoId
                        }).done(function () {
                            refreshDebitMemoList();
                        });
                    }
                }
            );
        }
    });
})();
