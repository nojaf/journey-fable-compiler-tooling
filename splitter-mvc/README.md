# Splitter MVC

This sample contains an Express web application made with Fable.

## Run

> yarn

Open two terminals:

> yarn start

and

> yarn sync

This will compile F# using `fable-splitter` and run the `bin\App.js` with NodeJS.
The other terminal will act as a proxy-server (using [browser-sync](https://www.browsersync.io/)) and reload the browser when any file changes.