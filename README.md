# Unity Broker Chain Pattern along with EASY Stats and Modifiers

## Overview

This Unity project demonstrates the implementation of the Broker Chain design pattern along with a simple stats and modifiers system. The project includes classes and components for managing and modifying stats, as well as basic cube movement and stat debugging.

## Project Structure

The project is organized into the following main components:

- **Modifiers**: Classes for modifying stats.
- **Broker**: Manages a collection of stats.
- **CubeManager**: Handles interactions and modifications for a cube.
- **CubeMovement**: Manages cube movement.
- **CubeStatDebugger**: Debugs and displays stat values over time.
- **Stat**: Represents a stat with modifiers.

## Components

### Modifiers

- **`IModifier` Interface**
  ```csharp
  public interface IModifier 
  {
      float Modify(float value);       
  }
  ```

- **`AttackModifier` Class**
  ```csharp
  public class AttackModifier : IModifier 
  {
      private readonly float attackBoost;
  
      public AttackModifier(float attackBoost)
      {
          this.attackBoost = attackBoost;
      }
  
      public float Modify(float value)
      {
          return value + attackBoost;
      }
  }
  ```

- **`DefenseModifier` Class**
  ```csharp
  public class DefenseModifier : IModifier
  {
      private readonly float defenseBoost;
  
      public DefenseModifier(float defenseBoost)
      {
          this.defenseBoost = defenseBoost;
      }
  
      public float Modify(float value)
      {
          return value + defenseBoost;
      }
  }
  ```

### Broker

- **`Broker` Class**
  ```csharp
  using System.Collections.Generic;
  using UnityEngine;
  
  public class Broker 
  {
      private readonly List<Stat> stats = new List<Stat>();
  
      public void AddStat(Stat stat)
      {
          if (stat == null)
          {
              Debug.LogError("Cannot add a null stat");
              return;
          }
          stats.Add(stat);
          Debug.Log("Stat added to broker");
      }
  
      public void ProcessAllStats()
      {
          foreach (var stat in stats)
          {
              Debug.Log($"Stat value: {stat.GetValue()}");
          }
      }
  }
  ```

### CubeManager

- **`CubeManager` Class**
  ```csharp
  using UnityEngine;

  public class CubeManager : MonoBehaviour
  {
      private Stat attackStat;
      private Stat defenseStat;
      private Broker broker;
  
      void Start()
      {
          attackStat = new Stat(50f);
          defenseStat = new Stat(50f);
  
          broker = new Broker();
          broker.AddStat(attackStat);
          broker.AddStat(defenseStat);
  
          Debug.Log("Cube initialized with Attack: " + attackStat.GetValue() + " Defense: " + defenseStat.GetValue());
      }
  
      private void OnTriggerEnter(Collider other)
      {
          if(other.gameObject.CompareTag("AttackBoost"))
          {
              attackStat.AddModifier(new AttackModifier(10f));
              Debug.Log("Attack boosted by 10");
              Destroy(other.gameObject);
          }
          else if(other.gameObject.CompareTag("DefenseBoost"))
          {
              defenseStat.AddModifier(new DefenseModifier(10f));
              Debug.Log("Defense boosted by 10");
              Destroy(other.gameObject);
          }
      }
  }
  ```

### CubeMovement

- **`CubeMovement` Class**
  ```csharp
  using UnityEngine;

  public class CubeMovement : MonoBehaviour
  {
     public float moveSpeed = 5f; // Movement speed
 
     void Update()
     {
         // Read input for WASD keys
         float moveX = Input.GetAxis("Horizontal"); // A and D keys (X axis)
         float moveZ = Input.GetAxis("Vertical");   // W and S keys (Z axis)
 
         // Create movement vector
         Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
 
         // Update cube's position
         transform.Translate(move);
     }
  }
  ```

### CubeStatDebugger

- **`CubeStatDebugger` Class**
  ```csharp
  using UnityEngine;
  using System.Collections;
  
  public class CubeStatDebugger : MonoBehaviour
  {
      [SerializeField] private Stat attackStat;
      [SerializeField] private Stat defenseStat;
  
      private void Start()
      {
          if (attackStat == null)
              attackStat = new Stat(50f);  // Default attack value
  
          if (defenseStat == null)
              defenseStat = new Stat(50f);  // Default defense value
  
          // Start coroutine for debugging stats
          StartCoroutine(DebugStatsCoroutine());
      }
  
      private IEnumerator DebugStatsCoroutine()
      {
          while (true)
          {
              if (attackStat == null || defenseStat == null)
              {
                  Debug.LogError("One or both stats are null!");
              }
              else
              {
                  Debug.Log($"Attack: {attackStat.GetValue()}");
                  Debug.Log($"Defense: {defenseStat.GetValue()}");
              }
  
              yield return new WaitForSeconds(5f);
          }
      }
  
      private void OnTriggerEnter(Collider other)
      {
          if (attackStat == null || defenseStat == null)
          {
              Debug.LogError("One or both stats are null!");
              return;
          }
  
          if (other.CompareTag("AttackBoost"))
          {
              attackStat.AddModifier(new AttackModifier(10f));
              Debug.Log("Attack boosted by 10");
              Destroy(other.gameObject);
          }
          else if (other.CompareTag("DefenseBoost"))
          {
              defenseStat.AddModifier(new DefenseModifier(10f));
              Debug.Log("Defense boosted by 10");
              Destroy(other.gameObject);
          }
      }
  }
  ```

### Stat

- **`Stat` Class**
  ```csharp
  using System.Collections.Generic;
  using UnityEngine;
 
  [System.Serializable]
  public class Stat 
  {
     [SerializeField] private float baseValue;    
     private List<IModifier> modifiers = new List<IModifier>();
 
     public Stat(float baseValue)
     {
         this.baseValue = baseValue;
     }
 
     public float GetValue()
     {
         float finalValue = baseValue;
         
         if (modifiers != null)  // Check if the list is not null
         {
             foreach(var modifier in modifiers)
             {
                 finalValue = modifier.Modify(finalValue);
             }
         }
 
         return finalValue;
     }
 
     public void AddModifier(IModifier modifier)
     {
         if (modifier == null) 
         {
             Debug.LogError("Cannot add a null modifier");
             return;
         }
 
         // Ensure the list is initialized
         if (modifiers == null)
         {
             modifiers = new List<IModifier>();
         }
 
         modifiers.Add(modifier);
         Debug.Log($"Modifier added: {modifier.GetType().Name}");
     }
 
     public void RemoveModifier(IModifier modifier)
     {
         if (modifier == null) 
         {
             Debug.LogError("Cannot remove a null modifier");
             return;
         }
         if (modifiers.Remove(modifier))
         {
             Debug.Log($"Modifier removed: {modifier.GetType().Name}");
         }
         else
         {
             Debug.LogWarning($"Modifier not found: {modifier.GetType().Name}");
         }
     }
  }
  ```     

  
