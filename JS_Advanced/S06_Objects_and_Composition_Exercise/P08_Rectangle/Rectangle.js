function rectangle(width, height, color) {

    let rectangle = { width: Number(width), height: Number(height), color: color[0].toUpperCase() + color.slice(1) };

    rectangle.calcArea = function () {
        return this.width * this.height;
    }

    return rectangle;
}




let rect = rectangle(4, 5, 'red');
console.log(typeof (rect.width));
console.log(rect.height);
console.log(rect.color);
console.log(typeof (rect.calcArea()));
