function addItem() {
    let textElement = document.getElementById('newItemText');
    let valueElement = document.getElementById('newItemValue');

    const dropdownElement = document.getElementById("menu");
    let option = document.createElement("option");
    option.text = textElement.value;
    option.value = valueElement.value;
    dropdownElement.add(option);

    textElement.value = '';
    valueElement.value = '';
}