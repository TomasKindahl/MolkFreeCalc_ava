using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Input;
// using Avalonia.Documents; finns inte
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Interactivity;
// using Avalonia.Navigation; finns inte
// using Avalonia.Shapes; finns inte


namespace MolkFreeCalc_ava
{
    public partial class MainWindow : Window
    {
        CStack cs = new CStack();
        public MainWindow()
        {
            InitializeComponent();
            LetterField.Text = "T:\nZ:\nY:\nX:\n▹";
            UpdateNumberField();
        }
        private void UpdateNumberField()
        {
            NumberField.Text = cs.StackString();
        }
        private void NumBtn(object sender, RoutedEventArgs e)
        {
            Button B = sender as Button;
            cs.EntryAddNum(B.Content.ToString());
            UpdateNumberField();
        }
        private void NumComma(object sender, RoutedEventArgs e)
        {
            cs.EntryAddComma();
            UpdateNumberField();
        }
        private void NumCHS(object sender, RoutedEventArgs e)
        {
            cs.EntryChangeSign();
            UpdateNumberField();
        }
        private void EnterBtnClick(object sender, RoutedEventArgs e)
        {
            cs.Enter();
            UpdateNumberField();
        }
        private void OpBtn_binop(object sender, RoutedEventArgs e)
        {
            string op = (sender as Button).Content.ToString();
            cs.BinOp(op);
            UpdateNumberField();
        }
        private void OpBtn_unop(object sender, RoutedEventArgs e)
        {
            string op = (sender as Button).Content.ToString();
            cs.Unop(op);
            UpdateNumberField();
        }
        private void OpBtn_nilop(object sender, RoutedEventArgs e)
        {
            string op = (sender as Button).Content.ToString();
            cs.Nilop(op);
            UpdateNumberField();
        }
        private void Clr_Btn(object sender, RoutedEventArgs e)
        {
            cs.entry = "";
            UpdateNumberField();
        }
        private void Clx_Btn(object sender, RoutedEventArgs e)
        {
            cs.X = 0;
            UpdateNumberField();
        }
        private void Clst_Btn(object sender, RoutedEventArgs e)
        {
            cs.Y = cs.Z = cs.T = 0;
            UpdateNumberField();
        }
        private void OpBtn_swap(object sender, RoutedEventArgs e)
        {
            double tmp = cs.X; cs.X = cs.Y; cs.Y = tmp;
            UpdateNumberField();
        }
        private void OpBtn_dup(object sender, RoutedEventArgs e)
        {
            cs.RollSetX(cs.X);
            UpdateNumberField();
        }
        private void OpBtn_drop(object sender, RoutedEventArgs e)
        {
            cs.Drop();
            UpdateNumberField();
        }
        private void OpBtn_roll(object sender, RoutedEventArgs e)
        {
            cs.Roll();
            UpdateNumberField();
        }
        private void OpBtn_sto(object sender, RoutedEventArgs e)
        {
            string op = (sender as Button).Content.ToString();
            cs.SetVar(op);
        }
        private void OpBtn_rcl(object sender, RoutedEventArgs e)
        {
            string op = (sender as Button).Content.ToString();
            cs.GetVar(op);
        }
    }
}
