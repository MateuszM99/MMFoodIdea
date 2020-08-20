function latest() {
    alert('elo');
    $("#recipes").load("/Recipes/GetLatest");
}

function popular() {
    $("#recipes").load("/Recipes/GetPopular");
}

function liked() {
    $("#recipes").load("/Recipes/GetLiked");
}

function search() {

    let recipeName = $("#recipeSearch").val();

    $("#recipes").load("/Recipes/SearchRecipe", { recipeName: recipeName });
}