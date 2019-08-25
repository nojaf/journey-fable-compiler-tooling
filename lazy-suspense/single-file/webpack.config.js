const path = require("path");

module.exports = {
    entry: path.join(__dirname, "App.fs"),
    output: {
        path: path.join(__dirname, "bin"),
        filename: "bundle.js"
    },
    module: {
        rules: [
            {
                test: /\.fs(x|proj)?$/,
                use: "fable-loader"
            }
        ]
    }
};