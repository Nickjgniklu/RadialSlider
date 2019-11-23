using System;
using SkiaSharp.Views.Forms;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.ComponentModel;
using System.Windows.Input;

namespace Plugin.RadialSlider
{
    [Browsable(true)]

    public class RadialSlider : ContentView
    {
        static Color KNOBDEFAULT = Color.FromHex("F3F3F3");
        static Color ARCCOLORDEFAULT = Color.ForestGreen;
        static Color ARCBACKGROUNDCOLOR = Color.FromHex("D3D3D3");

        public delegate void ValueChangedHandler(object sender, ValueChangedEventArgs e);
        public event ValueChangedHandler ValueChanged;







        Color _knobColor = KNOBDEFAULT;
        public Color KnobColor
        {
            get { return _knobColor; }
            set
            {
                _knobColor = value;
                canvasView.InvalidateSurface();

            }
        }
        public static readonly BindableProperty KnobColorProperty = BindableProperty.Create(
                                                         propertyName: "KnobColorProperty",
                                                         returnType: typeof(Color),
                                                         declaringType: typeof(RadialSlider),
                                                         defaultValue: KNOBDEFAULT,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: KnobColorPropertyChanged);
        private static void KnobColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadialSlider)bindable;
            control.KnobColor = (Color)newValue;


        }

        Color _arcColor= ARCCOLORDEFAULT;
        public Color ArcColor
        {
            get { return _arcColor; }
            set
            {
                _arcColor = value;
                canvasView.InvalidateSurface();

            }
        }
        public static readonly BindableProperty ArcColorProperty = BindableProperty.Create(
                                                         propertyName: "ArcColor",
                                                         returnType: typeof(Color),
                                                         declaringType: typeof(RadialSlider),
                                                         defaultValue: ARCCOLORDEFAULT,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: ArcColorPropertyChanged);
        private static void ArcColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadialSlider)bindable;
            control.ArcColor = (Color)newValue;


        }
        Color _arcBackgroundColor= ARCBACKGROUNDCOLOR;
        public Color ArcBackgroundColor
        {
            get { return _arcBackgroundColor; }
            set
            {
                _arcBackgroundColor = value;
                canvasView.InvalidateSurface();

            }
        }
        public static readonly BindableProperty ArcBackgroundColorProperty = BindableProperty.Create(
                                                         propertyName: "ArcBackgroundColor",
                                                         returnType: typeof(Color),
                                                         declaringType: typeof(RadialSlider),
                                                         defaultValue: ARCBACKGROUNDCOLOR,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: ArcBackgroundColorPropertyChanged);
        private static void ArcBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadialSlider)bindable;
            control.ArcBackgroundColor = (Color)newValue;


        }
        double _value = 127;
        public double Value
        {
            get { return _value; }
            set
            {
                SetValue(ValueProperty, value);
                _value = value;
                canvasView.InvalidateSurface();

            }
        }
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
                                                         propertyName: "Value",
                                                         returnType: typeof(double),
                                                         declaringType: typeof(RadialSlider),
                                                         defaultValue: (double)127,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: ValuePropertyChanged);
        private static void ValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadialSlider)bindable;
            control.Value = control.Value < control.Max ? (double)newValue : control.Max;
          control.ValueChanged?.Invoke(control, new ValueChangedEventArgs((double)oldValue, (double)newValue));




        }
        double _max = 255;
        public double Max
        {
            get { return _max; }
            set
            {
                _max = value;
                canvasView.InvalidateSurface();

            }
        }
        public static readonly BindableProperty MaxProperty = BindableProperty.Create(
                                                         propertyName: "Max",
                                                         returnType: typeof(double),
                                                         declaringType: typeof(RadialSlider),
                                                         defaultValue: (double)255,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: MaxPropertyChanged);
        private static void MaxPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadialSlider)bindable;
            control.Max = (double)newValue;


        }
        int _precision = 0;
        public int Precision
        {
            get { return _precision; }
            set
            {
                _precision = value;
                canvasView.InvalidateSurface();

            }
        }
        public static readonly BindableProperty PrecisionProperty = BindableProperty.Create(
                                                         propertyName: "Precision",
                                                         returnType: typeof(int),
                                                         declaringType: typeof(RadialSlider),
                                                         defaultValue: (int)0,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: PrecisionPropertyChanged);
        private static void PrecisionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadialSlider)bindable;
            control.Precision = (int)newValue;


        }
        double _min = 0;
        public double Min
        {
            get { return _min; }
            set
            {
                _min = value;
                canvasView.InvalidateSurface();

            }
        }
        public static readonly BindableProperty MinProperty = BindableProperty.Create(
                                                         propertyName: "Min",
                                                         returnType: typeof(double),
                                                         declaringType: typeof(RadialSlider),
                                                         defaultValue: (double)0,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: MinPropertyChanged);
        private static void MinPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadialSlider)bindable;
            control.Min = (double)newValue;


        }

        bool _showValue = false;
        public bool ShowValue
        {
            get { return _showValue; }
            set
            {
                _showValue = value;
                canvasView.InvalidateSurface();

            }
        }
        public static readonly BindableProperty ShowValueProperty = BindableProperty.Create(
                                                         propertyName: "ShowValue",
                                                         returnType: typeof(bool),
                                                         declaringType: typeof(RadialSlider),
                                                         defaultValue: false,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: ShowValuePropertyChanged);
        private static void ShowValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadialSlider)bindable;
            control.ShowValue = (bool)newValue;


        }

        private int arcWidth;
        private int arcPadding;
        private int KnobRadius;
        private float startAngle = 120;//the starting angle of the arc
        private SKPoint Center;
        private SKCanvasView canvasView;
        private int MinorAxisLength;

        //todo when value is changed force a re render with a new percentage instead of point based
        public RadialSlider()
        {
            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
            canvasView.Touch += CanvasView_Touch;
            canvasView.EnableTouchEvents = true;
        }

        private void CanvasView_Touch(object sender, SKTouchEventArgs e)
        {
            var dis = GetDistance(Center.X, e.Location.X, Center.Y, e.Location.Y);
            float adjustedRadius = (MinorAxisLength / 2) - arcPadding;

            if (dis < (adjustedRadius + KnobRadius))
            {


                var angle = (float)(GetAngle(Center.X, e.Location.X, Center.Y, e.Location.Y) + 120) % 360;
                //Debug.WriteLine($"Angle:{angle % 360}");

                float sweepAngle = (startAngle + angle) % 360;// the current endpoint of  the draw arc
                //Debug.WriteLine($"sweepAngle:{sweepAngle }");
                var sweepPercent = sweepAngle / 300;
               // Debug.WriteLine($"sweepPercent:{sweepPercent}");
                double newValue;
                if (Min < 0)
                {
                    newValue = ((Max - Min) * sweepPercent) + Min;
                }
                else
                {
                    newValue = ((Max - Min) * sweepPercent) + Min;

                }

                if (newValue <= Max)
                {
                    Value = Math.Round(newValue, Precision);

                }
                else if (sweepAngle < 320)
                {
                    Value = Max;
                }
                else if (sweepAngle > 340)
                {
                    Value = Min;
                }
            }
            e.Handled = true;


        }
        private float getsweepangle()
        {

            var percentageOfSlider = (Value - Min) / (Max - Min);

            return (float)((percentageOfSlider * 300)) % 360;

        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            //determine find smallet axis length
            MinorAxisLength = info.Width > info.Height ? info.Height : info.Width;
            arcWidth = MinorAxisLength / 30;
            arcPadding = MinorAxisLength / 15;
            KnobRadius = MinorAxisLength / 30;
            float radius = (MinorAxisLength / 2);
            //update center
            Center = new SKPoint(info.Width / 2, info.Height / 2);
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            // canvas.Scale((float)(canvasView.CanvasSize.Width / canvasView.Width));


            //  SKPaint BackgroundPaint = new SKPaint
            //  {
            //      Style = SKPaintStyle.Fill,
            //      Shader = SKShader.CreateColor(BackgroundColor.ToSKColor()),
            //  };
            //
            //  canvas.DrawRect(new SKRect(Center.X-(MinorAxisLength/2), Center.Y - (MinorAxisLength / 2), Center.X + (MinorAxisLength / 2), Center.Y + (MinorAxisLength / 2)), BackgroundPaint);

            SKPaint arcPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Shader = SKShader.CreateColor(ArcColor.ToSKColor()),
                StrokeCap = SKStrokeCap.Round,
                StrokeWidth = arcWidth + 1,
                IsAntialias = true,

            };
            SKPaint arcBackgroundPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Shader = SKShader.CreateColor(ArcBackgroundColor.ToSKColor()),
                StrokeCap = SKStrokeCap.Round,
                StrokeWidth = arcWidth,
                IsAntialias = true,
                // ImageFilter = SKImageFilter.CreateDropShadow(0, 0, 2, 2, Color.Black.ToSKColor(), SKDropShadowImageFilterShadowMode.DrawShadowAndForeground)


            };
            SKPaint KnobPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Shader = SKShader.CreateColor(KnobColor.ToSKColor()),
                IsAntialias = true,
                ImageFilter = SKImageFilter.CreateDropShadow(0, 0, 3, 3, ArcColor.MultiplyAlpha(.5).ToSKColor(), SKDropShadowImageFilterShadowMode.DrawShadowAndForeground)



            };
            SKPaint TextPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Shader = SKShader.CreateColor(Color.Black.ToSKColor()),
                IsAntialias = true,
                TextSize = 40f,
                IsStroke = false,
                TextAlign = SKTextAlign.Center,






            };

            //create the rectangle that contains the arc
            //SKRect rect = new SKRect(arcPadding, arcPadding, MinorAxisLength - arcPadding, MinorAxisLength - arcPadding);
            SKRect rect = new SKRect(arcPadding + Center.X - (MinorAxisLength / 2), arcPadding + Center.Y - (MinorAxisLength / 2), Center.X + (MinorAxisLength / 2) - arcPadding, Center.Y + (MinorAxisLength / 2) - arcPadding);


            //var point = LastTouchedPoint;

            //calcualte the angle of the last touched point realtive to the center of the arc



            var sweepAngle = getsweepangle();
            float realAngle = startAngle + sweepAngle;

            //Debug.WriteLine($"realAngle:{realAngle % 360}");





            float arcRadius = (MinorAxisLength / 2) - arcPadding; ;

            //get x and y compoents o the point on ther arc
            float x = arcRadius * (float)Math.Cos(DegreeToRadian(realAngle));
            float y = arcRadius * (float)Math.Sin(DegreeToRadian(realAngle));

            //move the points realitve to the center of the chart
            // SKRect rect = new SKRect(arcPadding + Center.X - (MinorAxisLength / 2), arcPadding + Center.Y - (MinorAxisLength / 2), Center.X + (MinorAxisLength / 2) - arcPadding, Center.Y + (MinorAxisLength / 2) - arcPadding);

            float realtiveX = x + Center.X;
            float realtiveY = y + Center.Y;


            using (SKPath path = new SKPath())
            {
                //draw background arc
                path.AddArc(rect, startAngle, 300);
                canvas.DrawPath(path, arcBackgroundPaint);
            }
            using (SKPath path = new SKPath())
            {
                //draw arc showing value
                path.AddArc(rect, startAngle, sweepAngle);
                canvas.DrawPath(path, arcPaint);
            }
            //draw current postion
            var TextBounds = new SKRect();
            var ValueString = String.Format("{0:F" + Precision + "}", Value);
            TextPaint.MeasureText(ValueString, ref TextBounds);

            canvas.DrawOval(new SKRect(realtiveX - KnobRadius, realtiveY - KnobRadius, realtiveX + KnobRadius, realtiveY + KnobRadius), KnobPaint);
            if (ShowValue)
            {
                canvas.DrawText(ValueString, Center.X, Center.Y + (TextBounds.Height / 2), TextPaint);
            }



        }

        private double GetDistance(float x1, float x2, float y1, float y2)
        {
            return Math.Sqrt(Math.Pow((double)(x2 - x1), 2) + Math.Pow((double)(y2 - y1), 2));
        }
        private double GetAngle(float x1, float x2, float y1, float y2)
        {
            return RadianToDegree(Math.Atan2(y1 - y2, x1 - x2)) + 180;
        }
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        private double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }


    }

}