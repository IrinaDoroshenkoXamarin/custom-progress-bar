using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomProgressBar.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomSwitcher : ContentView
    {
        #region Public properties

        public static readonly BindableProperty IsVisibleTextProperty =
           BindableProperty.Create(nameof(IsVisibleText), typeof(bool), typeof(CustomSwitcher), false);

        public bool IsVisibleText
        {
            get { return (bool)base.GetValue(IsVisibleTextProperty); }
            set { base.SetValue(IsVisibleTextProperty, value); }
        }

        public static readonly BindableProperty IsToggledProperty =
            BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(CustomSwitcher), false,
                defaultBindingMode: BindingMode.TwoWay);

        public bool IsToggled
        {
            get { return (bool)base.GetValue(IsToggledProperty); }
            set { base.SetValue(IsToggledProperty, value); }
        }

        #endregion

        public CustomSwitcher()
        {
            InitializeComponent();

            this.buttonTapRecognizer.Command = new Command(OnSwitcherTap);
        }

        #region Overrides

        protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsToggled))
            {
                if (IsToggled)
                {
                    await this.switcherButton.TranslateTo(25, 0, 250, Easing.BounceOut);
                    this.mainFrame.BackgroundColor = Color.BlueViolet;
                }
                else
                {
                    await this.switcherButton.TranslateTo(0, 0, 250, Easing.Linear);
                    this.mainFrame.BackgroundColor = Color.LightGray;
                }
            }
        }

        #endregion

        #region Private helpers

        private void OnSwitcherTap()
        {
            IsToggled = !IsToggled;
        }

        #endregion
    }
}