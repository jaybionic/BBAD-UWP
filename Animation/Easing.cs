/*
    Written by Jason Kisch [jckisch@gmail.com]
*/
using Windows.Foundation;
using Windows.UI.Xaml.Media.Animation;

namespace Jaycorp.Animation
{
    public class Easing
    {        
        public static SplineDoubleKeyFrame Linear() {
            SplineDoubleKeyFrame sdkf = new SplineDoubleKeyFrame();
            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = new Point(0, 0);
            ks.ControlPoint2 = new Point(1, 1);
            sdkf.KeySpline = ks;
            return sdkf;
        }
        public static SplineDoubleKeyFrame EaseIn() {
            SplineDoubleKeyFrame sdkf = new SplineDoubleKeyFrame();
            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = new Point(0.25, 0.1);
            ks.ControlPoint2 = new Point(0.25, 0.1);
            sdkf.KeySpline = ks;
            return sdkf;
        }
        public static SplineDoubleKeyFrame EaseOut() {
            SplineDoubleKeyFrame sdkf = new SplineDoubleKeyFrame();
            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = new Point(0, 0);
            ks.ControlPoint2 = new Point(0.58, 1);
            sdkf.KeySpline = ks;
            return sdkf;
        }
        public static SplineDoubleKeyFrame FastIn() {
            SplineDoubleKeyFrame sdkf = new SplineDoubleKeyFrame();
            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = new Point(0.1, 0.9);
            ks.ControlPoint2 = new Point(0.2, 1);
            sdkf.KeySpline = ks;
            return sdkf;
        }
        public static SplineDoubleKeyFrame FastOut() {
            SplineDoubleKeyFrame sdkf = new SplineDoubleKeyFrame();
            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = new Point(0.9, 0.1);
            ks.ControlPoint2 = new Point(1, 0.2);
            sdkf.KeySpline = ks;
            return sdkf;
        }
        public static SplineDoubleKeyFrame DrillIn() {
            SplineDoubleKeyFrame sdkf = new SplineDoubleKeyFrame();
            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = new Point(0.17, 0.17);
            ks.ControlPoint2 = new Point(0, 1);
            sdkf.KeySpline = ks;
            return sdkf;
        }
        public static SplineDoubleKeyFrame Custom(double x1, double y1, double x2, double y2) {
            SplineDoubleKeyFrame sdkf = new SplineDoubleKeyFrame();
            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = new Point(x1, y1);
            ks.ControlPoint2 = new Point(x2, y2);
            sdkf.KeySpline = ks;
            return sdkf;
        }
    }
}
