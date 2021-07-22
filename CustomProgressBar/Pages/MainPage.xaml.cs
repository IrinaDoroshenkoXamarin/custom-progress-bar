using System;
using Xamarin.Forms;

namespace CustomProgressBar.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly Random _random;

        public MainPage()
        {
            _random ??= new Random();

            InitializeComponent();
        }

        #region Private helpers

        private void OnButtonClicked(object sender, EventArgs args)
        {
            this.customControl.Progress = _random.Next(0, 100) / 100.0;
        }

        #endregion
    }
}
