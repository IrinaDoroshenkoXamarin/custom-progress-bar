using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CustomProgressBar.Enums;
using Xamarin.Forms;

namespace CustomProgressBar.Controls
{
    public partial class CustomProgressBar : Grid
    {
        #region Public Properties

        //----

        public static readonly BindableProperty BgImageProperty = BindableProperty.Create(
            nameof(BgImage),
            typeof(ImageSource),
            typeof(CustomProgressBar));

        /// <summary>
        /// value from 0 to 1
        /// </summary>
        public ImageSource BgImage
        {
            get => (ImageSource)GetValue(BgImageProperty);
            set => SetValue(BgImageProperty, value);
        }

        //----

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            nameof(CornerRadius),
            typeof(float),
            typeof(CustomProgressBar),
            defaultValue: default(float));

        /// <summary>
        /// value from 0 to 1
        /// </summary>
        public float CornerRadius
        {
            get => (float)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        //----

        public static readonly BindableProperty ProgressFontSizeProperty = BindableProperty.Create(
            nameof(ProgressFontSize),
            typeof(double),
            typeof(CustomProgressBar),
            defaultValue: 14.0d);

        /// <summary>
        /// value from 0 to 1
        /// </summary>
        public double ProgressFontSize
        {
            get => (double)GetValue(ProgressFontSizeProperty);
            set => SetValue(ProgressFontSizeProperty, value);
        }

        //----

        public static readonly BindableProperty BrushRadiusProperty = BindableProperty.Create(
            nameof(BrushRadius),
            typeof(double),
            typeof(CustomProgressBar),
            defaultValue: 0.5);

        /// <summary>
        /// value from 0 to 1
        /// </summary>
        public double BrushRadius
        {
            get => (double)GetValue(BrushRadiusProperty);
            set => SetValue(BrushRadiusProperty, value);
        }

        //---

        public static readonly BindableProperty ProgressProperty = BindableProperty.Create(
            nameof(Progress),
            typeof(double),
            typeof(CustomProgressBar),
            defaultValue: default(double));

        /// <summary>
        /// value from 0 to 1
        /// </summary>
        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        //-----

        public static readonly BindableProperty BackgroudBrushProperty = BindableProperty.Create(
            nameof(BackgroudBrush),
            typeof(BackgroudBrushType),
            typeof(CustomProgressBar));

        /// <summary>
        /// type of brush
        /// </summary>
        public BackgroudBrushType BackgroudBrush
        {
            get => (BackgroudBrushType)GetValue(BackgroudBrushProperty);
            set => SetValue(BackgroudBrushProperty, value);
        }

        //----

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            nameof(BorderColor),
            typeof(Color),
            typeof(CustomProgressBar),
             defaultValue: Color.Transparent);

        /// <summary>
        /// Progress bar border color
        /// </summary>
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        //-----

        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
            nameof(StartColor),
            typeof(Color),
            typeof(CustomProgressBar),
             defaultValue: Color.Transparent);

        /// <summary>
        /// Progress bar border color
        /// </summary>
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }

        //-----

        public static readonly BindableProperty StopColorProperty = BindableProperty.Create(
            nameof(StopColor),
            typeof(Color),
            typeof(CustomProgressBar),
             defaultValue: Color.Transparent);

        /// <summary>
        /// Progress bar border color
        /// </summary>
        public Color StopColor
        {
            get => (Color)GetValue(StopColorProperty);
            set => SetValue(StopColorProperty, value);
        }

        //--

        public static readonly BindableProperty ProgressTextColorProperty = BindableProperty.Create(
           nameof(ProgressTextColor),
           typeof(Color),
           typeof(CustomProgressBar),
            defaultValue: Color.Black);

        /// <summary>
        ///Text color of progress label
        /// </summary>
        public Color ProgressTextColor
        {
            get => (Color)GetValue(ProgressTextColorProperty);
            set => SetValue(ProgressTextColorProperty, value);
        }

        //--

        public static readonly BindableProperty EmptyAreaColorProperty = BindableProperty.Create(
           nameof(EmptyAreaColor),
           typeof(Color),
           typeof(CustomProgressBar),
            defaultValue: Color.LightGray);

        /// <summary>
        /// Color of progress bar backround
        /// </summary>
        public Color EmptyAreaColor
        {
            get => (Color)GetValue(EmptyAreaColorProperty);
            set => SetValue(EmptyAreaColorProperty, value);
        }

        //--

        #endregion

        public CustomProgressBar()
        {
            InitializeComponent();
        }

        #region Overrides

        protected async override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Progress))
            {
                this.progressFrame.WidthRequest = 0;

                double mainFrameWidth = this.baseFrame.Width;

                for (int i = 0; i < Progress * 100; i++)
                {
                    this.progressFrame.WidthRequest = (i * mainFrameWidth) / 100;

                    if (i % 2 == 0)
                    {
                        await Task.Delay(5);
                    }

                    this.progressLabel.Text = $"{i}%";
                }

                await this.progressLabel.ScaleTo(1.3, 150, easing: Easing.BounceOut);
                await this.progressLabel.ScaleTo(1, 150, easing: Easing.BounceIn);
            }

            if (propertyName == nameof(BackgroudBrush))
            {
                this.progressFrame.Background = null;

                switch (BackgroudBrush)
                {
                    case BackgroudBrushType.LinearGradientBrush:
                        {
                            var background = new LinearGradientBrush
                            {
                                StartPoint = new Point(0, 0.5),
                                EndPoint = new Point(0.5, 1.0)
                            };

                            background.GradientStops.Add(
                               new GradientStop(StartColor, 0.0f));
                            background.GradientStops.Add(
                                new GradientStop(StopColor, 0.5f));

                            this.progressFrame.Background = background;
                        }
                        break;

                    case BackgroudBrushType.RadialGradientBrush:
                        {
                            var background = new RadialGradientBrush()
                            {
                                Radius = BrushRadius,

                                GradientStops = new GradientStopCollection
                                {
                                    new GradientStop { Color = StartColor, Offset = 0.25f },
                                    new GradientStop { Color = StopColor, Offset = 0.5f }
                                }
                            };
                            this.progressFrame.Background = background;
                        }
                        break;

                    default:

                        var backgroundColor = new SolidColorBrush
                        {
                            Color = StartColor
                        };
                        this.progressFrame.Background = backgroundColor;

                        break;
                }
            }
        }

        #endregion 
    }
}
