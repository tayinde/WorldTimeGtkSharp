using System;
using APIRequest;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using Application = Gtk.Application;
namespace gtkAppTest
{
    class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button _button1 = null;
        [UI] private Entry city = null;
        public MainWindow() : this(new Builder("MainWindow.glade")) { }
        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);
            CssProvider css = new CssProvider();
            Gtk.StyleContext.AddProviderForScreen(Gdk.Screen.Default, css, Gtk.StyleProviderPriority.Application);
            css.LoadFromPath ("./css/gtk.css");
            DeleteEvent += Window_DeleteEvent;
            _button1.Clicked += RenderCityData;
            city.Activated += RenderCityData;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Console.WriteLine($"{Application.ApplicationId}: App closed");
            Application.Quit();
        }

        private async void RenderCityData(object sender, EventArgs a)
        {
            var place = city.Text.ToLower();
            city.Text = "";
            _label1.Text = "Searching...";
            await Request.Send(place);
            if (Request.location["data"]["error"] != null)
            {
                _label1.Text = $"The location \"{place}\" was not found.";
            } else
            {
                string location = (string) Request.location["data"]["request"][0]["query"];
                string time = (string) Request.location["data"]["time_zone"][0]["localtime"];
                string offset = (string) Request.location["data"]["time_zone"][0]["utcOffset"];
                string region = (string) Request.location["data"]["time_zone"][0]["zone"];
                int cutOff = region.IndexOf("/");
                region = region.Substring(0, cutOff);
                _label1.Text = $"{char.ToUpper(location[0])}{location.Substring(1, location.Length - 1)}\n \nDate: {time}\nUTC Offset: {offset}\nContinent: {region}";
            }
            Console.WriteLine($"{Application.ApplicationId}: Request attempt executed.");
        }
    }
}
