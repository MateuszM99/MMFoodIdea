function like(id) {

    var likes = document.getElementById(`likes-${id}`).textContent;

    if (document.getElementById(`like-button-${id}`) != null) {

        if (document.getElementById(`dislike-pressed-${id}`) != null) {
            var dislikes = document.getElementById(`dislikes-${id}`).textContent;
            dislikes--;
            document.getElementById(`dislikes-${id}`).textContent = dislikes;
            var button = document.getElementById(`dislike-pressed-${id}`);
            button.id = `dislike-button-${id}`;
        }

        likes++;
        document.getElementById(`likes-${id}`).textContent = likes;

        var button = document.getElementById(`like-button-${id}`);

        button.id = `like-pressed-${id}`;

    } else {

        likes--;
        document.getElementById(`likes-${id}`).textContent = likes;

        var button = document.getElementById(`like-pressed-${id}`);

        button.id = `like-button-${id}`;
    }

}

function dislike(id) {

    var dislikes = document.getElementById(`dislikes-${id}`).textContent;

    if (document.getElementById(`dislike-button-${id}`) != null) {

        if (document.getElementById(`like-pressed-${id}`) != null) {
            var likes = document.getElementById(`likes-${id}`).textContent;
            likes--;
            document.getElementById(`likes-${id}`).textContent = likes;
            var button = document.getElementById(`like-pressed-${id}`);
            button.id = `like-button-${id}`;
        }

        dislikes++;
        document.getElementById(`dislikes-${id}`).textContent = dislikes;

        var button = document.getElementById(`dislike-button-${id}`);

        button.id = `dislike-pressed-${id}`;
    } else {

        dislikes--;
        document.getElementById(`dislikes-${id}`).textContent = dislikes;

        var button = document.getElementById(`dislike-pressed-${id}`);

        button.id = `dislike-button-${id}`;
    }



}