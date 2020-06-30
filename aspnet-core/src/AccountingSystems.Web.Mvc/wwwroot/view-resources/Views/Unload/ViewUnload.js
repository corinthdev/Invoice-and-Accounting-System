(function () {
    $(function () {

        var lastNumber = 0;
        $("#unloadTable tr").each(function () {
            lastNumber += 1;
        });
        var lastNum = lastNumber - 1;
        $("#article").text(lastNum);

    });
})();
