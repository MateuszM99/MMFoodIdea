class Comment {
    constructor(text, date) {
        this.text = text;
        this.date = date;
    }
}


const textInput = document.getElementById('text');
const commentSection = document.getElementById('commentSec');
const commentsQueue = [];

document.getElementById('submitButton').addEventListener('click', () => {
    
});

function clearInputField() {
    commentsQueue.push(textInput.value);
    textInput.value = "";
}

function sendComment() {
    let text = commentsQueue.shift() || "";
    if (text.trim() === "") return;

    let date = new Date();
    let comment = new Comment(text,date);
    sendCommentToHub(comment);
}

function addComment(comment) {
   
    let container = document.createElement('div');
    
    let text = document.createElement('p');
    text.innerHTML = comment.text;

    let date = document.createElement('span');
    var currentdate = new Date();
    date.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
   
    container.appendChild(text);
    container.appendChild(date);
    commentSection.appendChild(container);
}