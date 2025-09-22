# Pulse Panel (EmotionalDashboardSystem)

Pulse Panel is a C#/.NET system designed for **e-commerce platforms** to track user interactions and infer emotional responses. By understanding **how customers feel while shopping**, online stores can reduce cart abandonment, improve user experience, and increase conversions — all **without capturing sensitive data like faces or voices**.

## Features

 **Behavioral Emotion Detection**  
  Infers emotions such as frustration, hesitation, engagement, and satisfaction from safe signals like:
    Mouse clicks
    Scrolling patterns
    Time spent on pages
    Typing behavior

 **Interactive Dashboard**  
  Visualizes emotional trends per page, product, or customer segment.

 **Actionable Insights**  
  Helps businesses optimize product placement, checkout flow, and UX design.

 **Easy Integration**  
  Modular system that can plug into existing e-commerce websites or apps.

  ##  Project Structure

- **PulsePanel (F# project)** – API and controllers  
- **PulsePanel.AppHost (C# project)** – Application entry point  
- **PulsePanel.ServiceDefaults** – Shared defaults for services  

### Implemented Models
- `ClickEvent.cs` → Captures user click data  
  - Properties: `ElementId`, `PageUrl`, `Timestamp`, `UserId`  
  - Methods:  
    - `IsRecent(int seconds)` → Checks if the click happened recently  
    - `ToString()` → Returns a readable representation  

---

##  Progress
- [x] Added `ClickEvent.cs` model  
- [ ] Add `ScrollEvent.cs`  
- [ ] Add `TypingEvent.cs`  
- [ ] Add `PageVisit.cs`  
- [ ] Implement `EventCollector.cs` service  
- [ ] Build `EmotionAnalyzer.cs`  
- [ ] Create dashboard reports  
