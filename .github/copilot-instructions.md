## General

- Make only high confidence suggestions when reviewing code changes.
- Never change NuGet.config files unless explicitly asked to.

## Formatting

- Apply code-formatting style defined in `.editorconfig`.
- Prefer file-scoped namespace declarations and single-line using directives.
- Insert a newline before the opening curly brace of any code block (e.g., after `if`, `for`, `while`, `foreach`, `using`, `try`, etc.).
- Ensure that the final return statement of a method is on its own line.
- Use pattern matching and switch expressions wherever possible.
- Use `nameof` instead of string literals when referring to member names.

### Nullable Reference Types

- Declare variables non-nullable, and check for `null` at entry points.
- Always use `is null` or `is not null` instead of `== null` or `!= null`.
- Trust the C# null annotations and don't add null checks when the type system says a value cannot be null.

### Naming Conventions

- Use PascalCase for class, interface, enum, and method names.
- Use camelCase for local variables and method parameters.
- Use ALL_CAPS for constants.
- File names should match the main class or type they contain and use the `.cs` extension.

### Commenting

- Use XML documentation comments (`///`) for all public APIs.
- Add inline comments for complex or non-obvious logic.
- Update or remove outdated comments.

### Async/Await

- Prefer async/await for asynchronous operations.
- Name async methods with an `Async` suffix.
- Avoid using `async void` except for event handlers.

### Dependency Injection

- Use dependency injection for services and dependencies.
- Avoid static or singleton patterns unless necessary.

### Error Handling

- Use custom exception types where appropriate.
- Log exceptions using the configured logging framework.
- Avoid catching general exceptions unless necessary.

### Immutability

- Prefer `readonly` for fields where possible.
- Use immutable types for DTOs and value objects.

### Testing

- We use NUnit tests.
- We use Shouldly for assertions.
- Use FakeItEasy for mocking in tests.
- Copy existing style in nearby files for test method names and capitalization.
- Test method names should clearly describe the scenario and expected outcome.
- Aim for high test coverage of critical code paths.

### Resource Management

- Always use `using` statements or declarations for disposable resources.

### Magic Values

- Avoid magic strings and numbers; use constants or enums instead.

### Logging

- Use the configured logging framework for all logging.
- Prefer structured logging over plain text messages.
