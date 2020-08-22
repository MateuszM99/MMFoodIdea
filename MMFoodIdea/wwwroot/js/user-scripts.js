
function addProfilePic(){  
    document.querySelector(".pop-up").style.display = "flex";
}

function closePopUp() {
    document.querySelector(".pop-up").style.display = "none";
}

const inputImg = document.getElementById("image-input");
const previewContainer = document.getElementById("imagePreview");
const previewImage = previewContainer.querySelector(".preview-profile-image");
const previewText = previewContainer.querySelector(".preview-text");

inputImg.addEventListener("change", function () {

    const file = this.files[0];

    if (file) {
        const reader = new FileReader();
        previewText.style.display = "none";
        previewImage.style.display = "block";

        reader.addEventListener("load", function () {
            console.log(inputImg);
            previewImage.setAttribute("src", this.result);
        });

        reader.readAsDataURL(file);

    } else {
        previewText.style.display = null;
        previewImage.style.display = null;
        previewImage.setAttribute("src", "");
    }
});

function loadRecipes() {

}

function hideRecipes() {
    document.getElementById("recipes").style.display = "none";
    document.getElementById("liked").style.display = "block";
}

function hideLiked() {
    document.getElementById("recipes").style.display = "block";
    document.getElementById("liked").style.display = "none";
}