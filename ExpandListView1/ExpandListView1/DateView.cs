using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpandListView1 {
    class DateView : ExpandView {

        public DateTime DateTime {
            get {
                if (Device.OS == TargetPlatform.iOS) {
                    return _exDatePicker.Date;
                } else {
                    return _datePicker.Date;
                }
            }
            set {
                if (Device.OS == TargetPlatform.iOS) {
                    _exDatePicker.Date = value;
                } else {
                    _datePicker.Date = value;
                }
            }
        }

        private ExDatePicker _exDatePicker = new ExDatePicker(); // iOS
        private DatePicker _datePicker = new DatePicker(); // Android,WindowsPhone

        public DateView() {

            _height = Device.OnPlatform(200, 50, 100);

            subViews.Add(_datePicker);
            subViews.Add(_exDatePicker);

            _datePicker.Format = "D"; // 日付表示フォーマット
            _datePicker.HeightRequest = _height;
            _exDatePicker.HeightRequest = _height;


            View view = _datePicker;
            if (Device.OS == TargetPlatform.iOS) {
                view = _exDatePicker;
            }

            Content = new StackLayout {
                Spacing = 0,
                Children = { view }
            };
        }
    }

    // iOS の場合は、下に表示されるインターフェースなので、セルの中に収めるために
    // レンダラーでUIDatePickerを表示する
    public class ExDatePicker : ContentView {
        public static readonly BindableProperty DateProperty =
          BindableProperty.Create<ExDatePicker, DateTime>
            (p => p.Date, DateTime.Now);

        public DateTime Date {
            get {
                return (DateTime)GetValue(DateProperty);
            }
            set { SetValue(DateProperty, value); }
        }
    }

}
