![CO-2](https://github.com/user-attachments/assets/44d96487-a2f2-433f-90ba-caa677807c10)

## 🥁 CarnaCode 2026 - Challenge 14 - Command

Hi, I am Felipe Parizzi Galli, and this is the space where I share my learning journey during the **CarnaCode 2026** challenge, created by [balta.io](https://balta.io). 👻

Here you will find projects, exercises, and code I am building during the challenge. The goal is to practice hands-on, test ideas, and record my progress in technology.

### About this challenge
In the **Command** challenge, I had to solve a real problem by implementing the related **Design Pattern**.
During this process, I learned about:
* ✅ Software Best Practices
* ✅ Clean Code
* ✅ SOLID
* ✅ Design Patterns

## Problem
A text editor needs to support undo/redo operations for multiple actions, such as typing, deleting, and formatting. The original code called editor methods directly, which made it impossible to undo operations or maintain a command history.

## About CarnaCode 2026
The **CarnaCode 2026** challenge consists of implementing all 23 design patterns in real-world scenarios. Throughout the 23 challenges in this journey, participants learn and practice how to identify non-scalable code and solve problems using market-standard patterns.

### eBook - Design Patterns Fundamentals
My main source of knowledge during the challenge was the free eBook [Design Patterns Fundamentals](https://lp.balta.io/ebook-fundamentos-design-patterns).

## Command Pattern Implementation
The solution applies the Command Pattern by encapsulating each editor action into its own command object. Instead of calling the text editor directly, the application creates commands and sends them to a command invoker.

The implementation includes:
* `ICommand`, which defines the contract for `Execute`, `Undo`, and `Redo` operations.
* `WriteTextCommand`, which inserts text and can remove it when undone.
* `DeleteTextCommand`, which stores the deleted text so it can be restored later.
* `MakeTextBoldCommand`, which applies and removes bold formatting.
* `SetCursorPositionCommand`, which moves the cursor and can restore the previous position.
* `CommandInvoker`, which keeps undo and redo stacks to manage command history.
* `EditorApplication`, which demonstrates the basic undo/redo flow.
* `EditorWithOperationLog`, which adds an operation log to track executed actions.
* `EditorWithStateHistory`, which records named command histories and replays them when needed.

With this structure, editor operations are decoupled from the application flow, and each action becomes reversible and reusable.
