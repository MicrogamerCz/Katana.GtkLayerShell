# GTK# Layer Shell

A feature-incompelete port of [GTK LS](https://github.com/wmww/gtk-layer-shell/) for C#, compatible with [GtkSharp](https://github.com/GtkSharp/GtkSharp). Only GTK3 and Wayland will be supported (at least until GTK3 is EOL)

**Dependencies**: GTK3, GTK Layer Shell, Wayland

---

# API

```csharp
GtkLayerShell.GtkMain(); // Extra method for missing gtk_main() in GtkSharp

GtkLayerShell.InitForWindow(Window window);

GtkLayerShell.SetExclusiveZone(Window window, int exclusiveZone);

GtkLayerShell.AutoExclusiveZoneEnable(Window window);

GtkLayerShell.SetAnchor(Window window, GtkLayerShellEdge edge, bool anchor);

GtkLayerShell.SetMargin(Window window, GtkLayerShellEdge edge, int margin);


```
