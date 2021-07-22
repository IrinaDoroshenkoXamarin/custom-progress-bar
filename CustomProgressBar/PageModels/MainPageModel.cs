using System;
using System.Collections.Generic;
using System.Linq;
using CustomProgressBar.Enums;

namespace CustomProgressBar.PageModels
{

    public class MainPageModel : FreshMvvm.FreshBasePageModel
    {
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

        #endregion

        public MainPageModel()
        {
            BrushTypesList = new(Enum.GetValues(typeof(BackgroudBrushType)).Cast<BackgroudBrushType>());
        }
    }
}
