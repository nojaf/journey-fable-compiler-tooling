# A Journey into the Compiler and Tooling

When I wanted to add the capability of compiling F# scripts to Fable, I had to explore the infrastructure of the compiler as well as its JS clients, like fable-loader and fable-splitter. In this talk we will do this journey together to understand how all the pieces fit together so, maybe in the future, you can contribute a new feature to the compiler too.

## Requirements for the demo's

Paket should be installed as global cli tool:

> dotnet tool install -g Paket

And obviously you need everything necessary to work with Fable in general (see [docs](https://fable.io/docs/2-steps/setup.html)).

## Questions?

Each sample has a README file with some context.
Don't hesitate to open an issue when you have additional questions.