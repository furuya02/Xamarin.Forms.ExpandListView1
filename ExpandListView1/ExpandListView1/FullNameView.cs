using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpandListView1 {
    class FullNameView : ExpandView {

        public string FirstName {
            get {
                return _firstName.Text;
            }
            set {
                _firstName.Text = value;
            }
        }
        public string LastName {
            get {
                return _lastName.Text;
            }
            set {
                _lastName.Text = value;
            }
        }

        private Entry _firstName = new Entry();
        private Entry _lastName = new Entry();

        public FullNameView() {

            _height = Device.OnPlatform(100, 100, 200);

            subViews.Add(_firstName);
            subViews.Add(_lastName);

            _firstName.Placeholder = "Firstname";
            _firstName.HeightRequest = _height/2;
            _lastName.Placeholder = "Lastname";
            _lastName.HeightRequest = _height/2;


            Content = new StackLayout {
                Spacing = 0,
                Children = { _firstName, _lastName }
            };
        }
    }
}
