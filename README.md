# 🖼️ .NET Image Processing Plugin Framework

This project is a lightweight, extensible plugin-based framework in .NET for processing images using customizable effects. Each image can have one or more effects applied in order, and new effects can be easily added via the plugin system.

---

## 🔧 Features

- Apply multiple effects per image (e.g., Resize, Blur, Grayscale)
- Add/remove plugins without modifying core application code
- Structured plugin architecture using interfaces and reflection
- Internal API, no UI or third-party libraries required

---

## 🧪 Sample Plugins Included

- `Resize`
- `Blur`
- `Grayscale`

These are dummy plugins for simulation and logging only (no real image processing).

---

## 🚀 How to Use

### 🔁 Example JSON Input

```json
[
  {
    "imageId": "Image1",
    "effects": [
      {
        "effectName": "Resize",
        "parameters": { "width": 100 }
      },
      {
        "effectName": "Blur",
        "parameters": { "radius": 2 }
      }
    ]
  },
  {
    "imageId": "Image3",
    "effects": [
      {
        "effectName": "Resize",
        "parameters": { "width": 150 }
      },
      {
        "effectName": "Blur",
        "parameters": { "radius": 5 }
      },
      {
        "effectName": "Grayscale",
        "parameters": {}
      }
    ]
  }
]
