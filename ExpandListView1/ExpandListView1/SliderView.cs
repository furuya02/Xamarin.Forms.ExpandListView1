using Xamarin.Forms;

namespace ExpandListView1 {
    class SliderView : ExpandView {

        public double Value {
            get {
                return _slider.Value;
            }
            set {
                _slider.Value = value;
            }
        }

        private Slider _slider = new Slider();

        public SliderView(int max) {

            _slider.Maximum = max;
            _slider.HorizontalOptions = LayoutOptions.FillAndExpand;

            subViews.Add(_slider);

            _height = Device.OnPlatform(50, 50, 100);

            Content = new StackLayout {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0,
                Children = { _slider }
            };
        }
    }
}

