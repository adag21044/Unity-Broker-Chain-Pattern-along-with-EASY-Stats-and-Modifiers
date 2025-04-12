# 🧠 Unity Broker Chain Pattern - Stats & Modifiers System

This Unity sample project demonstrates the **Broker Chain Pattern** combined with an extendable **stat-modifier system**, inspired by **EASY stats architecture**. It is designed for educational purposes and provides a clear, modular example of how to build scalable stat logic in a game using SOLID principles and design patterns.

---

## 📌 Features

- 🧱 **Stat System**: Flexible base value handling with real-time modifier updates.
- 🔗 **Broker Pattern**: Acts as a chain of responsibility to process stat modifiers.
- 🔧 **Modifiers**: Modular stat modifiers (attack, defense, timed) with priority-based application.
- ⏳ **Timed Modifier Support**: Expire modifiers after a set duration.
- 🎮 **In-Game Trigger Handling**: Boost stats via interaction with tagged objects.
- 📈 **Real-Time Debugging**: Outputs stat changes live in the console.
- ✅ **Unity Editor Friendly**: Works seamlessly with `SerializeField` and `EditorUtility.SetDirty`.

---

## 📂 Folder Structure

```
Assets/
│
├── Scripts/
│   ├── Broker.cs                # Handles and applies modifiers
│   ├── IModifier.cs            # Modifier interface
│   ├── Stat.cs                 # Represents a stat with broker support
│   ├── AttackModifier.cs       # Concrete attack modifier
│   ├── DefenseModifier.cs      # Concrete defense modifier
│   ├── TimedModifier.cs        # Modifier with expiration logic
│   ├── CubeManager.cs          # Initializes stats and handles triggers
│   ├── CubeMovement.cs         # Basic player movement
│   ├── CubeStatDebugger.cs     # Coroutine to print stat values periodically
```

---

## 🚀 How It Works

### 1. **Stat Initialization**
Stats like Attack and Defense are initialized with a base value and a shared `Broker` instance:

```csharp
attackStat = new Stat(50f, broker);
```

### 2. **Modifier Application**
When player triggers a power-up (e.g., tagged `AttackBoost`), the broker adds a new `AttackModifier`:

```csharp
broker.AddModifier(new AttackModifier(10f));
```

### 3. **Modifier Priority System**
Modifiers are applied in sorted order based on `GetPriority()`:

- `AttackModifier`: Priority 1
- `TimedModifier`: Priority 2
- `DefenseModifier`: Priority 3

This allows fine control over modifier application sequence.

### 4. **Timed Modifier Logic**
Timed modifiers update every frame and expire automatically after a duration:

```csharp
broker.UpdateModifiers(Time.deltaTime);
```

### 5. **Stat Updates and Debugging**
Every frame:
- Stats are re-evaluated
- Console displays current values
- Optional periodic debugger prints values every 5 seconds

---

## 🕹️ Controls

- Use **arrow keys / WASD** to move the cube.
- Touch or collide with:
  - 🟥 `AttackBoost`: Adds `+10 Attack`
  - 🟦 `DefenseBoost`: Adds `+10 Defense`

---

## 🧪 Educational Value

This project is a **great starting point** for understanding how to:

- Chain modifiers using the Broker pattern
- Prioritize modifier effects
- Extend stat systems with time-based effects
- Integrate gameplay objects with stat changes
- Use good practices (SRP, OCP from SOLID) for game architecture

---





## 📘 License

MIT License - free to use for learning and game prototypes.

---

## ✨ Credits

Designed for teaching **game architecture**, **SOLID design**, and **modular stat handling** in Unity.
