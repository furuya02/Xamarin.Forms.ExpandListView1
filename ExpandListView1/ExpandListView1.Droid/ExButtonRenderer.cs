using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using ExpandListView1;
using ExpandListView1.Droid;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ExButton), typeof(ExButtonRenderer))]

namespace ExpandListView1.Droid {
    class ExButtonRenderer:ButtonRenderer {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e) {
            base.OnElementChanged(e);
            UpdateAlignment();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            UpdateAlignment();
            base.OnElementPropertyChanged(sender, e);
        }

        void UpdateAlignment() {
            var element = this.Element as ExButton;

            if (element == null || this.Control == null) {
                return;
            }
            Control.Gravity = 
                element.Aligment == Alignment.Left?GravityFlags.Left:GravityFlags.Right;

        }
    }
}