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

Pictures:

<a style="background-color:black;color:white;text-decoration:none;padding:4px 6px;font-family:-apple-system, BlinkMacSystemFont, &quot;San Francisco&quot;, &quot;Helvetica Neue&quot;, Helvetica, Ubuntu, Roboto, Noto, &quot;Segoe UI&quot;, Arial, sans-serif;font-size:12px;font-weight:bold;line-height:1.2;display:inline-block;border-radius:3px" href="https://unsplash.com/@maltewingen?utm_medium=referral&amp;utm_campaign=photographer-credit&amp;utm_content=creditBadge" target="_blank" rel="noopener noreferrer" title="Download free do whatever you want high-resolution photos from Malte Wingen"><span style="display:inline-block;padding:2px 3px"><svg xmlns="http://www.w3.org/2000/svg" style="height:12px;width:auto;position:relative;vertical-align:middle;top:-2px;fill:white" viewBox="0 0 32 32"><title>unsplash-logo</title><path d="M10 9V0h12v9H10zm12 5h10v18H0V14h10v9h12v-9z"></path></svg></span><span style="display:inline-block;padding:2px 3px">Malte Wingen</span></a>