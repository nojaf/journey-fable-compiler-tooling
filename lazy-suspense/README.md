# Lazy/Suspense

This sample demonstrates how you can lazy-load a ReactElement using [React.lazy](https://reactjs.org/docs/code-splitting.html).
Originally I thought this would only work using `*.fsx` files and it turned out that this also works with `fs/fsproj` approach.

Hence the reason the sample is made in two flavours: `fsx/Paket` and `fsproj/NuGet`.

The folder `single-file` contains a sample to prove that you cannot compile a single `fs` file without an `fsproj`.