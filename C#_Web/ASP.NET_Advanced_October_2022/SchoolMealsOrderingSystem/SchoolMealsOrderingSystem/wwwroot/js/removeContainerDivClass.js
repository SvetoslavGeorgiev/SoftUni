document.addEventListener("DOMContentLoaded", function () {
    let itemToRemoveClassFrom = document.querySelector(".container");

    if (itemToRemoveClassFrom) {
        itemToRemoveClassFrom.classList.remove("container");
    }
});