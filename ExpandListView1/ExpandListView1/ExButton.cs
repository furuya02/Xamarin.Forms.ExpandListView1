using Xamarin.Forms;

public class ExButton : Button {
    public Alignment Aligment { get; set; }
    public ExButton(Alignment aligmrnt) {
        Aligment = aligmrnt;
    }
}

public enum Alignment {
    Left,Right
}

