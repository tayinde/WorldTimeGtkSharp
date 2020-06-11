using System;
using Gtk;

namespace gtkAppTest
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();
            var app = new Application("org.gtkAppTest.gtkAppTest", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow();
            app.AddWindow(win);

            win.Show();
            Gdk.Pixbuf img = new Gdk.Pixbuf("./img/globe.png");
            win.Icon = img;
            Application.Run();
        }
    }
}
