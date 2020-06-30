(function () {
    $(function () {
        $('.count-to').countTo();
        $("#stockListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshStockList();
        });
        function refreshStockList() {
            location.reload(true); //reload page to see new location!
        }

    });
})();
