/*
    Written by Jason Kisch [jckisch@gmail.com]
*/

namespace Jaybionic.Animation
{
    public class GetProp
    {
        public static string Opacity = "Opacity";
        public static string X = "(UIElement.RenderTransform).(CompositeTransform.TranslateX)";
        public static string Y = "(UIElement.RenderTransform).(CompositeTransform.TranslateY)";
        public static string Width = "(FrameworkElement.Width)";
        public static string Height = "(FrameworkElement.Height)";
        public static string ScaleX = "(UIElement.RenderTransform).(CompositeTransform.ScaleX)";
        public static string ScaleY = "(UIElement.RenderTransform).(CompositeTransform.ScaleY)";
        public static string Rotation = "(UIElement.RenderTransform).(CompositeTransform.Rotation)";
        public static string ProjectionX = "(UIElement.Projection).(PlaneProjection.RotationX)";
        public static string ProjectionY = "(UIElement.Projection).(PlaneProjection.RotationY)";
        public static string ProjectionZ = "(UIElement.Projection).(PlaneProjection.RotationZ)";
        public static string Background = "(FrameworkElement.Background).(SolidColorBrush.Color)";
        public static string Foreground = "(Control.Foreground).(SolidColorBrush.Color)";
        public static string Fill = "(Shape.Fill).(SolidColorBrush.Color)";
        public static string Stroke = "(Path.Stroke).(SolidColorBrush.Color)";
        public static string FontSize = "(TextBlock.FontSize)";
    }
    
}
