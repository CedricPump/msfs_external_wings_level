# MSFS External Wings Level Autopilot

A lightweight external autopilot tool for Microsoft Flight Simulator.  
Designed for short AFK operations in general aviation aircraft.

---

## ✈️ Features

- **Wings Level Hold Autopilot**  
  Keeps the aircraft's wings level (bank = 0°) and gently stabilizes altitude.

- **Auto-Pause on Vertical Speed Exceedance**  
  Pauses the sim automatically if the aircraft exceeds a safe vertical speed (e.g., rapid uncontrolled climb or descent).

- **Auto-Pause on Low AGL Altitude**  
  Pauses the sim automatically if the aircraft drops below a critical altitude above ground level — ideal for AFK safety.

---

## 🔧 Usage

1. **Launch Microsoft Flight Simulator and start a flight.**
2. Run `msfs_external_wings_level.exe`.
3. Use the interface or hotkey (if available) to toggle the autopilot.
4. When active, the autopilot:
   - Levels the wings
   - Stabilizes altitude
   - Monitors for unsafe conditions and auto-pauses the sim if needed

---

## 🛠 Technical Overview

- Written in **C#**, using **SimConnect** for communication with MSFS.
- PID-based control system for:
  - **Bank ➜ Aileron**
  - **Vertical Speed ➜ Elevator**
- Supports **external pause** using `PAUSE_ON` SimConnect event.

---

## 📦 Requirements

- Microsoft Flight Simulator (MSFS 2020 or later)
- .NET 6 or newer
- SimConnect (included with MSFS)

---

## ⚠️ Known Issues

- Some aircraft do not have **aileron trim** modeled at all.
- **Elevator trim becomes disabled** if the engine is off (affecting gliders or engine-off scenarios).
- Some aircraft **do not trigger the engine combustion SimVar** even when running — in those cases, VS hold does not activate.

---

## 🛠 Planned Fixes / Improvements

- **Selectable control method** for bank hold:
  - Aileron trim
  - Aileron deflection
  - Rudder trim (fallback)

---

## 📜 License

MIT License — free to use, modify, and distribute.

---

## 👨‍💻 Author

Developed by [CedricPump](https://github.com/CedricPump)
