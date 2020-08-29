
var counter = 0;



function addIngridient() {
    var div = document.createElement('div');

    div.id = `ingridient-${counter}`;

    var mainDiv = document.getElementById('ings')

    mainDiv.append(div);

    var nameLabel = document.createElement('label');

    nameLabel.textContent = "Name";

    nameLabel.htmlFor = 'ing-name';

    nameLabel.setAttribute('class', 'ing-label')

    var nameInput = document.createElement('input');

    nameInput.name = `Ingridients[${counter}].Name`;

    nameInput.id = 'ing-name';

    var quantityLabel = document.createElement('label');

    quantityLabel.textContent = "Quantity";

    quantityLabel.htmlFor = 'ing-quantity';

    quantityLabel.setAttribute('class', 'ing-label')

    var quantityInput = document.createElement('input');

    quantityInput.name = `Ingridients[${counter}].Quantity`;

    quantityInput.id = 'ing-quantity'

    var removeButton = document.createElement('input');

    removeButton.type = 'button';

    removeButton.value = "Remove";

    removeButton.className = "ingridient-input"

    removeButton.id = `removeButton-${counter}`;

    removeButton.setAttribute('onclick', `removeIngridient(${counter})`);

    div.append(nameLabel);
    div.append(nameInput);
    div.append(quantityLabel);
    div.append(quantityInput);
    div.append(removeButton);

    counter++;
}

function removeIngridient(id) {
    var div = document.getElementById(`ingridient-${id}`);

    for (i = id + 1; i < counter; i++) {

        let nextDiv = document.getElementById(`ingridient-${i}`)

        nextDiv.id = `ingridient-${i - 1}`

        var nameLabel = document.getElementsByName(`Ingridients[${i}].Name`)[0];

        if (nameLabel != null)
            nameLabel.name = `Ingridients[${i - 1}].Name`

        var quantityLabel = document.getElementsByName(`Ingridients[${i}].Quantity`)[0];

        if (quantityLabel != null)
            quantityLabel.name = `Ingridients[${i - 1}].Quantity`

        var removeButton = document.getElementById(`removeButton-${i}`)

        removeButton.id = `removeButton-${i - 1}`

        removeButton.setAttribute('onclick', `removeIngridient(${i - 1})`)
    }

    div.remove();

    counter--;
}


Array.prototype.forEach.call(
    document.querySelectorAll(".file-upload_button"),
    function (button) {
        const hiddenInput = button.parentElement.querySelector(".file-upload_input");
        const label = button.parentElement.querySelector(".file-upload_label");
        const defaultLabelText = "No file(s) selected";


        label.textContent = defaultLabelText;
        label.title = defaultLabelText;

        button.addEventListener("click", function () {
            hiddenInput.click();
        });

        hiddenInput.addEventListener("change", function () {
            const filenameList = Array.prototype.map.call(hiddenInput.files, function (file) {
                return file.name;
            });

            label.textContent = filenameList.join(", ") || defaultLabelText;
            label.title = label.textContent;
        });
    }
);