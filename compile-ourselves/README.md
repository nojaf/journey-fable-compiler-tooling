# Compile F# from scratch

Using only `fable-compiler` and `@babel\core` we can compile F# to JavaScript.
The main idea of this sample is to have a bare-bone experience and highlight why things like `fable-splitter` and `fable-loader` exist.

**Warning:** line 1 of `App.fsx` contains a hardcoded path to my local `Fable.Core` dll.


## Run 

> yarn

> node index.js 