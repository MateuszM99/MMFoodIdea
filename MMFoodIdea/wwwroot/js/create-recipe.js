$("#btnAdd").on('click', function () {
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/Recipes/addIngridient',
        success: function (partialView) {
            console.log("partialView: " + partialView);
            $('#ingridientsContainer').html(partialView);
        }
    });
});

