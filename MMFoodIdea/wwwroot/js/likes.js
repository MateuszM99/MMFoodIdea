function like(){
    var likes = document.getElementById("likes").textContent;
    likes++;
    document.getElementById("likes").textContent = likes;
    alert("ok");
}