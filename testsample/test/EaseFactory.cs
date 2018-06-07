using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kitchanismo;

namespace test
{
   public class EaseFactory
    {
            public static Dictionary<string, Easing> ease = new Dictionary<string, Easing> { };

            static EaseFactory()
            {
                ease.Clear();
                TypeList();
            }

            static void TypeList()
            {
                ease.Add("ease_cubicout", Easing.CubicOut);
                ease.Add("ease_cubicin", Easing.CubicIn);

                ease.Add("ease_cubicinout",Easing.CubicInOut);
                ease.Add("ease_bounceout", Easing.BounceOut);

                ease.Add("ease_linear", Easing.Linear);
                ease.Add("ease_quadin", Easing.QuadIn);

                ease.Add("ease_quadout", Easing.QuadOut);
                ease.Add("ease_quadinout", Easing.QuadInOut);

                ease.Add("ease_quintout", Easing.QuintOut);
                ease.Add("ease_quintin", Easing.QuintIn);

                ease.Add("ease_quintinout", Easing.QuintInOut);
                ease.Add("ease_quartin", Easing.QuartIn);

                ease.Add("ease_quartout", Easing.QuartOut);
                ease.Add("ease_quartinout", Easing.QuartInOut);

                ease.Add("ease_backin", Easing.BackIn);
                ease.Add("ease_ineaseout", Easing.EaseInOut);
            }

            public static Easing ParseEase(string _ease)
            {
                return ease[_ease];
            }
        }
}
