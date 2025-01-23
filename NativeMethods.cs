using System.Runtime.InteropServices;
using GLib;

namespace Katana.Gtk;

public static partial class GtkLayerShell {
    [DllImport("libgtk-3.so", CallingConvention = CallingConvention.Cdecl)]
    static extern void gtk_main();

    [DllImport("/usr/lib/libgtk-layer-shell.so", CallingConvention = CallingConvention.Cdecl)]
    static extern void gtk_layer_set_exclusive_zone(nint window, int exclusiveZone);
    [DllImport("/usr/lib/libgtk-layer-shell.so", CallingConvention = CallingConvention.Cdecl)]
    static extern void gtk_layer_auto_exclusive_zone_enable(nint window);
    [DllImport("/usr/lib/libgtk-layer-shell.so", CallingConvention = CallingConvention.Cdecl)]
    static extern void gtk_layer_set_anchor(nint window, int edge, bool anchorToEdge);
    [DllImport("/usr/lib/libgtk-layer-shell.so", CallingConvention = CallingConvention.Cdecl)]
    static extern void gtk_layer_set_margin(nint window, int edge, int margin);

    internal static class Internal
    {
        [DllImport("/usr/lib/libgtk-layer-shell.so", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void gtk_wayland_init_if_needed();
        [DllImport("/usr/lib/libgtk-layer-shell.so", CallingConvention = CallingConvention.Cdecl)]
        internal static extern nint layer_surface_new(nint window);
        [DllImport("/usr/lib/libgdk-3.so", CallingConvention = CallingConvention.Cdecl)]
        internal static extern GType gdk_wayland_display_get_type();
        [DllImport("/usr/lib/libgdk-3.so", CallingConvention = CallingConvention.Cdecl)]
        internal static extern nint gdk_wayland_display_get_wl_display(nint display);
        [DllImport("/usr/lib/libwayland-client.so", CallingConvention = CallingConvention.Cdecl)]
        internal static extern nint wl_display_get_registry(nint display);
    }
}