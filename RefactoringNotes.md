# Refactoring Code By

### By Jonathan Castillo Bello
### _e._ `jacastillob@gmail.com`

## Findings

### Architectural Pattern
- API usually have more layers (Layered Pattern | MVC)

### SOLID principal

- Models are breaking basic design principles such:
    - Single Responsability -> Products,ProductOptions
    - Dependancy inversion  -> SQLite connectio

### Blocking Code

- Currently the way database connections and queries are handled will lead into a Blocking Code,therefore, the products API won't be able to handle varirous requests