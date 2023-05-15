function Edit_Element(element, match, replacer) {

    let pattern = new RegExp(match, 'g');
    element.textContent = element.textContent.replace(pattern, replacer);

}