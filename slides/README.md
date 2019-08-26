# Story

- How Fable works
    - F# AST to Babel AST by Fable.Cli
        - F# AST in AST Viewer
        
        https://jindraivanek.gitlab.io/ast-viewer/#?code=MQJwBAAgRAwgXAHQKoGcCmIUIHYHsBWAhgGYIB02ArgOZoAuCADoQMYDWhtWxhARgDZoyLXCDQIAzGQAMMhPwCWvHPRR1C2ACaEQmgExyAYn0FkYooZv78oAWABQD3IzTYwxgUPNiyAKRQAkth0GM4ODoJ0YAC2aAAWYAC8YCxihCEA8rz4YADaYFDEuLhQSYkAfAW8OqUAuuH2kWCEmprNYLxJ7QDUHUA
        
        - Compile F# to JavaScript: demo
        
        - Show that FCS needs a project and debug a script
            - show demo project
            - Rider Debug configuration
            - compile fable-library
            - debug, highlight what is going on at each breakpoint
            
        - Mention F# script package management PR https://github.com/fsharp/fslang-suggestions/issues/542
        - Question if nuget package are way to go?

- fable-splitter
    - js client that interacts with Fable Daemon
    
    - example node-js
        - commonjs option
        - `--run`
        - browser-sync combo, great experience so backend development
        
    - example pika
    
- fable-loader
    - Fable client, works in a similar fashion
    - elaborate on React lazy
        - both fsx & fsproj work
        - single fs file cannot be transpiled
        
- fable-compiler-js

    - explain early stage
    - relation to fable/repl
    - remark on the dependencies (@babel/core, ...)
    - no package management
    
- closing thoughts