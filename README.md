# StateContainersDemo

## Description

**StateContainersDemo** is a mobile application built with .NET MAUI that demonstrates how to manage user state using **StateContainers**. This application handles states such as user authentication, data loading, and authentication success. **StateContainers** enable centralized state management and facilitate communication between different components and pages of the application without the need to explicitly pass data during navigation.

## Features

- **Centralized State Management**: Improves maintainability and keeps the code organized.
- **Simplified Communication**: Makes it easier to communicate between components that are not directly related in the navigation hierarchy.
- **Reactivity**: Views automatically update when the state changes.
- **Reusability**: The same state container can be reused across multiple components or pages.

## Requirements

- .NET 6 SDK or higher.
- Visual Studio 2022 or higher (with .NET MAUI development tools).
- **CommunityToolkit.Maui** package for state management.

## Installation

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/rretamal/StateContainersDemo.git
   ```

2. Open the solution in Visual Studio 2022 or higher.

3. Ensure the **CommunityToolkit.Maui** package is installed. If it's not installed, you can add it using the NuGet Package Manager or run the following command in the NuGet Package Manager console:

   ```bash
   Install-Package CommunityToolkit.Maui
   ```

4. Restore NuGet packages and build the solution.

## Project Structure

The project is structured as follows:

- **Models/**: Contains the data models used for state management.
- **ViewModels/**: Contains the ViewModels that manage the UI logic, including state handling.
- **Views/**: Contains the application's pages, such as `LoginPage.xaml` for user login.

## Demo

The project includes a simple demonstration of an authentication flow:

1. **Login**: The user enters their credentials.
2. **Loading**: A loading state simulates authentication.
3. **Success**: The user is successfully authenticated and presented with the success state.

## How to Run

1. Open the solution in Visual Studio.
2. Select the target platform (Android, iOS, or Windows).
3. Build and run the application.

## Code Example

Here is an example of how state is managed in the application:

```csharp
public class UserState
{
    public bool IsAuthenticated { get; set; }
    public string Username { get; set; }
}

public class StateContainer<T>
{
    private T _value;

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            NotifyStateChanged();
        }
    }

    public event Action OnStateChanged;

    private void NotifyStateChanged() => OnStateChanged?.Invoke();
}
```

## Contribution

Feel free to contribute to this project by submitting pull requests or reporting issues on GitHub.
