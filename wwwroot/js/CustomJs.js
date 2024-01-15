$('#txtSearch').keyup(function () {

    var typeValue = $(this).val();
    $('tbody tr').each(function (){
        if ($(this).text().search(new RegExp(typeValue, "i")) < 0) {
            $(this).fadeOut();
        }
        else {
            $(this).show();
        }
    })

});