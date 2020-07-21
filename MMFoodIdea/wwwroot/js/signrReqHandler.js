var connection = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();

connection.on('reciveComment', addComment);

connection.start()
    .catch(error => {
        console.error(error.message);
    });

function sendCommentToHub(comment) {
    connection.invoke('PostComment', comment)
}