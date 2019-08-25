const path = require("path");
const fs = require("fs");
const start = require("fable-compiler").default;
const { transformFromAstSync } = require("@babel/core");

const outputFile = path.join(__dirname, "App.js");

if(fs.existsSync(outputFile)) {
    fs.unlinkSync(outputFile)
}

const fableCliArgs = {};
const fableCompiler = start(fableCliArgs);

fableCompiler.send({
    path: path.join(__dirname, "App.fsx"),
    define: ["DEBUG"]
}).then(result => {
    console.log(`\nFable Cli result: \n${JSON.stringify(result)}\n`);
    fableCompiler.close();

    const { code } = transformFromAstSync(result);
    console.log(`Babel result: \n${code}\n`);

    fs.writeFileSync(outputFile, code);
});