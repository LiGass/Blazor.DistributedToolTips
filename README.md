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


2. Add Css Stylesheet to the _host.cshtml (server) / Index.razor (wasm)

```html

...
<link src="_content/Blazor.DistributedToolTips/style.css" ref="stylesheet" />
...
```


3. Add a ToolTip Toggler somewhere accessible and visible
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

## Difficulties:
**Keeping it simple, stupid** and **Being SOLID**

**Implementing a json file for storing content**

## Current ToDo List :
- [ ] Implement State Container
  - [X] Notification to the Components
  - [X] Dependency Injection
  - [ ] Adding options to customize the State Container (?)
- [X] Implement Toggler Component
  - [X] Blazor Component with minimal styling
  - [ ] Add capturing unexpected parameters  
- [X] Implement Anchor Component
  - [X] Blazor Component with minimal styling
  - [ ] Add capturing unexpected parameters 
- [ ] Implement Dynamic Display Component
  - [ ] Blazor Component with minimal styling
  - [ ] Add Receiving Anchor helper text

## Next in line / Possible follow-ups :
- [ ] Implement unit tests
- [ ] Add file storage and fetching for helper texts (json/resx...)
- [ ] Create Javascript back-end implement on AfterRender
