using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ExpandListView1 {
    public class App : Application {
        public App() {
            MainPage = new MyPage();
        }
    }

    class MyPage : ContentPage {

        List<ExpandView> expandViews = new List<ExpandView>();

        public MyPage() {

            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            var fullNameView = new FullNameView();
            var fullNameCell = CreateCell("FullName", fullNameView);
            var dateView = new DateView();
            var dateCell = CreateCell("Date of Birth", dateView);
            var switchView = new SwitchView("Off = Single,On = Married");
            var switchCell = CreateCell("Marital Status", switchView);
            var groupPersonal = CreateGroup("Personal", new List<StackLayout> { fullNameCell, dateCell, switchCell });


            var sportView = new SelectView(new List<string>() { "Football", "Backetball", "Basebool", "Valleyball" });
            var sportCell = CreateCell("Favorite Sport", sportView);
            var colorView = new SelectView(new List<string>() { "Red", "Green", "Blue" });
            var colorCell = CreateCell("Favorite Color", colorView);
            var groupPreferences = CreateGroup("Preferences", new List<StackLayout> { sportCell, colorCell });



            var sliderView = new SliderView(100);
            var levelCell = CreateCell("Level", sliderView);
            var groupWorkExperience = CreateGroup("Work Experience", new List<StackLayout> { levelCell });


            var scrollView = new ScrollView {
                Content = new StackLayout {
                    Children = { groupPersonal, groupPreferences, groupWorkExperience }
                }
            };

            Content = scrollView;
        }

        // ボタンと拡張するビューを持つセルの生成
        StackLayout CreateCell(string title, ExpandView expandView) {
            expandViews.Add(expandView); // 他のセルが拡張されるときに、セルを閉じるためにリスト登録する
            var button1 = CreateButton(title);
            button1.Clicked += (s, e) => {
                // 自分のセルが拡張している場合は、閉じる
                if (expandView.Expand) {
                    expandView.Expand = false;
                } else { // 自分のセルが閉じている場合は、他のセルを全部閉じてから開く
                    foreach (var v in expandViews) {
                        v.Expand = false;
                    }
                    expandView.Expand = true;
                }
            };
            return new StackLayout {
                Children = { button1, expandView }
            };

        }
        // 複数のセルを持つグループの生成
        StackLayout CreateGroup(string title, IList<StackLayout> ar) {
            var subLayout = new StackLayout {
                Padding = new Thickness(10, 0, 10, 0),
            };
            foreach (var a in ar) {
                subLayout.Children.Add(a);
            }
            return new StackLayout {
                Children = { CreateGroupLabel(title), subLayout }
            };
        }
        // グループ用のラベル
        Label CreateGroupLabel(string title) {
            var label = new Label() {
                Text = "  " + title,
                HorizontalTextAlignment = TextAlignment.Start,
                BackgroundColor = Device.OnPlatform(Color.FromRgb(220, 220, 220), Color.Transparent, Color.FromRgb(90, 90, 90)),
                HeightRequest = Device.OnPlatform(20, 20, 40),
            };
            return label;
        }
        // セル内で拡張ビューを広げたり閉じたりするボタン
        Button CreateButton(string title) {
            var button = new ExButton(Alignment.Right) {
                Text = title + " > ",
                HeightRequest = Device.OnPlatform(50, 50, 80),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Silver,
            };
            return button;
        }
    }
}

