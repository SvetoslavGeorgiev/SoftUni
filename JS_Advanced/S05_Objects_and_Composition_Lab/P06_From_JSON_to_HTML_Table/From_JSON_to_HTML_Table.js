function solve(input) {
    const result = [];
        result.push('<table>');

        const data = JSON.parse(input);

        const props = Object.keys(data[0]);

        result.push(
          `  <tr>${props.map((p) => `<th>${escapeHtml(p)}</th>`).join('')}</tr>`
        );

        for (const entry of data) {
          result.push(
            `  <tr>${props
              .map((p) => `<td>${escapeHtml(entry[p])}</td>`)
              .join('')}</tr>`
          );
        }

        result.push('</table>');

        return result.join('\n');

        function escapeHtml(value) {
          return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
        }
}


console.log(solve(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"Rumen",
"Score":6}]`
));