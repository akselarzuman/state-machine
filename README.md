# Jason State

![Jason Statham](https://raw.githubusercontent.com/akselarzuman/state-machine/dev/misc/logo.jpg)

Jason State is a simple state machine implementation. It's configured by a JSON file.

## Supported Platforms

* [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## Features

* Dependency injection friendly (can also be used standalone, see below)

## Table of Contents

1. [Why Jason State?](https://github.com/akselarzuman/state-machine#why-jason-state)
2. [Installation](https://github.com/akselarzuman/state-machine#installation)
3. [Usage](https://github.com/akselarzuman/state-machine#usage)
    - [Standalone Initialization](https://github.com/akselarzuman/state-machine#standalone-initialization)
      - [JasonStateStandalone](https://github.com/akselarzuman/state-machine#standalone)
    - [Microsoft.Extensions.DependencyInjection Initialization](https://github.com/akselarzuman/state-machine#microsoftextensionsdependencyinjection-initialization)
4. [License](https://github.com/akselarzuman/state-machine#license)

## Why Jason State?

- No need to worry about implementing State Pattern. With Jason State, it is already implemented!
- Because you use state pattern, your code is cleaner.
- Let the business need change! It'll give you the flexibility to change the flow just by the JSON file you provide. No need for deployment!



## Usage

First you need to provide a valid JSON file.
This JSON file must contain a **States** array. This array should have ![BaseState](https://github.com/akselarzuman/state-machine/blob/master/src/JasonState/Models/BaseState.cs) objects.
* **Namespace**: namespace of your state
* **Name**: Just the name of your file
* **NextState**: ![Next State](https://github.com/akselarzuman/state-machine/blob/master/src/JasonState/Models/NextState.cs) array contains ![Next State](https://github.com/akselarzuman/state-machine/blob/master/src/JasonState/Models/NextState.cs) objects
  * __Condition__: It's actually an if condition. Instead of using '==', use .Equals() method
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
          "Condition": "TestClientModel.FromEmail != null && TestClientModel.FromEmail.Equals(\"aksel@test.com\")",
          "State": "ValidatePaymentState"
        },
        {
          "Condition": "TestClientModel.FromEmail != null && TestClientModel.FromEmail.Equals(\"test@test.com\")",
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
          "Condition": "True",
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
States must inherit from ![BaseState](https://github.com/akselarzuman/state-machine/blob/master/src/JasonState/Models/BaseState.cs) and implement **Execute** method. You can use any dependency injection frameworks for construction injections. It will not break anything.

