using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Introduce
{
    public class PositionHandler : Window
    {
        public static double ArrowWidth { get; set; } = 50;

        public static double ArrowHeight { get; set; } = 100;

        public static double ArrowWidthOffset { get; set; }

        public static double ArrowHeightOffset { get; set; }

        public static double InfoWidth { get; set; }

        public static double InfoHeight { get; set; }

        public static double InfoWidthOffset { get; set; }

        public static double InfoHeightOffset { get; set; }

        public static PositionResponse Draw(FrameworkElement container,Type t, string name, double arrowWidthOffset, double arrowHeightOffset,
            double infoWidthOffset, double infoHeightOffset, PositionDirectionEnum positionDirectionEnum)
        {
            var res = new PositionResponse();
            var control = FindFirstVisualChild(t,container, name);
            if (control != null)
            {
                var fatherPoint = container.PointToScreen(new Point(0, 0));
                var childPoint = control.PointToScreen(new Point(0, 0));
                var point = new Point(0,0)+(childPoint-fatherPoint);
                var height = control.ActualHeight;
                var width = control.ActualWidth;
                res.Rect = new Rect(point, new Size(width, height));
                ArrowWidthOffset = arrowWidthOffset;
                ArrowHeightOffset = arrowHeightOffset;
                InfoWidthOffset = infoWidthOffset;
                InfoHeightOffset = infoHeightOffset;
                switch (positionDirectionEnum)
                {
                    case PositionDirectionEnum.Bottom:
                        res.PathGeometry = new PathGeometry
                        {
                            Figures = new PathFigureCollection
                            {
                                new PathFigure
                                {
                                    IsClosed = true,
                                    Segments = ArrorwBottom(new Point(point.X,point.Y+height))
                                }
                            }
                        };
                        res.Xy = InfoBottom(new Point(point.X, point.Y + height));
                        break;
                    case PositionDirectionEnum.Right:
                        res.PathGeometry = new PathGeometry
                        {
                            Figures = new PathFigureCollection
                            {
                                new PathFigure
                                {
                                    IsClosed = true,
                                    Segments = ArrorwRight(new Point(point.X+width,point.Y))
                                }
                            }
                        };
                        res.Xy = InfoRight(new Point(point.X + width, point.Y));
                        break;
                    case PositionDirectionEnum.Left:
                        res.PathGeometry = new PathGeometry
                        {
                            Figures = new PathFigureCollection
                            {
                                new PathFigure
                                {
                                    IsClosed = true,
                                    Segments = ArrorwLeft(point)
                                }
                            }
                        };
                        res.Xy = InfoLeft(point);
                        break;
                    case PositionDirectionEnum.Top:
                        res.PathGeometry = new PathGeometry
                        {
                            Figures = new PathFigureCollection
                            {
                                new PathFigure
                                {
                                    IsClosed = true,
                                    Segments = ArrorwTop(point)
                                }
                            }
                        };
                        res.Xy = InfoTop(point);
                        break;
                }
                return res;
            }
            return null;
        }

        public static PositionResponse Draw<T>(FrameworkElement container, string name, double arrowWidthOffset, double arrowHeightOffset,
            double infoWidthOffset, double infoHeightOffset, PositionDirectionEnum positionDirectionEnum) where T : FrameworkElement
        {
            var res = new PositionResponse();
            var control = FindFirstVisualChild<T>(container, name);
            if (control != null)
            {
                var point = control.PointToScreen(new Point(0, 0));
                var height = control.ActualHeight;
                var width = control.ActualWidth;
                res.Rect = new Rect(point, new Size(width, height));
                ArrowWidthOffset = arrowWidthOffset;
                ArrowHeightOffset = arrowHeightOffset;
                InfoWidthOffset = infoWidthOffset;
                InfoHeightOffset = infoHeightOffset;
                switch (positionDirectionEnum)
                {
                    case PositionDirectionEnum.Bottom:
                        res.PathGeometry = new PathGeometry
                        {
                            Figures = new PathFigureCollection
                            {
                                new PathFigure
                                {
                                    IsClosed = true,
                                    Segments = ArrorwBottom(new Point(point.X,point.Y+height))
                                }
                            }
                        };
                        res.Xy = InfoBottom(new Point(point.X, point.Y + height));
                        break;
                    case PositionDirectionEnum.Right:
                        res.PathGeometry = new PathGeometry
                        {
                            Figures = new PathFigureCollection
                            {
                                new PathFigure
                                {
                                    IsClosed = true,
                                    Segments = ArrorwRight(new Point(point.X+width,point.Y))
                                }
                            }
                        };
                        res.Xy = InfoRight(new Point(point.X + width, point.Y));
                        break;
                    case PositionDirectionEnum.Left:
                        res.PathGeometry = new PathGeometry
                        {
                            Figures = new PathFigureCollection
                            {
                                new PathFigure
                                {
                                    IsClosed = true,
                                    Segments = ArrorwLeft(point)
                                }
                            }
                        };
                        res.Xy = InfoLeft(point);
                        break;
                    case PositionDirectionEnum.Top:
                        res.PathGeometry = new PathGeometry
                        {
                            Figures = new PathFigureCollection
                            {
                                new PathFigure
                                {
                                    IsClosed = true,
                                    Segments = ArrorwTop(point)
                                }
                            }
                        };
                        res.Xy = InfoTop(point);
                        break;
                }
                return res;
            }
            return null;
        }

        public static PathSegmentCollection ArrorwTop(Point origin)
        {
            var newOrigin = new Point(origin.X + ArrowWidthOffset, origin.Y + ArrowHeightOffset);
            var sc = new PathSegmentCollection();
            sc.Add(new LineSegment(newOrigin, true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowWidth / 2, newOrigin.Y - ArrowHeight / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowWidth / 4, newOrigin.Y - ArrowHeight / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowWidth / 4, newOrigin.Y - ArrowHeight / 3 * 2), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowWidth / 4, newOrigin.Y - ArrowHeight / 3 * 2), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowWidth / 4, newOrigin.Y - ArrowHeight / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowWidth / 2, newOrigin.Y - ArrowHeight / 3), true));
            sc.Add(new LineSegment(newOrigin, true));

            return sc;
        }

        public static PathSegmentCollection ArrorwBottom(Point origin)
        {
            var newOrigin = new Point(origin.X + ArrowWidthOffset, origin.Y + ArrowHeightOffset);
            var sc = new PathSegmentCollection();
            sc.Add(new LineSegment(newOrigin, true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowWidth / 2, newOrigin.Y + ArrowHeight / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowWidth / 4, newOrigin.Y + ArrowHeight / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowWidth / 4, newOrigin.Y + ArrowHeight / 3 * 2), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowWidth / 4, newOrigin.Y + ArrowHeight / 3 * 2), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowWidth / 4, newOrigin.Y + ArrowHeight / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowWidth / 2, newOrigin.Y + ArrowHeight / 3), true));
            sc.Add(new LineSegment(newOrigin, true));
            return sc;
        }

        public static PathSegmentCollection ArrorwLeft(Point origin)
        {
            var newOrigin = new Point(origin.X + ArrowWidthOffset, origin.Y + ArrowHeightOffset);
            var sc = new PathSegmentCollection();
            sc.Add(new LineSegment(newOrigin, true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowHeight / 3, newOrigin.Y - ArrowWidth / 2), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowHeight / 3, newOrigin.Y - ArrowWidth / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowHeight, newOrigin.Y - ArrowWidth / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowHeight, newOrigin.Y + ArrowWidth / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowHeight / 3, newOrigin.Y + ArrowWidth / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X - ArrowHeight / 3, newOrigin.Y + ArrowWidth / 2), true));
            sc.Add(new LineSegment(newOrigin, true));

            return sc;
        }

        public static PathSegmentCollection ArrorwRight(Point origin)
        {
            var newOrigin = new Point(origin.X + ArrowWidthOffset, origin.Y + ArrowHeightOffset);
            var sc = new PathSegmentCollection();
            sc.Add(new LineSegment(newOrigin, true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowHeight / 3, newOrigin.Y - ArrowWidth / 2), true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowHeight / 3, newOrigin.Y - ArrowWidth / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowHeight, newOrigin.Y - ArrowWidth / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowHeight, newOrigin.Y + ArrowWidth / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowHeight / 3, newOrigin.Y + ArrowWidth / 3), true));
            sc.Add(new LineSegment(new Point(newOrigin.X + ArrowHeight / 3, newOrigin.Y + ArrowWidth / 2), true));
            sc.Add(new LineSegment(newOrigin, true));
            return sc;
        }

        public static double[] InfoTop(Point origin)
        {
            var newOrigin = new Point(origin.X + ArrowWidthOffset, origin.Y + ArrowHeightOffset);
            return new[] { newOrigin.X + InfoWidthOffset, newOrigin.Y - ArrowHeight / 3 * 2 + InfoHeightOffset };
        }

        public static double[] InfoBottom(Point origin)
        {
            var newOrigin = new Point(origin.X + ArrowWidthOffset, origin.Y + ArrowHeightOffset);
            return new[] { newOrigin.X + InfoWidthOffset, newOrigin.Y + ArrowHeight / 3 * 2 + InfoHeightOffset };
        }

        public static double[] InfoLeft(Point origin)
        {
            var newOrigin = new Point(origin.X + ArrowWidthOffset, origin.Y + ArrowHeightOffset);
            return new[] { newOrigin.X - ArrowHeight + InfoWidthOffset, newOrigin.Y + InfoHeightOffset };
        }

        public static double[] InfoRight(Point origin)
        {
            var newOrigin = new Point(origin.X + ArrowWidthOffset, origin.Y + ArrowHeightOffset);
            return new[] { newOrigin.X + ArrowHeight + InfoWidthOffset, newOrigin.Y + InfoHeightOffset };
        }

        public static T FindFirstVisualChild<T>(DependencyObject obj, string childName) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                var visualChild = child as T;
                if (visualChild != null && visualChild.GetValue(NameProperty).ToString() == childName)
                {
                    return visualChild;
                }
                T childOfChild = FindFirstVisualChild<T>(child, childName);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
            return null;
        }

        public static FrameworkElement FindFirstVisualChild(Type t, DependencyObject obj, string childName)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child.GetType() == t)
                {
                    var visualChild = child;
                    if (!string.IsNullOrEmpty(childName) && visualChild.GetValue(NameProperty).ToString() == childName)
                    {
                        return visualChild as FrameworkElement;
                    }
                }

                var childOfChild = FindFirstVisualChild(t, child, childName);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
            return null;
        }

        public static List<T> GetChildObjects<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject child = null;
            List<T> childList = new List<T>();
            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);
                var item = child as T;
                if (item != null && (item.Name == name || string.IsNullOrEmpty(name)))
                {
                    childList.Add(item);
                }
                childList.AddRange(GetChildObjects<T>(child, ""));
            }
            return childList;
        }
    }
}
