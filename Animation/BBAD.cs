/*
    Written by Jason Kisch [jckisch@gmail.com]
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Jaycorp.Animation
{
    //Brutal Beast Animation Destroyer
    public class BBAD
    {

        public static SplineDoubleKeyFrame DefaultEase = Easing.FastIn();

        #region BBAD.To                
        public static Storyboard To(UIElement target, double to, double duration,
                                        double delay, string prop, SplineDoubleKeyFrame ease = null,
                                        Action<object, object> onCompleteFunc = null) {
            if (ease == null) { ease = Easing.Linear(); }
                                  
            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = ease.KeySpline.ControlPoint1;
            ks.ControlPoint2 = ease.KeySpline.ControlPoint2;

            SplineDoubleKeyFrame endFrame = new SplineDoubleKeyFrame();
            endFrame.KeySpline = ks;
            endFrame.Value = to;
            endFrame.KeyTime = TimeSpan.FromMilliseconds(duration);

            DoubleAnimationUsingKeyFrames anim = new DoubleAnimationUsingKeyFrames();
            anim.BeginTime = TimeSpan.FromMilliseconds(delay);
            anim.EnableDependentAnimation = true;
            anim.KeyFrames.Add(endFrame);

            Storyboard.SetTarget(anim, target);
            Storyboard.SetTargetProperty(anim, prop);
            Storyboard sb = new Storyboard();
            sb.Children.Add(anim);
            sb.Completed += onCompleteFunc == null ? null : new EventHandler<object>(onCompleteFunc);
            return sb;
        }
        public static Storyboard To(UIElement target, double to, double duration,
                                            string prop, SplineDoubleKeyFrame ease = null,
                                            Action<object, object> onCompleteFunc = null) {
            return To(target, to, duration, 0, prop, ease, onCompleteFunc);
        }
        #endregion


        #region BBAD.FromTo
        public static Storyboard FromTo(UIElement target, double from, double to, double duration,
                                            double delay, string prop, SplineDoubleKeyFrame ease = null,
                                            Action<object, object> onCompleteFunc = null) {
            if (ease == null) { ease = Easing.Linear(); }
            Storyboard sb = new Storyboard();
            DoubleAnimationUsingKeyFrames anim = new DoubleAnimationUsingKeyFrames(); ;
            EasingDoubleKeyFrame startFrame = new EasingDoubleKeyFrame();
            EasingDoubleKeyFrame midFrame = new EasingDoubleKeyFrame();
            SplineDoubleKeyFrame endFrame = new SplineDoubleKeyFrame();
            KeySpline newKs = new KeySpline();
            newKs.ControlPoint1 = ease.KeySpline.ControlPoint1;
            newKs.ControlPoint2 = ease.KeySpline.ControlPoint2;

            startFrame.Value = from;
            startFrame.KeyTime = TimeSpan.FromSeconds(0);

            midFrame.Value = from;
            midFrame.KeyTime = TimeSpan.FromMilliseconds(delay);

            endFrame.KeySpline = newKs;
            endFrame.Value = to;
            endFrame.KeyTime = TimeSpan.FromMilliseconds(delay + duration);

            anim.KeyFrames.Add(startFrame);
            anim.KeyFrames.Add(midFrame);
            anim.KeyFrames.Add(endFrame);
            anim.Duration = new Duration(TimeSpan.FromMilliseconds(delay + duration));
            anim.EnableDependentAnimation = true;

            Storyboard.SetTarget(anim, target);
            Storyboard.SetTargetProperty(anim, prop);
            sb.Children.Add(anim);

            return sb;
        }
        public static Storyboard FromTo(UIElement target, double from, double to, double duration,
                                            string prop, SplineDoubleKeyFrame ease = null,
                                            Action<object, object> onCompleteFunc = null) {
            return FromTo(target, from, to, duration, 0, prop, ease, onCompleteFunc);
        }
        #endregion


        #region BBAD.All-To/FromTo        
        public static Storyboard AllTo(List<UIElement> targets, double to, double duration, 
                                        double delay, string prop, SplineDoubleKeyFrame ease = null) {
            Storyboard sb = new Storyboard();
            foreach (UIElement t in targets) {
                sb.Children.Add(To(t, to, duration, delay, prop, ease));
            }
            return sb;
        }
        public static Storyboard AllTo(List<UIElement> targets, double to, double duration,
                                        string prop, SplineDoubleKeyFrame ease = null) {
            return AllTo(targets, to, duration, 0, prop, ease);
        }

        public static Storyboard AllFromTo(List<UIElement> targets, double from, double to, double duration,
                                            double delay, string prop, SplineDoubleKeyFrame ease = null) {            
            Storyboard sb = new Storyboard();
            foreach (UIElement t in targets) {                
                sb.Children.Add(FromTo(t, from, to, duration, delay, prop, ease));
            }
            return sb;
        }
        public static Storyboard AllFromTo(List<UIElement> targets, double from, double to, double duration,
                                            string prop, SplineDoubleKeyFrame ease = null) {
            return AllFromTo(targets, from, to, duration, 0, prop, ease);
        }
        #endregion


        #region BBAD.Cascade-To/FromTo
        public static Storyboard CascadeTo(List<UIElement> targets, double to, double duration, 
                                                double delay, double stagger, string prop, SplineDoubleKeyFrame ease = null) {
            Storyboard sb = new Storyboard();
            for (int i = 0; i < targets.Count; i++) {
                sb.Children.Add(To(targets[i], to, duration, ((i * stagger) + delay), prop, ease));
            }
            return sb;
        }
        public static Storyboard CascadeTo(List<UIElement> targets, double to, double duration, 
                                                double stagger, string prop, SplineDoubleKeyFrame ease = null) {
            return CascadeTo(targets, to, duration, 0, stagger, prop, ease);
        }


        public static Storyboard CascadeFromTo(List<UIElement> targets, double from, double to, double duration, 
                                                    double delay, double stagger, string prop, SplineDoubleKeyFrame ease = null) {
            Storyboard sb = new Storyboard();
            for (int i = 0; i < targets.Count; i++) {
                sb.Children.Add(FromTo(targets[i], from, to, duration, ((i * stagger) + delay), prop, ease));
            }
            return sb;
        }
        public static Storyboard CascadeFromTo(List<UIElement> targets, double from, double to, double duration,
                                                    double stagger, string prop, SplineDoubleKeyFrame ease = null) {
            return CascadeFromTo(targets, from, to, duration, 0, stagger, prop, ease);
        }
        #endregion


        #region ColorAnimation
        public static Storyboard ColorTo(UIElement target, Color to, double duration, double delay, string prop, EasingFunctionBase ease = null)
        {
            Storyboard sb = new Storyboard();
            ColorAnimation anim = new ColorAnimation();
            anim.To = to;
            anim.Duration = new Duration(TimeSpan.FromMilliseconds(duration));
            anim.BeginTime = TimeSpan.FromMilliseconds(delay);
            anim.EnableDependentAnimation = true;                                    
            Storyboard.SetTarget(anim, target);
            Storyboard.SetTargetProperty(anim, prop);
            sb.Children.Add(anim);
            return sb;
        }
        public static Storyboard ColorTo(UIElement target, Color to, double duration, string prop, EasingFunctionBase ease = null) {
            return ColorTo(target, to, duration, prop, ease);
        }
        #endregion


        #region Visibility/Opacity
        public static Storyboard FadeInAutoOn(UIElement target, double duration, double opacity = 1) {
            AutoOn(target, 0);
            return To(target, opacity, duration, GetProp.Opacity, Easing.Linear());
        }
        public static Storyboard FadeInAutoOn(UIElement target, double duration, double delay, double opacity = 1) {
            AutoOn(target, 0);
            return To(target, opacity, duration, delay, GetProp.Opacity, Easing.Linear());
        }
        public static Storyboard FadeOutAutoOff(UIElement target, double duration) {
            return To(target, 0, duration, GetProp.Opacity, Easing.Linear(), (a, b) => {
                AutoOff(target);
            });
        }
        public static Storyboard FadeOutAutoOff(UIElement target, double duration, double delay) {
            return To(target, 0, duration, delay, GetProp.Opacity, Easing.Linear(), (a, b) => {
                AutoOff(target);
            });
        }
        public static UIElement AutoOff(UIElement el)
        {
            el.Visibility = Visibility.Collapsed;
            el.Opacity = 0;
            return el;
        }
        public static void AutoOffMulti(List<UIElement> targets) {
            foreach (UIElement el in targets) {
                el.Visibility = Visibility.Collapsed;
                el.Opacity = 0;
            }
        }
        public static UIElement AutoOn(UIElement el, double alpha = 1)
        {
            el.Visibility = Visibility.Visible;
            el.Opacity = alpha;
            return el;
        }
        public static void AutoOnMulti(List<UIElement> targets, double alpha = 1) {
            foreach (UIElement el in targets) {
                el.Visibility = Visibility.Visible;
                el.Opacity = alpha;
            }
        }
        #endregion


        #region Helpers
        public static UIElement InitTransform(UIElement el, double X = 0, double Y = 0, double ScaleX = 1, double ScaleY = 1, 
                                                double OriginX = 0.5, double OriginY = 0.5) {
            CompositeTransform c = new CompositeTransform();
            c.TranslateX = X;
            c.TranslateY = Y;
            c.ScaleX = ScaleX;
            c.ScaleY = ScaleY;
            el.RenderTransformOrigin = new Point(OriginX, OriginY);
            el.RenderTransform = c;
            return el;
        }
        public static void InitTransformMulti(List<UIElement> targets, double X = 0, double Y = 0, double ScaleX = 1, double ScaleY = 1, 
                                                double OriginX = 0.5, double OriginY = 0.5) {
            CompositeTransform c = new CompositeTransform();
            c.TranslateX = X;
            c.TranslateY = Y;
            c.ScaleX = ScaleX;
            c.ScaleY = ScaleY;
            foreach (UIElement el in targets) {
                el.RenderTransformOrigin = new Point(0.5, 0.5);
                el.RenderTransform = c;
            }
        }

        public static List<UIElement> GetList(UIElement obj)
        {
            List<UIElement> l = new List<UIElement>();
            if(obj.GetType() == typeof(ListView)) {
                ListView lv = obj as ListView;
                l = lv.Items.OfType<UIElement>().ToList<UIElement>();
            } else if (obj.GetType() == typeof(Grid) || obj.GetType() == typeof(StackPanel)) {
                Panel p = obj as Panel;
                l = p.Children.OfType<UIElement>().ToList<UIElement>();
            }
            return l;
        }
        #endregion
    }
}
