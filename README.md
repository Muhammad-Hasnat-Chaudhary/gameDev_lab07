# SILENT INFILTRATION
### CS464 — Game Development | Lab 07

**Developer:** Muhammad Hasnat  
**Roll Number:** BSCS23006  
**Game Engine:** Unity 6.3 LTS (6000.3.24f1)  
**Project Type:** Interactive Mobile Game UI/Menu System  
**Reference Resolution:** 1920 × 1080 (Landscape)

---

## 1. Project Overview

**Silent Infiltration** is a tactical stealth-themed game menu system developed in Unity for CS464 Lab 07.

The project contains **10 interconnected and functional UI screens**, featuring menu navigation, agent loadout customization, a virtual-credit shop, adjustable settings, mission selection, and mission results.

The interface follows a consistent dark-and-gold visual theme inspired by modern tactical game menus.

**Note:** This project demonstrates a functional menu prototype rather than a complete playable game.

## 2. The 10 UI Screens

| # | Screen | Description |
|---|---|---|
| 1 | Title Screen | Displays the game title and Start Game button. |
| 2 | Main Menu | Provides access to Play, Loadout, Shop, Settings, and Credits. |
| 3 | Mode Select | Offers Campaign and Training modes. |
| 4 | Level Select | Displays five selectable missions and a Test Results button. |
| 5 | Agent Loadout | Allows players to customize primary, secondary, and gadget selections. |
| 6 | Tactical Shop | Allows purchases using virtual in-game credits. |
| 7 | Settings | Provides music, sound, graphics quality, and reset controls. |
| 8 | Pause Screen | Provides Resume, Restart, Settings, Main Menu, and Quit Mission controls. |
| 9 | Results Screen | Displays a sample mission score and reward, with navigation options. |
| 10 | Credits Screen | Displays developer, course, game, and technology information. |

## 3. Functional Features

### Navigation
- Functional buttons connect the menu screens.
- Back buttons provide navigation to earlier menus.
- A Test Results button allows direct access to the Results Screen for demonstration.
- Retry and Next Mission return to mission selection in this prototype.

### Agent Loadout
- Primary equipment selection
- Secondary equipment selection
- Gadget selection
- Equip Loadout functionality
- Console feedback confirming selections

### Tactical Shop
- Starting balance: **500 credits**
- Armor Upgrade: 200 credits
- Stealth Boost: 150 credits
- Speed Boost: 100 credits
- Balance updates after purchases
- Duplicate purchases are prevented

### Settings
- Music ON/OFF toggle
- Sound ON/OFF toggle
- Graphics quality selection
- Reset Settings functionality

### Results
- Sample mission score display
- Reward display
- Retry Mission
- Next Mission
- Return to Main Menu

## 4. UI/UX Design

The project applies the following principles:

- **Colour theory:** Dark navy backgrounds with gold buttons and headings.
- **Visual hierarchy:** Large headings distinguish each screen.
- **Consistency:** Shared colours, typography, spacing, and button styles.
- **Contrast:** Bright controls and text remain visible against the dark background.
- **Alignment:** Centered controls provide a clean and organized interface.
- **Affordance:** Clearly labelled buttons communicate available actions.
- **Feedback:** Text updates, navigation changes, and Unity Console messages confirm interactions.

### Screen Transitions

Screen transitions use a custom `ScreenFade.cs` component with Unity's `CanvasGroup`.

- Animation: Fade-in
- Duration: **0.35 seconds**
- Easing: **Ease-Out Cubic**
- Timing: `Time.unscaledDeltaTime`

The easing function is:

`f(t) = 1 - (1 - t)^3`

This produces a smooth screen entrance.

## 5. Project Structure

The Unity project includes:

- `Assets/` — Unity scenes, scripts, and UI resources
- `Packages/` — Unity package configuration
- `ProjectSettings/` — Unity project configuration
- `MenuManager.cs` — Menu navigation and interaction logic
- `ScreenFade.cs` — Animated screen-entry transitions

## 6. How to Run the Project

1. Clone or download this repository.
2. Open **Unity Hub**.
3. Select **Add project from disk**.
4. Choose the Unity project folder containing `Assets`, `Packages`, and `ProjectSettings`.
5. Open the project using **Unity 6.3 LTS**.
6. Open the menu scene from the project's Scenes folder.
7. Set the Game view to **Full HD (1920 × 1080)**.
8. Press **Play**.
9. Click **START GAME** to explore the UI system.

The Game-view zoom (such as 0.41x or 0.5x) can be adjusted to fit the Unity Editor window.

## 7. Demo Video

The demonstration shows the navigation and interactions of the ten UI screens.

**Demo:** [Silent Infiltration Lab 07 Demo](SilentInfiltration_Lab07_Demo.mp4)

## 8. Design Documentation

The detailed design document includes screen screenshots, UI/UX explanations, navigation details, and transition techniques.

**Documentation:** [Silent Infiltration Lab 07 Design Document](Silent_Infiltration_Lab07_Design_Document.pdf)

## 9. Credits and References

**Developed by:** Muhammad Hasnat  
**Roll Number:** BSCS23006  
**Course:** CS464 — Game Development

**Technologies:**
- Unity 6.3 LTS
- Unity UI (uGUI)
- TextMeshPro
- C#

**Educational Reference:**
- CS464 Lecture 08 — Colour, UI Design & Menus

**Visual Direction:** Original tactical-style UI design. No AI-generated images were used.

---

*Created as an educational project for CS464 Game Development — Lab 07.*
