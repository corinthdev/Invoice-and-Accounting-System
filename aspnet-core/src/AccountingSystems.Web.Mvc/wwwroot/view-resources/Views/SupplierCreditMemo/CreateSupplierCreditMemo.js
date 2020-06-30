(function () {
    $(function () {

        var _supplierService = abp.services.app.supplier;
        var _productService = abp.services.app.product;

        var tblCode;
        var tblDesc;
        var pricePerPiece;
        var unitCost;
        //var btnFunc = delProduct(this);
        let today = new Date().toLocaleDateString();
        //console.log(today);
        $("#returnCMDate").val(today);
        $("#returnCMDate").attr('readonly', true);

        $('#isAllowed').change(function () {
            if (this.checked) {
                $("#returnCMDate").attr('readonly', false);
            }
            else {
                $("#returnCMDate").attr('readonly', true);
            }
        });

        function getTotal() {
            var totalCase = 0;
            var totalPcs = 0;
            var totalPrice = 0;
            var totalGross = 0;
            var totalNet = 0;
            var vatable = 0;
            var vat = 0;

            $(".tblCases").each(function () {
                var value = parseInt($(this).text());
                totalCase += value;
            });
            $("#totalCase").text(totalCase);

            $(".tblPcs").each(function () {
                var value = parseInt($(this).text());
                totalPcs += value;
            });
            $("#totalPcs").text(totalPcs);

            $(".tblPrice").each(function () {
                var value = parseFloat($(this).text());
                totalPrice += value;
            });
            $("#totalPrice").text(totalPrice);

            $(".tblGross").each(function () {
                var value = parseFloat($(this).text());
                totalGross += value;
            });
            $("#totalGross").text(totalGross);

            $(".tblNet").each(function () {
                var value = parseFloat($(this).text());
                totalNet += value;
            });
            $("#totalNet").text(totalNet);
            vatable = (totalNet / 1.12).toFixed(2);
            vat = (vatable * .12).toFixed(2);
            $("#vatable").val(vatable);
            $("#vat").val(vat);
        }

        $('#supCode').change(function (e) {

            var supCode = $("#supCode").val();
            //console.log(cusCode);

            _supplierService.get({ id: supCode }).done(function (result) {
                $("#supName").val(result.name);
                $("#supAddress").val(result.address);
                //console.log(result);
            });
        });

        $("#prodCode").change(function (e) {

            var prodCode = $("#prodCode").val();

            _productService.get({ id: prodCode }).done(function (result) {
                console.log(result);
                tblCode = result.code;
                tblDesc = result.itemName;
                pricePerPiece = result.pricePerPiece;
                unitCost = result.unitCost;
            });
        });

        $("#addInvoice").click(function () {
            var gross;
            var prodprice;
            var net;
            //let delBtn = "<input type='button' value='Delete Row' onclick='delProduct()' > ";
            if ($("#cases").val() == 0) {
                gross = $("#pcs").val() * pricePerPiece;
                net = $("#pcs").val() * pricePerPiece;
                prodprice = pricePerPiece;
            } else {
                gross = $("#cases").val() * unitCost;
                net = $("#cases").val() * unitCost;
                prodprice = unitCost;
            }
            $("#invoiceTable").append(
                "<tr>" +
                "<td>" + tblCode + "</td >" +
                "<td>" + tblDesc + "</td > " +
                "<td class='tblCases'>" + $("#cases").val() + "</td > " +
                "<td>" + "CS" + "</td > " +
                "<td class='tblPcs'>" + $("#pcs").val() + "</td > " +
                "<td>" + "PCS" + "</td > " +
                "<td>" + $("#priceType").val() + "</td > " +
                "<td class='tblPrice'>" + prodprice +
                "<td class='tblGross'>" + gross + "</td > " +
                "<td class='tblNet'>" + net + "</td > " +
                "<td>" + "<button class='delProd'><i class='material-icons'>delete_sweep</i></button>" + "</td > " +
                "</tr>"
            );
            formClear();
            getTotal();
        });
        function formClear() {
            $("#prodCode").val("");
            $("#cases").val("");
            $("#pcs").val("");
        }

        $("#invoiceTable").on('click', '.delProd', function () {
            $(this).closest('tr').remove();
            getTotal();
        });
    });
})();
