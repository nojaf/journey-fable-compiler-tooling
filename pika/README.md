# Pika

[Pika](https://www.pika.dev/about/) is a project to move the JavaScript ecosystem forward.<br />
The main idea is that we don't need a bundle anymore and using `fable-splitter` we can compile our individual files to ES6 modules.
Those can then be served by [browser-sync](https://www.browsersync.io/) and create a modern developer experience.

## Running

> yarn

The `postinstall` script should trigger Paket and Pika.

> yarn start 