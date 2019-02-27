# Jason State

![Jason Statham](https://raw.githubusercontent.com/akselarzuman/state-machine/dev/misc/logo.jpg)

Jason State is a simple state machine implementation. It's configured by a JSON file.

#### Why Jason State?
- No need to worry about implementing State Pattern. With Jason State, it is already implemented!
- Because you use state pattern, your code is cleaner.
- Let the business need change! It'll give you the flexibility to change the flow just by the JSON file you provide. No need for deployment!

#### Usage
First you need to provide a JSON file.
This JSON file must contain a **States** array. This array should have ![BaseState](https://github.com/akselarzuman/state-machine/blob/master/src/JasonState/Models/BaseState.cs) objects.
