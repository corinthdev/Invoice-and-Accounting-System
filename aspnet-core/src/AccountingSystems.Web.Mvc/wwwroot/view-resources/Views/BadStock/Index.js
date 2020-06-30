(function () {
    $(function () {

        $("#badStockListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshBadStockList();
        });
        function refreshBadStockList() {
            location.reload(true); //reload page to see new location!
        }
    });
})();
