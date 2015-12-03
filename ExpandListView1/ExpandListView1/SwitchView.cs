using Xamarin.Forms;

namespace ExpandListView1 {
    class SwitchView:ExpandView {
        public bool Status {
            get {
                return _switch.IsToggled;
            }
            set {
                _switch.IsToggled = value;
            }
        }

        private Switch _switch = new Switch();
        private Label _label = new Label();

        public SwitchView(string title) {
            _label.Text = title;
            _label.HorizontalOptions = LayoutOptions.StartAndExpand;


            subViews.Add(_label);
            subViews.Add(_switch);

            _height = Device.OnPlatform(50, 50, 100);

            Content = new StackLayout {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0,
                Children = { _label,_switch }
            };
        }
    }
}
