const path = require("path");
const fs = require("fs");
const fableSplitter = require("fable-splitter").default;
const browserSync = require("browser-sync").create();

const scriptPath = path.join(__dirname, "src", "App.fsx");

const splitterOptions = {
    entry: scriptPath,
    outDir: path.join(__dirname, "public"),
    babel:{
        "plugins": [
            ["@pika/web/assets/babel-plugin.js"]
        ]
    }
};

let previousInfo = null;

function compileFSharp(){
    fableSplitter(splitterOptions, previousInfo).then(info => {
        previousInfo = info;
    });
}

compileFSharp();

fs.watchFile(scriptPath, { interval: 500 }, (prev, current) => {
    console.log(`File change detected`);
    compileFSharp();
});

function isModuleRequest(url) {
    const pieces = url.split("/");
    const lastPiece = pieces && pieces[pieces.length - 1];
    const fileRegex = /\.(js|html|css|png|svg)$/;
    return !(fileRegex.test(lastPiece));
}

function es6Middleware(req,res,next){
    if (isModuleRequest(req.url) && req.url !== "/") {
        const content = fs.readFileSync(path.join(__dirname, "public", `${req.url}.js`), 'utf8');
        res.writeHead(200, {'Content-Type': 'application/javascript'});
        res.write(content);
        res.end();
    } else {
        next();
    }
}

browserSync.init({
    server: path.join(__dirname, "public"),
    watch: true,
    middleware: [ es6Middleware ],
    open: false
});