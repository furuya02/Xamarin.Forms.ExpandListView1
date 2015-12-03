using ExpandListView1.iOS;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExButton), typeof(ExButtonRenderer))]
namespace ExpandListView1.iOS {
    class ExButtonRenderer : ButtonRenderer {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            var element = Element as ExButton;
            if (element == null || Control == null) {
                return;
            }

            Control.HorizontalAlignment =
                element.Aligment == Alignment.Left ?
                UIKit.UIControlContentHorizontalAlignment.Left :
                UIKit.UIControlContentHorizontalAlignment.Right;
        }
    }
}



