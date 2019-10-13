# Jason State

![Jason Statham](https://raw.githubusercontent.com/akselarzuman/state-machine/dev/misc/logo.jpg)

Jason State is a simple state machine implementation. It's configured by a JSON file.

## Supported Platforms

* [.NET Standard 2.1](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)
* [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## Features

* Dependency injection friendly (can also be used standalone, see below)

## Table of Contents

1. [Why Jason State?](https://github.com/akselarzuman/state-machine#why-jason-state)
2. [Installation](https://github.com/akselarzuman/state-machine#installation)
3. [Usage](https://github.com/akselarzuman/state-machine#usage)
    - [Json File](https://github.com/akselarzuman/state-machine#json)
    - [State Implementation](https://github.com/akselarzuman/state-machine#state-implementation)
    - [State Context](https://github.com/akselarzuman/state-machine#state-context)
    - [Microsoft.Extensions.DependencyInjection Initialization](https://github.com/akselarzuman/state-machine#microsoftextensionsdependencyinjection-initialization)
4. [License](https://github.com/akselarzuman/state-machine#license)

## Why Jason State?

- No need to worry about implementing State Pattern. With Jason State, it is already implemented!
- Because you use state pattern, your code is cleaner.
- Let the business need change! It'll give you the flexibility to change the flow just by the JSON file you provide. No need for deployment!
- Supports sync and async operations!

## Installation

## Usage
### Json
First you need to provide a valid JSON file.
This JSON file must contain a **States** array. This array should have ![BaseState](https://github.com/akselarzuman/state-machine/blob/master/src/JasonState/Models/BaseState.cs) objects.
* **Namespace**: namespace of your state
* **Name**: Just the name of your state file
* **NextState**: ![Next State](https://github.com/akselarzuman/state-machine/blob/master/src/JasonState/Models/NextState.cs) array contains ![Next State](https://github.com/akselarzuman/state-machine/blob/master/src/JasonState/Models/NextState.cs) objects
  * __Condition__: The condition for the states execution.
  * __State__: State is next state's name. No need to provide namespace
* **ErrorState**: Name of your state's error state. This state will be executed only if the current state has an exception that you don't handle. Error state can be different for each state.

An example of a valid JSON file can be found throug ![here](https://github.com/akselarzuman/state-machine/blob/master/src/TestClient/Files/StateMachine.json)

```json
{
  "States": [
    {
      "Namespace": "TestClient.Impls.States",
      "Name": "InitialState",
      "NextState": [
        {
          "Condition": "!string.IsNullOrEmpty(FromEmail) && FromEmail.Equals(\"aksel@test.com\")",
          "State": "ValidatePaymentState"
        },
        {
          "Condition": "!string.IsNullOrEmpty(FromEmail) && FromEmail.Equals(\"test@test.com\")",
          "State": "FinalState"
        }
      ],
      "ErrorState": "ErrorState"
    },
    {
      "Namespace": "TestClient.Impls.States",
      "Name": "ErrorState",
      "NextState": [
        {
          "Condition": "true",
          "State": "FinalState"
        }
      ],
      "ErrorState": null
    },
    {
      "Namespace": "TestClient.Impls.States",
      "Name": "FinalState",
      "NextState": null,
      "ErrorState": null
    }
  ]
}
```

### State Implementation

States must inherit from ![BaseState](https://github.com/akselarzuman/state-machine/blob/master/src/JasonState/Models/BaseState.cs) and implement **Execute** method with your state context. You can use any dependency injection framework for construction injections. It will not break anything.

```csharp
public class InitialState : BaseState<TestStateContext>
{
    public override void Execute(TestStateContext context)
    {
      // do the magic
    }
}
```

### State Context

Jason State allows you to add any kind of object to the context. Everything you need during the state execution should be in the context.

```csharp
public class TestStateContext
{
    public long CreditCardNumber { get; set; }

    public string CardHolderName { get; set; }

    public decimal Amount { get; set; }
}

public class InitialState : BaseState<TestStateContext>
{
    public override void Execute(TestStateContext context)
    {
        context.CreditCardNumber = "4545454545454545";
    }
}
```

### Microsoft.Extensions.DependencyInjection Initialization

By referencing JasonState.Extension, register necessary dependencies to ServiceCollection as follows
```csharp
serviceCollection.AddJasonState<TestStateContext>();
```
or
```csharp
serviceCollection.AddAsyncJasonState<TestStateContext>();
```

## Samples

TestClient can be found ![here](https://github.com/akselarzuman/state-machine/tree/master/src/samples/TestClient)
AsyncTestClient can be found ![here](https://github.com/akselarzuman/state-machine/tree/master/src/samples/AsyncTestClient)

## License
Licensed under MIT, see [LICENSE](LICENSE) for the full text.
