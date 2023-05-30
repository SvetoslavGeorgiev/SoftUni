function attachEventsListeners() {

    // Function to convert seconds to other time units
    function convertSeconds(seconds) {
        const minutes = seconds / 60;
        const hours = minutes / 60;
        const days = hours / 24;
        return { minutes, hours, days };
    }

    // Function to convert minutes to other time units
    function convertMinutes(minutes) {
        const seconds = minutes * 60;
        const hours = minutes / 60;
        const days = hours / 24;
        return { seconds, hours, days };
    }

    // Function to convert hours to other time units
    function convertHours(hours) {
        const seconds = hours * 60 * 60;
        const minutes = hours * 60;
        const days = hours / 24;
        return { seconds, minutes, days };
    }

    // Function to convert days to other time units
    function convertDays(days) {
        const seconds = days * 24 * 60 * 60;
        const minutes = days * 24 * 60;
        const hours = days * 24;
        return { seconds, minutes, hours };
    }

    // Event listener for all convert buttons
    const convertBtns = document.querySelectorAll('input[type=button]');

    for (const btn of convertBtns) {
        btn.addEventListener('click', () => {

            
            const btnForElement = btn.id;
            const elementTextbox = btnForElement.slice(0, -3)
            console.log(elementTextbox);
            const inputValue = parseFloat(document.getElementById(elementTextbox).value);

            let convertedValues = {};

            switch (btnForElement) {
                case 'secondsBtn':
                    convertedValues = convertSeconds(inputValue);
                    break;
                case 'minutesBtn':
                    convertedValues = convertMinutes(inputValue);
                    break;
                case 'hoursBtn':
                    convertedValues = convertHours(inputValue);
                    break;
                case 'daysBtn':
                    convertedValues = convertDays(inputValue);
                    break;
            }

            // Update the input fields with the converted values
            Object.keys(convertedValues).forEach(key => {
                document.getElementById(key).value = convertedValues[key];
            });
        });
    }
}