(function () {
    $(function () {

        $("#withdrawalListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshWithdrawalList();
        });
        function refreshWithdrawalList() {
            location.reload(true); //reload page to see new location!
        }

    });
})();
