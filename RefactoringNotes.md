# Refactoring Code By

### By Jonathan Castillo Bello
### _e._ `jacastillob@gmail.com`

## Improvements and Tweaks

### Global Error Handling in ASP.NET Core Web API

- Basic Error code Implementation
- Room to implement a Logger (not implemented but easy to plug in)

### .NEt Framework Migrated -> 5.0

- Framework Migrated into 5.0
- Web server Startup migrated to the 5.0 MVC implementation

### Unit test included by Using xUnit-> (Microsoft.NET.Test.Sdk (Required))

- Basic test suits that can be enhanced(Just Services included) 


### Architectural Pattern

- An API must have more layers (Layered Pattern | MVC) to handle logic and to be extended -> Pattern implemented on its first iteration(more to do!)
- Strategy behavioural pattern implemented for the DataSources
- Singleton implemented for the Services and Storage

### SOLID principles

- this approach is not addressing some basic SOLID principles:
    - Single Responsability -> Products,ProductOptions,Product Controllers
    - Dependancy inversion  -> SQLite connection
    - Dependancy inversion  -> Services
