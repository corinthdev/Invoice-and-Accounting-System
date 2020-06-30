(function () {
    $(function () {

        var _$form = $('form[name=stocksCreateForm]');
        var _stockService = abp.services.app.stock;
        var _productService = abp.services.app.product;

        var pieceprice;
        var boxprice;
        var caseprice;
        _$form.validate({});
        var lastPurchaseOrderCode;
        var newPurchaseOrderCode;

        for (var i = 0; i < 10; i++) {
            $("#stocksTable").append(
                "<tr id='rowProd" + i + "'>" +
                "<td>" + "<input class='hidden' name='ProductId' data-prod-idd=' " + i + "' /><input class='hidden' name='PricePerPiece' data-prod-pricepiece=' " + i + "' /><input class='hidden' name='ProdCase' data-prod-prodcase=' " + i + "' /><input class='hidden' name='ProdPiece' data-prod-prodpiece=' " + i + "' /><input id='prodCode' data-prod-id=' " + i + "' name='Code' type='text' class='form-control' size='10' />" + "</td>" +
                "<td class='tblDesc' nowrap>" + "<input id='prodDesc' name='Description' type='text' data-prod-desc=' " + i + "' class='form-control' style='width: 100%;' size='30' readonly />" + "</td > " +
                "<td class='tblCases'>" + "<input id='cases' type='text' name='Case' data-prod-cases=' " + i + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblBox'>" + "<input id='boxes' type='text' name='Box' data-prod-boxes=' " + i + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblPcs'>" + "<input id='pieces' type='text' name='Piece' data-prod-pieces=' " + i + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblPrice'>" + "<input id='sumPrice' type='text' data-prod-price=' " + i + "' name='TotalProductPrice' class='form-control' size='10' />" + "</td>" +
                "<td class='tblGross'>" + "<input type='text' name='Gross' data-prod-gross=' " + i + "' class='form-control' size='10' />" + "</td > " +
                "<td>" + "<button class='delProd'><i class='material-icons'>delete_sweep</i></button>" + "</td>" +
                "</tr>");
        }

        $("#stocksTable").DataTable({
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

        var x = 10;
        $("#addBtn").click(function () {

            $("#stocksTable").append(
                "<tr id='rowProd" + x + "'>" +
                "<td>" + "<input class='hidden' name='ProductId' data-prod-idd=' " + x + "' /><input class='hidden' name='PricePerPiece' data-prod-pricepiece=' " + x + "' /><input class='hidden' name='ProdCase' data-prod-prodcase=' " + x + "' /><input class='hidden' name='ProdPiece' data-prod-prodpiece=' " + x + "' /><input id='prodCode' data-prod-id=' " + x + "' name='Code' type='text' class='form-control' size='10' />" + "</td>" +
                "<td class='tblDesc' nowrap>" + "<input id='prodDesc' name='Description' type='text' data-prod-desc=' " + x + "' class='form-control' style='width: 100%;' size='30' readonly />" + "</td > " +
                "<td class='tblCases'>" + "<input type='text' id='cases' name='Case' data-prod-cases=' " + x + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblBox'>" + "<input type='text' id='boxes' name='Boxes' data-prod-boxes=' " + x + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblPcs'>" + "<input type='text' id='pieces' name='Piece' data-prod-pieces=' " + x + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblPrice'>" + "<input id='sumPrice' type='text' data-prod-price=' " + x + "' name='TotalProductPrice' class='form-control' size='10' />" + "</td>" +
                "<td class='tblGross'>" + "<input type='text' name='Gross' data-prod-gross=' " + x + "' class='form-control' size='10' />" + "</td > " +
                "<td>" + "<button class='delProd'><i class='material-icons'>delete_sweep</i></button>" + "</td>" +
                "</tr>"
            );
            x++;
        });

        $("#stocksTable").on('click', '.delProd', function () {
            $(this).closest('tr').remove();
            getTotal();
        });

        $("#stocksTable").on('change', '#prodCode', function () {
            var code = $(this).closest('td').find("input[name='Code']").val();
            var prodId = $(this).attr("data-prod-id");
            _productService.getProductByCode(code).done(function (result) {
                console.log(result);
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

        $("#stocksTable").on('change', '#pieces', function () {
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



        }

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var stock = _$form.serializeFormToObject();

            stock.stocks = [];
            $("input[name=ProductId]").each(function () {
                var data = {};
                if ($(this).val() > 0) {
                    $(this).closest('tr').each(function () {
                        $('input', this).each(function () {
                            data[$(this).attr('name')] = $(this).val();
                        });
                    });
                    stock.stocks.push(data);
                }
            });
            //console.log(stock);
            //abp.ui.setBusy(_$form);
            abp.ajax({
                url: abp.appPath + 'Stocks/CreateStocks',
                type: 'POST',
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                dataType: 'json',
                data: stock,
                success: function (result) {
                    location.href = "/Stocks";
                },
                error: function (e) { }
            });
            /*_stockService.create(stocks).done(function () {
                location.href = "/Stocks";
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
            */
        });
    });
})();
