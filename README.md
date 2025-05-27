# 🧙‍♂️ Fantasy Game Simulation

This project is a **C# console application** designed to simulate a fantasy game world using key software engineering principles. The goal is to demonstrate **four core design patterns**—Factory, Singleton, Repository, and Adapter—through dynamic character creation, game state management, inventory control, and skill integration.

## 📖 Table of Contents

- [Project Overview](#project-overview)
- [Design Patterns Implemented](#design-patterns-implemented)
  - [Factory Pattern](#1-factory-pattern)
  - [Singleton Pattern](#2-singleton-pattern)
  - [Repository Pattern](#3-repository-pattern)
  - [Adapter Pattern](#4-adapter-pattern)
- [Getting Started](#getting-started)
- [Usage](#usage)

## 📘 Project Overview

This application simulates a small-scale game environment where:
- Characters like **Mages**, **Warriors**, and **Archers** can be created.
- A **singleton game world** manages the environment and characters.
- An **inventory system** manages weapons, potions, and artifacts.
- **Legacy skills** are adapted into a modern skill system.

## 🧩 Design Patterns Implemented

### 1. 🏭 Factory Pattern

**Purpose:**  
Used to create characters dynamically based on type without instantiating them directly.

**Implementation:**
```csharp
public class CharacterFactory {
    public static Character CreateCharacter(string type, string name) {
        Character character;

        switch (type.ToLower()) {
            case "warrior":
            character = new Warrior(name);
            break;
            case "mage":
            character = new Mage(name);
            break;
            case "archer":
            character = new Archer(name);
            break;
            default:
            throw new ArgumentException("Invalid character type");
        }

        return character;
    }
}
```

**Usage:**
```csharp
Character mage = CharacterFactory.CreateCharacter("mage", "Elandra");
Character warrior = CharacterFactory.CreateCharacter("warrior", "Gorim");
```

### 2. 🔁 Singleton Pattern

**Purpose:**  
Ensures a single instance of the game world exists throughout the simulation.

**Implementation:**
```csharp
public class GameState {
    private static GameState _instance;
    private static readonly object _lock = new object();

    public int CurrentLevel { get; set; } = 1;
    public List<Character> Characters { get; } = new List<Character>();
    public string Environment { get; set; } = "Forest";

    private GameState() { }

    public static GameState GetInstance() {
        if (_instance == null) {
            lock (_lock) {
                if (_instance == null) {
                    _instance = new GameState();
                }
            }
        }
        return _instance;
    }

    public void DisplayWorldStatus() {
        Console.WriteLine($"Current Level: {CurrentLevel}");
        Console.WriteLine($"Environment: {Environment}");
        Console.WriteLine("Characters in the game:");
        foreach (Character character in Characters) {
            character.DisplayStats();
        }
    }
}
```

**Usage:**
```csharp
GameWorld world = GameWorld.GetInstance();
world.Environment = "Mystic Ruins";
world.CurrentLevel = 1;
```

### 3. 📦 Repository Pattern

**Purpose:**  
Manages inventory items in a decoupled and testable manner using CRUD operations.

**Implementation:**
```csharp
public class InventoryRepository : IInventoryRepository {
    private readonly List<Item> _items = new List<Item>();

    public void AddItem(Item item) {
        _items.Add(item);
    }
    public void RemoveItem(string itemName) {
        _items.RemoveAll(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
    }
    public IEnumerable<Item> GetItems() {
        return _items;
    }
    public Item FindItemByName(string name) {
        return _items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
```

**Usage:**
```csharp
IInventoryRepository inventory = new InventoryRepository();
inventory.AddItem(new Item("Sword of Truth", "Weapon"));
inventory.GetItems();
inventory.FindItemByName("Sword of Truth");
inventory.RemoveItem("Sword of truth");
```

### 4. 🔌 Adapter Pattern

**Purpose:**  
Allows legacy skill classes with incompatible interfaces to be used in the new skill system.

**Legacy Skill:**
```csharp
public class LegacySkill {
    public string SkillName { get; }
    public int Power { get; }

    public LegacySkill(string skillName, int power) {
        SkillName = skillName;
        Power = power;
    }

    public void ExecuteLegacySkill() {
        Console.WriteLine($"Executing legacy skill: {SkillName} with power {Power}");
    }
}
```

**New Interface & Adapter:**
```csharp
public interface ISkill
{
    string Name { get; }
    void UseSkill();
}

public class LegacySkillAdapter : ISkill {
    private readonly LegacySkill _legacySkill;

    public LegacySkillAdapter(LegacySkill legacySkill) {
        _legacySkill = legacySkill;
    }

    public string Name => _legacySkill.SkillName;

    public void UseSkill() {
        _legacySkill.ExecuteLegacySkill();
    }
}
```

**Usage:**
```csharp
LegacySkill oldSkill = new LegacySkill("Ancient Blast", 50);
ISkill adaptedSkill = new LegacySkillAdapter(oldSkill);
warrior.Skills.Add(adaptedSkill);
```

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

### Run the Application

```bash
git clone https://github.com/mr-reutcky/fantasy-game-simulation.git
cd fantasy-game-simulation
dotnet build
dotnet run
```

## 🕹️ Usage

This application will:
- Initialize the game world
- Create characters
- Add inventory items
- Adapt legacy skills and assign them
