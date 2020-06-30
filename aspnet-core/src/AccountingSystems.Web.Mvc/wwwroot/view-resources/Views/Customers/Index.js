(function() {
    $(function() {

        var _customerService = abp.services.app.customer;
        var _salesmanService = abp.services.app.salesman;
        var _$modal = $('#CustomerCreateModal');
        var _$form = _$modal.find('form');

        $("#customerTable").DataTable({ responsive: true });
        _$form.validate({
        });

        $("#nextBtn").click(function () {
            $("#nextTab").addClass("active");
            $("#firstTab").removeClass("active");
        });

        $('#RefreshButton').click(function () {
            refreshCustomerList();
        });

        $('#salesmanCode').change(function (e) {

            var salesmanCode = $("#salesmanCode").val();

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Salesman/GetSalesmanName?salesmanCode=' + salesmanCode,
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (result) {
                    //console.log(result.id);
                    $('#SalesmanName').val(result.name).focus();
                    $('#SalesmanId').val(result.id);
                },
                error: function (e) { }
            });
        });

        $('.delete-customer').click(function () {
            var customerId = $(this).attr("data-customer-id");
            var customerName = $(this).attr('data-customer-name');

            deleteCustomer(customerId, customerName);
        });

        $('.edit-customer').click(function (e) {
            var customerId = $(this).attr("data-customer-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Customer/EditCustomerModal?customerId=' + customerId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#CustomerEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var customers = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            
            abp.ui.setBusy(_$modal);
            _customerService.create(customers).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new location!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshCustomerList() {
            location.reload(true); //reload page to see new location!
        }

        function deleteCustomer(customerId, customerName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AccountingSystems'), customerName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _customerService.delete({
                            id: customerId
                        }).done(function () {
                            refreshCustomerList();
                        });
                    }
                }
            );
        }
    });
})();
