const select = document.getElementById('rate-select');

const recipeId = document.getElementById('recipe-id').value;

$('#rate-button').click(function () {
    var rate = select.options[select.selectedIndex].value;

    $.ajax({
        url: "/Recipes/RateRecipe",
        data: {
            recipeId: recipeId,
            rate: rate
        },
        type: 'POST',
        success: showLabel(rate)
    });
});


function showLabel(rate) {
    document.getElementById('rate-label').textContent = `You rated ${rate}`;
}