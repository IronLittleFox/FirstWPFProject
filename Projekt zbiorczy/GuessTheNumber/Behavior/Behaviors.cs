using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace GuessTheNumber.Behavior
{
    public class CloseWindowBehavior : Behavior<Window>
    {
        public Key CloseKey { get; set; }

        protected override void OnAttached()
        {
            Window window = AssociatedObject;
            if (window != null)
                window.PreviewKeyDown += window_PreviewKeyDown;
            base.OnAttached();
        }

        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (CloseKey == e.Key)
                (sender as Window)?.Close();
        }

        public static readonly DependencyProperty CloseButtonProperty = DependencyProperty.Register("CloseButton", typeof(Button), typeof(CloseWindowBehavior), new PropertyMetadata(null, PropertyChangedCallback));
        public static readonly DependencyProperty CloseMenuItemProperty = DependencyProperty.Register("CloseMenuItem", typeof(MenuItem), typeof(CloseWindowBehavior), new PropertyMetadata(null, PropertyChangedCallback));

        public Button CloseButton
        {
            get
            {
                return (Button)GetValue(CloseButtonProperty);
            }
            set
            {
                SetValue(CloseButtonProperty, value);
            }
        }

        public MenuItem CloseMenuItem
        {
            get
            {
                return (MenuItem)GetValue(CloseMenuItemProperty);
            }
            set
            {
                SetValue(CloseMenuItemProperty, value);
            }
        }

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = (d as CloseWindowBehavior).AssociatedObject;
            RoutedEventHandler CloseEventClick = (sender, _e) => { window.Close(); };
            if (e.OldValue is Button || e.NewValue is Button)
            {
                if (e.OldValue != null)
                    ((Button)e.OldValue).Click -= CloseEventClick;
                if (e.NewValue != null)
                    ((Button)e.NewValue).Click += CloseEventClick;
            }

            if (e.OldValue is MenuItem || e.NewValue is MenuItem)
            {
                if (e.OldValue != null)
                    ((MenuItem)e.OldValue).Click -= CloseEventClick;
                if (e.NewValue != null)
                    ((MenuItem)e.NewValue).Click += CloseEventClick;
            }

        }
    }

    public static class RotateBehavior
    {
        public static double GetAngle(DependencyObject d)
        {
            return (double)d.GetValue(AngleProperty);
        }

        public static void SetAngle(DependencyObject d, double value)
        {
            d.SetValue(AngleProperty, value);
        }

        public static DependencyProperty AngleProperty = DependencyProperty.RegisterAttached("Angle", typeof(double), typeof(RotateBehavior), new PropertyMetadata(0.0, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement)
            {
                UIElement element = d as UIElement;
                
                element.RenderTransformOrigin = new Point(0.5, 0.5);
                element.RenderTransform = new RotateTransform((double)e.NewValue);
            }
        }
    }
}
