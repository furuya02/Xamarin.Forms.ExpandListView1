using ExpandListView1;
using ExpandListView1.WinPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(ExButton), typeof(ExButtonRenderer))]

namespace ExpandListView1.WinPhone {
    class ExButtonRenderer:ButtonRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e) {
            base.OnElementChanged(e);

            var element = this.Element as ExButton;

            if (element == null || this.Control == null) {
                return;
            }
            Control.HorizontalContentAlignment = element.Aligment == Alignment.Left?
                System.Windows.HorizontalAlignment.Left:System.Windows.HorizontalAlignment.Right;
            // ついでにボーダも消してしまう
            Control.BorderThickness = new System.Windows.Thickness(0.0);
        }


    }
}
