# Access Control Management System - Design Decisions

This document outlines the key design choices made during the development of the Access Control Management System, with a focus on the underlying principles and rationale behind them.

## Overall Architecture

- **Blazor Server:** I opted for Blazor Server for its simplicity and seamless real-time communication capabilities using SignalR. This was deemed suitable for the project's scope and requirements, avoiding the additional complexity of a WASM-based frontend. I considered implementing this but using the KISS principle I figured it would make more sense to start with state being represented in the server and not the client as much as possible. I'm a big fan of some (not all) of the principles suggested by [HTMX](https://htmx.org/essays/hypermedia-apis-vs-data-apis/).

## Domain-Driven Design (DDD)

- **`Door` Entity:**  The `Door` class encapsulates the core domain concept of a door, including its state (open/closed, locked/unlocked, alarmed/inactive) and behavior (e.g., `UpdateState` method).
- **Data Annotations:** I used data annotations (`[Required]`, `[StringLength]`) to express validation rules directly on the `Door` entity, enhancing its self-validation capabilities. Obviously not functional as no EF or db is implemented.
- **Repository Pattern:** The `IDoorRepository` and `DoorRepository` implement the repository pattern to abstract data access and persistence. This promotes loose coupling betIen the domain model and the underlying storage mechanism, allowing for flexibility and easier future changes (e.g., switching from in-memory storage to a database).
- **Singleton Repository:**  I made the `DoorRepository` a singleton service to maintain the door state throughout the application's lifetime, simplifying the implementation for this initial phase and not having to write to anything for persistence.

## Other Design Choices

- **SignalR for Real-Time Updates:** SignalR was chosen to enable real-time communication betIen the server and all connected clients. This ensures that any changes made to door states are instantly reflected across the entire application.
- **MudBlazor for UI:** I used MudBlazor, a popular component library, to create a modern and visually appealing user interface with minimal CSS effort.
- **Minimalistic UI:**  I focused on a simple and functional UI design to prioritize core functionality and meet the project's time constraints. Future enhancements can focus on refining the UI and adding more advanced features.

## Rationale

- **Simplicity and Maintainability:** The design choices prioritize simplicity and maintainability, making the code easier to understand, modify, and extend.
- **Flexibility:**  The use of interfaces and dependency injection allows for easy replacement of components (e.g., switching to a database-backed repository) as the application evolves.
- **Real-Time User Experience:** SignalR ensures a responsive and engaging user experience by providing instant updates across all clients.
- **Rapid Development:**  MudBlazor enables rapid UI development with pre-built components, saving time and effort.

## Future Considerations

- **State Change Validation:**  Implement more robust validation logic within the `Door` entity or a separate service layer to prevent invalid state transitions (e.g., preventing a door from being locked while open).
- **Database Integration:**  Replace the in-memory storage with a database for persistent data storage and to handle potential concurrency issues.
- **Authentication and Authorization:** Add user authentication and authorization mechanisms to control access and restrict actions based on user roles.
- **UI Enhancements:**  Improve the UI with additional features, styling, and responsiveness. Focus on providing clearer feedback to the user about the success or failure of door state changes, potentially using snackbars or other visual cues.s
- **Locking Mechanism:** Implement a robust locking mechanism (potentially using a distributed lock or database transactions) to handle concurrent door state updates and ensure data consistency.
- **Async Simulation:** Introduce artificial delays in door state updates to simulate real-world scenarios where actions might take some time to complete.
- **Microservices Architecture:**  Explore the possibility of refactoring the application into a microservices architecture, especially if the optional requirement of accessing data via an API is pursued. This would involve creating separate services for the frontend, backend API, and potentially other functionalities.
- **Graceful Error Handling:**  Enhance error handling, particularly around SignalR connection issues, to provide more informative feedback to the user and prevent application crashes.
- **Structured Logging:**  Implement structured logging using a framework like Serilog or NLog to capture detailed information about application events, errors, and warnings in a machine-readable format, facilitating easier troubleshooting and analysis.
- **Door State History:**  Implement a data structure for DoorState allowing for us to record a history of state changes for a door.
- **Comprehensive Testing:**  Expand the test suite to include bUnit tests for Razor components and add more coverage for existing xUnit tests to ensure the application's correctness and robustness. 

There's plenty of additional features I could expound on; I think focusing on what I think's missing right now for being up to my standards instead of a bunch of interesting new features.