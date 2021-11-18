# Refactoring Code By

### By Jonathan Castillo Bello
### _e._ `jacastillob@gmail.com`

## Findings

### .NEt Framework Migrated -> 5.0

- Framework Migrated into 5.0
- Web server Startup migrated to the 5.0 MVC implementation 

### Architectural Pattern

- API usually have more layers (Layered Pattern | MVC) -> Patter implemented on its first iteration

### SOLID principal

- Models are breaking basic design principles such:
    - Single Responsability -> Products,ProductOptions,Product Controllers
    - Dependancy inversion  -> SQLite connection

### Blocking Code

- Currently the way database connections and queries are handled will lead into a Blocking Code,therefore, the products API won't be able to handle varirous requests