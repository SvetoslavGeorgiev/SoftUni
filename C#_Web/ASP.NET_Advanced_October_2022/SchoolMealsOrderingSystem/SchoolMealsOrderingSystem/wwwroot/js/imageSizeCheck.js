function checkFileSize() {
    let fileInput = document.getElementById('file');
    let maxSize = 3.2 * 1024 * 1024; // 1 MB in bytes

    if (fileInput.files.length > 0) {
        let fileSize = fileInput.files[0].size; // Get the file size in bytes
        if (fileSize > maxSize) {
            document.getElementById('error').innerText = 'File size exceeds the maximum allowed size (3.2 MB).';
            fileInput.value = ''; // Clear the file input
        } else {
            document.getElementById('error').innerText = '';
        }
    }
}
