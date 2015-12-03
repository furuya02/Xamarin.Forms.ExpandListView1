using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpandListView1 {
    class ExpandView :ContentView{
        protected int _height = 100;
        private bool _expand;
        protected List<View> subViews = new List<View>();
        public bool Expand {
            set {
                HeightRequest = value ? _height : 0;
                _expand = value;
                foreach (var s in subViews) {
                    s.IsVisible = _expand;
                }
            }
            get {
                return _expand;
            }
        }

        public ExpandView() {
            Expand = false;
        }

    }
}
