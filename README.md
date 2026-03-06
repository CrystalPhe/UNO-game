# UNO Console Game (C#)

A console-based implementation of the classic **UNO card game** developed in C#.  
Players take turns playing cards, drawing from the deck, and using command-based input to interact with the game.

The project demonstrates **object-oriented programming concepts and modular game design**.

---

## Features
- Multiplayer turn-based UNO gameplay
- Deck generation, shuffling, and card drawing
- Player hand management
- Discard pile and turn tracking
- Command-based interaction system
- Support for action cards through extensible design

---

## Commands

The game supports several player commands:

| Command | Description |
|-------|-------------|
| `play <card>` | Play a card from your hand |
| `draw` | Draw a card from the deck |
| `show hand` | Display all cards in your hand |
| `uno` | Call UNO when you have one card left |

---

## Example Gameplay

<img width="450" alt="gameplay image" src="https://github.com/user-attachments/assets/2f7fffe3-8cc9-42d7-a8a8-40c62a7f39d9" />

## Game Concepts

### Cards
Each UNO card has a **color and value**. Some cards trigger special actions.

### Card Actions
Special cards trigger unique behaviors such as skipping turns or forcing players to draw cards.

### Players
Players have a **hand of cards** and take turns interacting with the game through commands.

### Deck
The deck contains all cards used in the game and supports **shuffling and drawing** operations.

### Discard Pile
The discard pile stores played cards and determines which cards can be played next.

### Commands
A command processing system interprets player input and executes game actions.

---

## Technologies

- **Language:** C#
- **Application Type:** .NET Console Application
- **Paradigm:** Object-Oriented Programming
- **Architecture Concepts:**
  - Abstraction
  - Inheritance
  - Command Pattern
  - Modular class design

---

## Project Structure

Main components of the system include:

- `Program` – Entry point that starts the game
- `UnoGame` – Manages game flow, turns, and overall state
- `Deck` – Handles card generation, shuffling, and drawing
- `Card` – Represents individual UNO cards
- `CardAction` – Base class for special card actions
- `Player` – Stores player information
- `PlayerHand` – Manages cards held by a player
- `Command` – Base class for player commands
- `CommandProcessor` – Processes and executes player input
- `PlayCardCommand`, `DrawCardCommand`, `ShowHandCommand` – Gameplay commands

Class Diagram:

<img width="500" alt="classdiagram" src="https://github.com/user-attachments/assets/ccfa5558-aa1c-4ff4-8ea2-fbf9eceb0fde" />

