(function () {
    $(function () {

        var _$form = $('form[name=purchaseOrderCreateForm]');
        var _purchaseOrderService = abp.services.app.purchaseOrder;
        var _supplierService = abp.services.app.supplier;
        var _productService = abp.services.app.product;
        var pieceprice;
        var boxprice;
        var caseprice;
        _$form.validate({});
        var lastPurchaseOrderCode;
        var newPurchaseOrderCode;

        let today = new Date().toLocaleDateString();
        $("#purchaseOrderDate").val(today);
        $("#purchaseOrderDate").attr('readonly', true);

        $('#isAllowed').change(function () {
            if (this.checked) {
                $("#purchaseOrderDate").attr('readonly', false);
            }
            else {
                $("#purchaseOrderDate").attr('readonly', true);
            }
        });

        _purchaseOrderService.getLastPurchaseOrderCode().done(function (result) {
            if (result == null) {
                var one = "PO0000001";
                $("#purchaseOrderNumber").val(one);
            }
            lastPurchaseOrderCode = result.purchaseOrderCode;
            var getPart = lastPurchaseOrderCode.replace(/[^\d.]/g, ''); //get number part
            var num = parseInt(getPart); //convert to int
            var newval = num + 1; //add 1
            var reg = new RegExp(num); //dynamic regexp
            newPurchaseOrderCode = lastPurchaseOrderCode.replace(reg, newval);
            $("#purchaseOrderNumber").val(newPurchaseOrderCode);
        });
        for (var i = 0; i < 10; i++) {
            $("#purchaseOrderTable").append(
                "<tr id='rowProd" + i + "'>" +
                "<td>" + "<input class='hidden' name='ProductId' data-prod-idd=' " + i + "' /><input class='hidden' name='PricePerPiece' data-prod-pricepiece=' " + i + "' /><input class='hidden' name='ProdCase' data-prod-prodcase=' " + i + "' /><input class='hidden' name='ProdPiece' data-prod-prodpiece=' " + i + "' /><input id='prodCode' data-prod-id=' " + i + "' name='Code' type='text' class='form-control' size='10' />" + "</td>" +
                "<td class='tblDesc' nowrap>" + "<input id='prodDesc' name='Description' type='text' data-prod-desc=' " + i + "' class='form-control' style='width: 100%;' size='30' readonly />" + "</td > " +
                "<td class='tblCases'>" + "<input id='cases' type='text' name='Case' data-prod-cases=' " + i + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblBox'>" + "<input id='boxes' type='text' name='Box' data-prod-boxes=' " + i + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblPcs'>" + "<input id='pieces' type='text' name='Piece' data-prod-pieces=' " + i + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblPrice'>" + "<input id='sumPrice' type='text' data-prod-price=' " + i + "' name='TotalProductPrice' class='form-control' size='10' />" + "</td>" +
                "<td class='tblGross'>" + "<input type='text' name='Gross' data-prod-gross=' " + i + "' class='form-control' size='10' />" + "</td > " +
                "<td class='tblNet'>" + "<input type='text' name='Net' data-prod-net=' " + i + "' class='form-control' size='10' />" + "</td > " +
                "<td>" + "<button class='delProd'><i class='material-icons'>delete_sweep</i></button>" + "</td>" +
                "</tr>");
        }

        $("#purchaseOrderTable").DataTable({
            "searching": false,
            "paging": false,
            "info": false,
            "language": {
                "emptyTable": " "
            },
            "ordering": false,
            "fixedHeader": true,
            "responsive": true,
            "autoWidth": true,
            "scrollY": "300px",
            "scrollCollapse": true
        });

        $('#supCode').change(function (e) {

            var supCode = $("#supCode").val();
            //console.log(cusCode);

            _supplierService.get({ id: supCode }).done(function (result) {
                $("#supName").val(result.name);
                $("#supAddress").val(result.address);
                //console.log(result);
            });
        });

        var x = 10;
        $("#addBtn").click(function () {

            $("#purchaseOrderTable").append(
                "<tr id='rowProd" + x + "'>" +
                "<td>" + "<input class='hidden' name='ProductId' data-prod-idd=' " + x + "' /><input class='hidden' name='PricePerPiece' data-prod-pricepiece=' " + x + "' /><input class='hidden' name='ProdCase' data-prod-prodcase=' " + x + "' /><input class='hidden' name='ProdPiece' data-prod-prodpiece=' " + x + "' /><input id='prodCode' data-prod-id=' " + x + "' name='Code' type='text' class='form-control' size='10' />" + "</td>" +
                "<td class='tblDesc' nowrap>" + "<input id='prodDesc' name='Description' type='text' data-prod-desc=' " + x + "' class='form-control' style='width: 100%;' size='30' readonly />" + "</td > " +
                "<td class='tblCases'>" + "<input type='text' id='cases' name='Case' data-prod-cases=' " + x + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblBox'>" + "<input type='text' id='boxes' name='Box' data-prod-boxes=' " + x + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblPcs'>" + "<input type='text' id='pieces' name='Piece' data-prod-pieces=' " + x + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblPrice'>" + "<input id='sumPrice' type='text' data-prod-price=' " + x + "' name='TotalProductPrice' class='form-control' size='10' />" + "</td>" +
                "<td class='tblGross'>" + "<input type='text' name='Gross' data-prod-gross=' " + x + "' class='form-control' size='10' />" + "</td > " +
                "<td class='tblNet'>" + "<input type='text' data-prod-net=' " + x + "' name='Net' class='form-control' size='10' />" + "</td > " +
                "<td>" + "<button class='delProd'><i class='material-icons'>delete_sweep</i></button>" + "</td>" +
                "</tr>"
            );
            x++;
        });

        $("#purchaseOrderTable").on('click', '.delProd', function () {
            $(this).closest('tr').remove();
            getTotal();
        });

        $("#purchaseOrderTable").on('change', '#prodCode', function () {
            var code = $(this).closest('td').find("input[name='Code']").val();
            var prodId = $(this).attr("data-prod-id");
            _productService.getProductByCode(code).done(function (result) {
                caseprice = result.net;
                boxprice = result.pricePerBox;
                pieceprice = result.pricePerPiece;
                $("input[data-prod-idd='" + prodId + "']").val(result.id);
                $("input[data-prod-desc='" + prodId + "']").val(result.itemName);
                $("input[data-prod-pricepiece='" + prodId + "']").val(result.pricePerPiece);
                $("input[data-prod-prodcase='" + prodId + "']").val(result.cases);
                $("input[data-prod-prodpiece='" + prodId + "']").val(result.pieces);
            });
        });

        $("#purchaseOrderTable").on('change', '#pieces', function () {
            var prodId = $(this).attr("data-prod-pieces");
            console.log(prodId);
            var caseval = $("input[data-prod-cases='" + prodId + "']").val();
            var boxval = $("input[data-prod-boxes='" + prodId + "']").val();
            var pieceval = $("input[data-prod-pieces='" + prodId + "']").val();
            var summ;
            if (caseval > 0 && boxval > 0 && pieceval > 0) {
                summ = (caseprice + boxprice + pieceprice).toFixed(2);
                $("input[data-prod-price='" + prodId + "']").val(summ);
            }
            else if (caseval > 0 && boxval > 0 && pieceval == 0) {
                summ = (caseprice + boxprice).toFixed(2);
                $("input[data-prod-price='" + prodId + "']").val(summ);
            }
            else if (caseval > 0 && boxval == 0 && pieceval > 0) {
                summ = (caseprice + pieceprice).toFixed(2);
                $("input[data-prod-price='" + prodId + "']").val(summ);
            }
            else if (caseval == 0 && boxval > 0 && pieceval > 0) {
                summ = (pieceprice + boxprice).toFixed(2);
                $("input[data-prod-price='" + prodId + "']").val(summ);
            }
            else if (caseval > 0 && boxval == 0 && pieceval == 0) {
                summ = (caseprice).toFixed(2);
                $("input[data-prod-price='" + prodId + "']").val(summ);
            }
            else if (caseval == 0 && boxval > 0 && pieceval == 0) {
                summ = (boxprice).toFixed(2);
                $("input[data-prod-price='" + prodId + "']").val(summ);
            }
            else if (caseval == 0 && boxval == 0 && pieceval > 0) {
                summ = (pieceprice).toFixed(2);
                $("input[data-prod-price='" + prodId + "']").val(summ);
            } else {
                summ = 0;
                $("input[data-prod-price='" + prodId + "']").val(summ);
            }
            var casess = caseprice * caseval;
            var boxess = boxprice * boxval;
            var piecess = pieceprice * pieceval;
            var sum = (casess + boxess + piecess).toFixed(2);
            $("input[data-prod-gross='" + prodId + "']").val(sum);
            var netnet = (sum);
            $("input[data-prod-net='" + prodId + "']").val(netnet);

            getTotal();

        });

        function getTotal() {
            let totalCase = 0;
            var totalBox = 0;
            var totalPcs = 0;
            var totalGross = 0;
            var totalNet = 0;
            var vatable = 0;
            var vat = 0;

            $("input[name = Case]").each(function () {
                if ($(this).val() != "") {
                    var value = parseInt($(this).val());
                    totalCase += value;
                }
            });
            $("input[name=TotalCase]").val(totalCase);

            $("input[name = Box]").each(function () {
                if ($(this).val() != "") {
                    var value = parseInt($(this).val());
                    totalBox += value;
                }
            });
            $("input[name=TotalBox]").val(totalBox);

            $("input[name = Piece]").each(function () {
                if ($(this).val() != "") {
                    var value = parseInt($(this).val());
                    totalPcs += value;
                }
            });
            $("input[name=TotalPiece]").val(totalPcs);

            $("input[name= Gross]").each(function () {
                if ($(this).val() != "") {
                    var value = parseFloat($(this).val());
                    totalGross += value;
                }
            });
            $("input[name=TotalGross]").val(totalGross);

            $("input[name= Net]").each(function () {
                if ($(this).val() != "") {
                    var value = parseFloat($(this).val());
                    totalNet += value;
                }
            });
            $("input[name=TotalNet]").val(totalNet);

            vatable = (totalNet / 1.12).toFixed(2);
            vat = (vatable * .12).toFixed(2);
            $("#vatable").val(vatable);
            $("#vat").val(vat);
        }

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var purchaseOrder = _$form.serializeFormToObject();

            purchaseOrder.purchaseOrderDetails = [];
            $("input[name=ProductId]").each(function () {
                var data = {};
                if ($(this).val() > 0) {
                    $(this).closest('tr').each(function () {
                        $('input', this).each(function () {
                            data[$(this).attr('name')] = $(this).val();
                        });
                    });
                    purchaseOrder.purchaseOrderDetails.push(data);
                }
            });
            console.log(purchaseOrder);
            abp.ajax({
                url: abp.appPath + 'PurchaseOrder/CreatePurchaseOrder',
                type: 'POST',
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                dataType: 'json',
                data: purchaseOrder,
                success: function () {
                    location.href = "/PurchaseOrder";
                },
                error: function (e) { console.log(e); }
            });
            /*abp.ui.setBusy(_$form);
            _purchaseOrderService.create(purchaseOrder).done(function () {
                location.href = "/PurchaseOrder";
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
            */
        });
    });
})();
