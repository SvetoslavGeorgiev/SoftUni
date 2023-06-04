function encodeAndDecodeMessages() {

    let buttonsElements = document.getElementsByTagName('button');
    let outputTextElement = document.querySelectorAll('#main div textarea')[1];
    outputTextElement.value = '';
    let senderButtonElement = buttonsElements[0];
    let receiverButtonElement = buttonsElements[1];

    function encode(e) {

        let textToEncode = e.currentTarget.parentNode.getElementsByTagName('textarea')[0].value;
        let encodedMessage = '';

        for (let index = 0; index < textToEncode.length; index++) {
            encodedMessage += String.fromCharCode(textToEncode.charCodeAt(index) + 1);
            
        }

        e.currentTarget.parentNode.getElementsByTagName('textarea')[0].value = '';
        outputTextElement.value = encodedMessage;

    }

    function decode(e) {

        let textToDecode = e.currentTarget.parentNode.getElementsByTagName('textarea')[0].value;
        let decodedMessage = '';

        for (let index = 0; index < textToDecode.length; index++) {
            decodedMessage += String.fromCharCode(textToDecode.charCodeAt(index) - 1);
            
        }

        outputTextElement.value = decodedMessage;
    }



    senderButtonElement.addEventListener('click', encode)

    receiverButtonElement.addEventListener('click', decode)


}