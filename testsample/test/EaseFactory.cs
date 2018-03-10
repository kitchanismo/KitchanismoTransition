using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kitchanismo_transition;

namespace test
{
   public class EaseFactory
    {
            public static Dictionary<string, IEasing> t = new Dictionary<string, IEasing> { };

            static EaseFactory()
            {
                t.Clear();
                tTypeList();
            }

            static void tTypeList()
            {
                t.Add("ease_cubicout", IEasing.cubicout);
                t.Add("ease_cubicin", IEasing.cubicin);

                t.Add("ease_cubicinout", IEasing.cubicinout);
                t.Add("ease_bounceout", IEasing.bounceout);

                t.Add("ease_linear", IEasing.linear);
                t.Add("ease_quadin", IEasing.quadin);

                t.Add("ease_quadout", IEasing.quadout);
                t.Add("ease_quadinout", IEasing.quadinout);

                t.Add("ease_quintout", IEasing.quintout);
                t.Add("ease_quintin", IEasing.quintin);

                t.Add("ease_quintinout", IEasing.quintinout);
                t.Add("ease_quartin", IEasing.quartin);

                t.Add("ease_quartout", IEasing.quartout);
                t.Add("ease_quartinout", IEasing.quartinout);

                t.Add("ease_backin", IEasing.backin);
                t.Add("ease_ineaseout", IEasing.ineaseout);
            }

            public static IEasing parseEase(string ease)
            {
                return t[ease];
            }
        }
}
