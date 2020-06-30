(function () {
    $(function () {

        $("#bookingListTable").DataTable({ responsive: true });

        $('#RefreshButton').click(function () {
            refreshBookingList();
        });
        function refreshBookingList() {
            location.reload(true); //reload page to see new location!
        }
        $('.delete-booking').click(function () {
            var bookingId = $(this).attr("data-booking-id");
            var bookingCode = $(this).attr('data-booking-name');

            deleteBooking(bookingId, bookingCode);
        });
        function deleteBooking(bookingId, bookingCode) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), bookingCode),
                function (isConfirmed) {
                    if (isConfirmed) {
                        //Change this
                        _productService.delete({
                            id: bookingId
                        }).done(function () {
                            refreshBookingList();
                        });
                    }
                }
            );
        }
    });
})();