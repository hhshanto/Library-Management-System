using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace LibraryManagementSystem
{
    public static class BlurElementExtension
    {
        public static void BlurApply(this UIElement element,
        double blurRadius, TimeSpan duration, TimeSpan beginTime)
        {
            BlurEffect blur = new BlurEffect() { Radius = 0 };
            DoubleAnimation blurEnable = new DoubleAnimation(0, blurRadius, duration)
            { BeginTime = beginTime };
            element.Effect = blur;
            blur.BeginAnimation(BlurEffect.RadiusProperty, blurEnable);
        }

        public static void BlurDisable(this UIElement element, TimeSpan duration, TimeSpan beginTime)
        {
            BlurEffect blur = element.Effect as BlurEffect;
            if (blur == null || blur.Radius == 0)
            {
                return;
            }
            DoubleAnimation blurDisable = new DoubleAnimation(blur.Radius, 0, duration) { BeginTime = beginTime };
            blur.BeginAnimation(BlurEffect.RadiusProperty, blurDisable);
        }
    }
}
