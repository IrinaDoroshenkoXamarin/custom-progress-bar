using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CustomProgressBar.Enums;
using Xamarin.Forms;
using CustomProgressBar.Resources;

namespace CustomProgressBar.PageModels
{

    public class MainPageModel : FreshMvvm.FreshBasePageModel
    {
        private readonly Random _random;

        public List<BackgroudBrushType> BrushTypesList { get; set; }

        #region Properties

        private BackgroudBrushType _selectedBrush;
        public BackgroudBrushType SelectedBrush
        {
            get
            {
                return _selectedBrush;
            }
            set
            {
                if (_selectedBrush != value)
                {
                    _selectedBrush = value;
                    RaisePropertyChanged(nameof(SelectedBrush));
                }
            }
        }

        private double _progress;
        public double Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                    RaisePropertyChanged(nameof(Progress));
                }
            }
        }

        private ICommand _makeProgressCommand;
        public ICommand MakeProgressCommand
        {
            get
            {
                return _makeProgressCommand ??
                  (_makeProgressCommand =
                      new Command(DoMakeProgressCommand));
            }
        }

        #endregion

        public MainPageModel()
        {
            _random ??= new Random();

            BrushTypesList = new(Enum.GetValues(typeof(BackgroudBrushType)).Cast<BackgroudBrushType>());
        }

        private void DoMakeProgressCommand()
        {
            if (SelectedBrush is not BackgroudBrushType.None)
            {
                Progress = _random.Next(0, (int)Constants.MAX_PERCENT_VALUE) / Constants.MAX_PERCENT_VALUE;
            }
            else
            {
                 this.CoreMethods.DisplayAlert("Ooops", "please select the brush type", "Sure!");
            }
        }
    }
}
