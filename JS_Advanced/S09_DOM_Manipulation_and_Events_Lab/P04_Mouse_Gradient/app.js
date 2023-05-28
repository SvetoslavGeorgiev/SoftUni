function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');

    gradientElement.addEventListener('mousemove', move, true)
    gradientElement.addEventListener('mouseout', moveOut, true)

    function move(e) {
        
        let perCent = Math.floor(e.offsetX / (e.target.clientWidth) * 100);

        let result = document.getElementById('result');

        result.textContent = `${perCent}%`
    }

    function moveOut(event) {
        document.getElementById('result').textContent = "";
      }
    
}