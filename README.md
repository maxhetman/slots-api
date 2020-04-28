Project is written using Onion architecture
(API, Application, Domain and Infrastructure layers)
Repository pattern used for data access

Technologies and libraries used:
- .Net core 3.1, EF core 3.1.3 
- SQLite for database(you can view it using DB Browser for SQLite)
- xUnit for unit tests
- automapper for mapping dto to entities and vice versa

Some concepts to better understand code:
	1. Dates are often treated as datediff (int) instead of Datetime for more efficient DB performance and for more clear semantics.
	2. "Enabled" slot means that slot is present for given date and day of the week. Slot might be enabled but not available
	3. "Available" slot means that user can actually use it.
	4. Days of weeks are implemented as flags enum

Important things to do:
	- add validation to API input DTOs
	- code needs some refactoring to be more testable
	- add more unit tests