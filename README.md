# Blazor.ToolTips
Simple ToolTip Service for Blazor Applications

## Objectives / Context :
This repository is in no way an opiniated implementation.
This is a learning project. Any comment/critic is welcome. 

## Inspiration :
Inspired by Chris Sainty's article on [creating basic ToolTips](https://chrissainty.com/building-a-simple-tooltip-component-for-blazor-in-under-10-lines-of-code/)

## Constraints :
**Simplicity**: As much as I’d like to make an insane, feature-rich component, as this is a learning project, so I’ll limit the scope to basic functionalities at first, while keeping in mind possible future features additions.

**Reusability**: We want to make a tool that is reusable across different projects and allow the users to customize the toggler, the anchors, and the helpers as much as possible.

# Usage (so far)

1. Register ToolTip Service in your Start-up file

```csharp Cancel changes
// In your file Startup.cs (server)/ Program.cs (Wasm)
...
services.AddBlazorToolTips();
...
```


2. Add Css Stylesheet and JS to the _host.cshtml (server) / Index.razor (wasm)

```html

...
<!-- in your page <head> --> 
<link src="_content/Blazor.ToolTips/style.css" ref="stylesheet" />
...
<!-- before </body> -->
<script src="_content/ToolTips/ToolTipsJS.js"></script>
```


3. Add **one** ToolTip Toggler somewhere accessible and visible - (having more togglers won't cause a problem, but they will all act the same) 
```html
// In any accessible component or DOM element (header, footer...)
...
<ToolTipToggler />
...
```


4. Add anchors anywhere on your site

```html 
// In any accessible component or DOM element (header, footer...)
...
<ToolTipAnchor>
  But What is it?
  <Helper>
    Isn't it a nice information!
  </Helper>
</ToolTipAnchor>
...
```



# What's next

## Current ToDo List :
- [ ] Implement State Container - **Working**
  - [X] Notification to the Components
  - [X] Dependency Injection
  - [ ] Adding options to customize the State Container (?)
- [X] Implement Toggler Component  - **Working**
  - [X] Blazor Component with minimal styling
- [X] Implement Anchor Component - **Working**
  - [X] Blazor Component with minimal styling
- [X] Javascript Background helpers
  - [X] Added Helper position relative to the Anchor position
  - [X] Add handling Anchors loaded as Markup strings 

## Next in line / Possible follow-ups :
- [ ] Add file fetching for helper texts (json/resx...)
- [ ] Add Tutorial Display
- [ ] Implement unit tests
