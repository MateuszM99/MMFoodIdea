

function addComment(){
    alert("ok");
    var commentContainer = document.createElement('div');
    commentContainer.classList.add("comment-container")

    document.getElementById("comments").appendChild(commentContainer);

    var imageContainer = document.createElement('div');
    imageContainer.classList.add("c-user-image");

    commentContainer.appendChild(imageContainer);

    var image = document.createElement('img');

    image.src = "https://image.shutterstock.com/image-vector/vector-simple-male-profile-icon-260nw-1388357696.jpg";

    imageContainer.appendChild(image);

    var commentInfo = document.createElement('div');
    commentInfo.classList.add("comment-info");

    imageContainer.appendChild(commentInfo);

    var username = document.createElement('p');

    username.textContent = "Random";

    var time = document.createElement('p');

    time.textContent = "2 years ago";

    commentInfo.appendChild(username);

    commentInfo.appendChild(time);

    var commentText = document.createElement('div');
    commentText.classList.add("comment-text");

    imageContainer.appendChild(commentText);
    
    var text = document.createElement('p');

    text.textContent = "Lorem Ipsum";

    commentText.appendChild(text);

    var commentLikes = document.createElement('div');
    commentLikes.classList.add("comment-likes");

    imageContainer.appendChild(commentLikes);

    var likeForm = document.createElement('form');

    likeForm.innerHTML = "some"

    likeForm.elements = "asp"

    commentLikes.appendChild(likeForm);

}

function commentAdd(){
    $("comments").load("/Recipes/LeaveComment")
}