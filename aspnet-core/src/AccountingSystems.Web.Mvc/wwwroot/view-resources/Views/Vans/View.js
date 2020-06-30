(function () {
    $(function () {
        $('.count-to').countTo();
        $("#vanStockListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshVanStockList();
        });
        function refreshVanStockList() {
            location.reload(true); //reload page to see new location!
        }

    });
})();
