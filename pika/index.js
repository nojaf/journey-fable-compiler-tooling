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
    const fileRegex = /\.(js|html|css|png|svg|ico)$/;
    return !(fileRegex.test(lastPiece));
}

const oneDayInSeconds = 60 * 60 * 24;
const cacheHeader = {'Cache-Control':`public,max-age=${oneDayInSeconds}`};
const contentTypeHeader = {'Content-Type': 'application/javascript'};

function es6Middleware(req,res,next){
    if (isModuleRequest(req.url) && req.url !== "/") {
        const content = fs.readFileSync(path.join(__dirname, "public", `${req.url}.js`), 'utf8');
        const headers =
            (/^\/(fable|Fable|lib).*\/.*/.test(req.url)) ?
                Object.assign(res.headers || {}, cacheHeader, contentTypeHeader) :
                Object.assign(res.headers || {}, contentTypeHeader) ;

        res.writeHead(200, headers);
        res.write(content);
        res.end();
    } else {
        next();
    }
}

function cacheWebModules(req, res, next){
    if (/^\/web_modules\/*./.test(req.url) && req.url !== "/") {
        res.writeHead(200, Object.assign(res.headers || {}, cacheHeader, contentTypeHeader));
        const content = fs.readFileSync(path.join(__dirname, "public", `${req.url}`));
        res.write(content);
        res.end();
    }
    else {
        next();
    }
}

browserSync.init({
    server: path.join(__dirname, "public"),
    watch: true,
    middleware: [ es6Middleware, cacheWebModules ],
    open: false
});