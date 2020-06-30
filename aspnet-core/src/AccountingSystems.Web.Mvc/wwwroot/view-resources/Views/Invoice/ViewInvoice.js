(function () {
    $(function () {

        var lastNumber = 0;
        $("#invoiceTable tr").each(function () {
            lastNumber += 1;
        });
        var lastNum = lastNumber - 1;
        $("#article").text(lastNum);

        $('#btnPrint').click(function () {
            var doc = new jsPDF();
            doc.fromHTML($('#panelContents').html(), 15, 15, { 'width': 170 });
            doc.save('sample.pdf');
            return false;
        });
        $("#printMe").click(function () {
            var prtContent = document.getElementById("panelContents");
            var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=900,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        });
    });
})();
