$(function () {
    $('#linkId').click(function () {
        $.get(this.href, function (result) {
            $(result).dialog();
        });
        return false;
    });
});