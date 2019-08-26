const net = require("net");
const fs = require("fs");
const path = require("path");
const { transformFromAstSync } = require("@babel/core");

const fableDefaultPort = 2000;

const outputFile = path.join(__dirname, "App.js");

if(fs.existsSync(outputFile)) {
    fs.unlinkSync(outputFile)
}

// Stolen from fable-splitter
function send(host, port, msg) {
    return new Promise((resolve, reject) => {
        const client = new net.Socket();
        let resolved = false;
        let buffer = "";

        client.connect(port, host, function() {
            client.write(JSON.stringify(msg));
        });

        client.on('error', function(err) {
            if (!resolved) {
                resolved = true;
                reject(err);
            }
        });

        client.on('data', function(data) {
            buffer += data.toString();
        });

        client.on('close', function() {
            if (!resolved) {
                resolved = true;
                resolve(JSON.parse(buffer));
            }
        });
    });
}

send( "127.0.0.1", fableDefaultPort, {
    path: path.join(__dirname, "App.fsx"),
    define: ["DEBUG"]
}).then(result => {
    console.log(`\nFable Cli, which we are debugging, result: \n${JSON.stringify(result)}\n`);

    const { code } = transformFromAstSync(result);
    console.log(`Babel result: \n${code}\n`);

    fs.writeFileSync(outputFile, code);
});