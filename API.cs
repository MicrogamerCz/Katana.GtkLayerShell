using Gdk;
using Window = Gtk.Window;

namespace Katana.Gtk;

public static partial class GtkLayerShell
{
    static bool hasInitialized = false;
    static nint globalWaylandRegistry = nint.Zero;

    public static void GtkMain() => gtk_main();
    public static void InitForWindow(Window window)
    {
        Internal.gtk_wayland_init_if_needed();
        _ = Internal.layer_surface_new(window.Handle);
    }

    #region Direct interop
    public static void SetExclusiveZone(Window window, int exclusiveZone)
    {
        gtk_layer_set_exclusive_zone(window.Handle, exclusiveZone);
    }
    public static void AutoExclusiveZoneEnable(Window window) 
    {
        gtk_layer_auto_exclusive_zone_enable(window.Handle);
    }
    public static void SetAnchor(Window window, GtkLayerShellEdge edge, bool anchor) 
    {
        gtk_layer_set_anchor(window.Handle, (int)edge, anchor);
    }
    public static void SetMargin(Window window, GtkLayerShellEdge edge, int margin)
    {
        gtk_layer_set_margin(window.Handle, (int)edge, margin);
    }
    #endregion

    #region Internal API reimplementation

    static void InitIfNeeded() // TODO
    {
        if (hasInitialized) return;

        Display display = Display.Default;
        if (display.NativeType == Internal.gdk_wayland_display_get_type()) throw new Exception("GDK Display is not a Wayland display");

        nint wldisplay = Internal.gdk_wayland_display_get_wl_display(display.Handle);
        globalWaylandRegistry = Internal.wl_display_get_registry(wldisplay);
    }

    #endregion
}