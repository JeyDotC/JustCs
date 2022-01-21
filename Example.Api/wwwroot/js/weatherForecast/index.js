import { h1 } from "https://unpkg.com/@jeydotc/justjs@1.0.1/dist/browser/index.js";

function Index() {
    return h1({}, 'Hello From JustJs!');
}

document.getElementById('app').append(Index());