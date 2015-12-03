using ExpandListView1;
using ExpandListView1.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using Foundation;


[assembly: ExportRenderer(typeof(ExDatePicker),typeof(ExCalendarRenderer))]

namespace ExpandListView1.iOS {
    class ExCalendarRenderer: ViewRenderer<ExDatePicker, UIDatePicker>  {

        protected override void OnElementChanged(ElementChangedEventArgs<ExDatePicker> e) {
            base.OnElementChanged(e);

            SetNativeControl(new UIDatePicker(Frame) {
                Mode = UIDatePickerMode.Date,
            });

            // Control(UIDatePickerの値が変化した際に、ExCarenderのCurrentDate プロパティを変化させる
            Control.AddTarget((s,a)=> {
                if (Element != null) {
                    Element.Date = Control.Date.ToDateTime();
                }
            }, UIControlEvent.ValueChanged);


        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null || Control == null) {
                return;
            }
            // ExCalendarのCurrentDateプロパティが変更された時、Control(UIDatePicker)のDateを変更する
            if (e.PropertyName == ExDatePicker.DateProperty.PropertyName) {
                Control.Date = Element.Date.ToNSDate();
            }
        }


    }
}
