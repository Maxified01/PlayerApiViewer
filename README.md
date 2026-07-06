# Player API Viewer

## Project Overview

Player API Viewer is a Unity application that demonstrates how to consume a REST API, deserialize JSON data into C# classes, and display the information using Unity's UI system.

The application downloads player information from a remote API and presents the player's details and inventory in a structured interface.

---

## Features

- Fetches JSON data from a REST API using UnityWebRequest
- Deserializes JSON into C# classes using JsonUtility
- Displays player information in Unity UI
- Dynamically generates inventory items
- Refresh button to reload data
- Error handling for failed API requests
- Inventory sorted alphabetically using LINQ
- Modular code structure using an interface

---

## API Used

https://api.jsonbin.io/v3/b/6686a992e41b4d34e40d06fa

---

## Technologies Used

- Unity 6
- C#
- UnityWebRequest
- JsonUtility
- TextMeshPro
- LINQ

---

## Project Structure

Assets
- Scripts
  - Interfaces
  - Managers
  - Models
  - UI
- Prefabs
- Scenes

---

## How to Run

1. Open the project in Unity.
2. Open the MainScene.
3. Press Play.
4. The application will automatically retrieve data from the API and display it.
5. Click the Refresh button to reload the data.

---

## Learning Outcomes

I Learnt,

- REST API integration
- JSON deserialization
- Object-oriented programming
- Unity UI development
- Modular C# architecture
- Dynamic UI generation

---

## Author

Anthony Emoh
