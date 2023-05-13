function generateJSON(input) {
  let rows = input.slice(1);
  let headers = input[0].split('|').map(header => header.trim()).filter(header => header);
  let json = [];

  rows.forEach(row => {
    let values = row.split('|').map(value => value.trim()).filter(value => value);

    let town = values[0];
    let latitude = parseFloat(values[1]).toFixed(2);
    let longitude = parseFloat(values[2]).toFixed(2);

    let obj = {
      [headers[0]]: town,
      [headers[1]]: parseFloat(latitude),
      [headers[2]]: parseFloat(longitude),
    };

    json.push(obj);
  });

  return JSON.stringify(json);
}

console.log(generateJSON(['| Town | Latitude | Longitude |',
  '| Sofia | 42.696552 | 23.32601 |',
  '| Beijing | 39.913818 | 116.363625 |']
));