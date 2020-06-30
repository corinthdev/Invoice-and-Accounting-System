(function () {
    $(function () {

        $("#arListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshInvoiceList();
        });
        function refreshInvoiceList() {
            location.reload(true); //reload page to see new location!
        }
        
    });
})();
