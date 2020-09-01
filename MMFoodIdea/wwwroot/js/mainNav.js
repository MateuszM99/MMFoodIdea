function UpdateQueryString(key, value, url) {
    if (!url) url = window.location.href;
    var re = new RegExp("([?&])" + key + "=.*?(&|#|$)(.*)", "gi"),
        hash;

    if (re.test(url)) {
        if (typeof value !== 'undefined' && value !== null) {
            return url.replace(re, '$1' + key + "=" + value + '$2$3');
        }
        else {
            hash = url.split('#');
            url = hash[0].replace(re, '$1$3').replace(/(&|\?)$/, '');
            if (typeof hash[1] !== 'undefined' && hash[1] !== null) {
                url += '#' + hash[1];
            }
            return url;
        }
    }
    else {
        if (typeof value !== 'undefined' && value !== null) {
            var separator = url.indexOf('?') !== -1 ? '&' : '?';
            hash = url.split('#');
            url = hash[0] + separator + key + '=' + value;
            if (typeof hash[1] !== 'undefined' && hash[1] !== null) {
                url += '#' + hash[1];
            }
            return url;
        }
        else {
            return url;
        }
    }
}



function latest() {   
    var url = UpdateQueryString("sortType", "latest");
    $(location).attr('href', url);
}

function popular() {
    var url = UpdateQueryString("sortType", "popular");
    $(location).attr('href', url);
}

function liked() {
    var url = UpdateQueryString("sortType", "liked");
    $(location).attr('href', url);
}

function search() {
    var searchName = document.getElementById("recipeSearch").value;
    var url = UpdateQueryString("recipeName", searchName);
    $(location).attr('href', url);
}

function timeSearch(minutes) {   
    var url = UpdateQueryString("time", minutes);
    $(location).attr('href', url);
}

function categorySearch() {
    const select = document.getElementById("select-category");
    var searchCategory = select.options[select.selectedIndex].textContent;
    var url = UpdateQueryString("category", searchCategory);
    $(location).attr('href', url);
}

function ratingSearch(rating) {
    var url = UpdateQueryString("rating", rating);
    $(location).attr('href', url);
}