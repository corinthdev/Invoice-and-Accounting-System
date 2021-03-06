﻿(function () {
    $(function () {

        var _$form = $('form[name=unloadCreateForm]');
        var _unloadService = abp.services.app.unload;
        var _vanService = abp.services.app.van;
        var _productService = abp.services.app.product;
        var _vanStockService = abp.services.app.vanStock;
        var pieceprice;
        var boxprice;
        var caseprice;
        _$form.validate({});
        var lastUnloadCode;
        var newUnloadCode;

        let today = new Date().toLocaleDateString();
        $("#unloadDate").val(today);
        $("#unloadDate").attr('readonly', true);

        _unloadService.getLastUnloadCode().done(function (result) {
            if (result == null) {
                var one = "U0000001";
                $("#unloadNumber").val(one);
            }
            else {
                lastUnloadCode = result.withdrawalCode;
                var getPart = lastUnloadCode.replace(/[^\d.]/g, ''); //get number part
                var num = parseInt(getPart); //convert to int
                var newval = num + 1; //add 1
                var reg = new RegExp(num); //dynamic regexp
                newUnloadCode = lastUnloadCode.replace(reg, newval);
                $("#unloadNumber").val(newUnloadCode);
            }

        });
        for (var i = 0; i < 10; i++) {
            $("#unloadTable").append(
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

        $("#unloadTable").DataTable({
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

        $('#isAllowed').change(function () {
            if (this.checked) {
                $("#unloadDate").attr('readonly', false);
            }
            else {
                $("#unloadDate").attr('readonly', true);
            }
        });

        $('#vanCode').change(function (e) {

            var vanCode = $("#vanCode").val();

            _vanService.get({ id: vanCode }).done(function (result) {
                $("#vanName").val(result.name);
                $("#vanDistrict").val(result.district);
                $("#salesmanId").val(result.salesmanId);
                $("#salesCode").val(result.salesmanCode);
                $("#salesName").val(result.salesmanName);
                $("#plateNumber").val(result.plateNumber);
                console.log(result);
            });
        });

        var x = 10;
        $("#addBtn").click(function () {

            $("#unloadTable").append(
                "<tr id='rowProd" + x + "'>" +
                "<td>" + "<input class='hidden' name='ProductId' data-prod-idd=' " + x + "' /><input class='hidden' name='PricePerPiece' data-prod-pricepiece=' " + x + "' /><input class='hidden' name='ProdCase' data-prod-prodcase=' " + x + "' /><input class='hidden' name='ProdPiece' data-prod-prodpiece=' " + x + "' /><input id='prodCode' data-prod-id=' " + x + "' name='Code' type='text' class='form-control' size='10' />" + "</td>" +
                "<td class='tblDesc' nowrap>" + "<input id='prodDesc' name='Description' type='text' data-prod-desc=' " + x + "' class='form-control' style='width: 100%;' size='30' readonly />" + "</td > " +
                "<td class='tblCases'>" + "<input type='text' id='cases' name='Case' data-prod-cases=' " + x + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblBox'>" + "<input type='text' id='boxes' name='Box' data-prod-boxes=' " + x + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblPcs'>" + "<input type='text' id='pieces' name='Piece' data-prod-pieces=' " + x + "' class='form-control' size='4' />" + "</td>" +
                "<td class='tblPrice'>" + "<input id='sumPrice' type='text' data-prod-price=' " + x + "' name='TotalProductPrice' class='form-control' size='10' />" + "</td>" +
                "<td class='tblGross'>" + "<input type='text' name='Gross' data-prod-gross=' " + x + "' class='form-control' size='10' />" + "</td > " +
                "<td class='tblDiscount'>" + "<input type='text' data-prod-discount=' " + x + "' name='Discount' class='form-control' size='4' />" + "</td > " +
                "<td class='tblNet'>" + "<input type='text' data-prod-net=' " + x + "' name='Net' class='form-control' size='10' />" + "</td > " +
                "<td>" + "<button class='delProd'><i class='material-icons'>delete_sweep</i></button>" + "</td>" +
                "</tr>"
            );
            x++;
        });

        $("#unloadTable").on('click', '.delProd', function () {
            $(this).closest('tr').remove();
            getTotal();
        });

        $("#unloadTable").on('change', '#prodCode', function () {
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

            //var productId = $("input[data-prod-idd='" + prodId + "']").val();
            //var vanId = $("#vanId").val();
            //_vanStockService.checkIfExisting(productId, vanId).done(function () {
            //    console.log("none");
            //});
        });
        $("#unloadTable").on('change', '#pieces', function () {
            var prodId = $(this).attr("data-prod-pieces");
            var salesm = $("#salesmanId").val();
            console.log(salesm);
            console.log(prodId);
            var caseval = $("input[data-prod-cases='" + prodId + "']").val();
            var boxval = $("input[data-prod-boxes='" + prodId + "']").val();
            var pieceval = $("input[data-prod-pieces='" + prodId + "']").val();
            var casepcs = $("input[data-prod-prodcase='" + prodId + "']").val();
            var whlcs = $("input[data-prod-prodpiece='" + prodId + "']").val();
            var productId = $("input[data-prod-idd='" + prodId + "']").val();
            var totalPieces = 0;
            var tcase = 0;
            var tbox = 0;
            tcase = parseInt(caseval) * parseInt(casepcs);
            tbox = parseInt(boxval) * parseInt(whlcs);
            totalPieces = (tcase + tbox + parseInt(pieceval));
            var vanId = $("#vanCode").val();
            _vanStockService.checkAvailable(productId, totalPieces, vanId).done(function () {
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
        });

        function getTotal() {
            let totalCase = 0;
            var totalBox = 0;
            var totalPcs = 0;
            var totalGross = 0;
            var totalDiscount = 0;
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

            $("input[name= Discount]").each(function () {
                if ($(this).val() != "") {
                    var value = parseFloat($(this).val());
                    totalDiscount += value;
                }
            });
            $("input[name=TotalDiscount]").val(totalDiscount);

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

            var unload = _$form.serializeFormToObject();

            unload.unloadDetails = [];
            $("input[name=ProductId]").each(function () {
                var data = {};
                if ($(this).val() > 0) {
                    $(this).closest('tr').each(function () {
                        $('input', this).each(function () {
                            data[$(this).attr('name')] = $(this).val();
                        });
                    });
                    unload.unloadDetails.push(data);
                }
            });
            console.log(unload);
            abp.ajax({
                url: abp.appPath + 'Unload/CreateUnload',
                type: 'POST',
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                dataType: 'json',
                data: unload,
                success: function (result) {
                    location.href = "/Unload";
                },
                error: function (e) { console.log(e); }
            });
        });

    });
})();