function extract(input) {
    let contentElement = document.getElementById(input);

    let pattern = /\(([^(]+)\)/g;
    let matches = contentElement.textContent.matchAll(pattern);
    let result = [];
    for (const match of matches) {
        result.push(match[1])
    }

    return result.join('; ');
}