using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.Xaml.Behaviors;
using Munchkin.ViewModels;

namespace Munchkin.Behaviors
{
    public class TurnOverBehavior : Behavior<ContentControl>
    {
        public static readonly DependencyProperty ToRightProperty = DependencyProperty.Register(nameof(ToRight), typeof(bool), typeof(TurnOverBehavior), new PropertyMetadata(true));
        public bool ToRight
        {
            get => (bool)GetValue(ToRightProperty);
            set => SetValue(ToRightProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.DataContextChanged += AssociatedObjectOnDataContextChanged;
        }

        private void AssociatedObjectOnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((CardBaseViewModel)AssociatedObject.DataContext).TurnOver += OnTurnOver;
        }

        private bool IsTurned;
        private bool IsCompleted = true;

        private void OnTurnOver(object? sender, EventArgs e)
        {
            if (!IsCompleted) return;

            IsTurned = false; 
            IsCompleted = false;
            
            if (!ToRight)
            {
                MatrixAnimationUsingKeyFrames mt = new MatrixAnimationUsingKeyFrames();
                TranslateTransform tt = new TranslateTransform();
                double time = 180;
                int ss = 180;
                double xOffset = 0;
                Matrix matrix = new Matrix();
                while (ss <= 360)
                {
                    matrix = new Matrix(-Math.Cos(ss * Math.PI / 180), Math.Sin(ss * Math.PI / 180), 0, 1, xOffset, 0);
                    mt.KeyFrames.Add(new DiscreteMatrixKeyFrame(matrix, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(time))));
                    ss += 1;
                    xOffset += 180.0 / 180.0;
                    time += 2;
                }

                MatrixTransform mat = new MatrixTransform();
                TransformGroup group = new TransformGroup();
                group.Children.Add(mat);
                AssociatedObject.RenderTransform = group;
                mat.Changed += MatOnChanged;
                mt.Completed += MtOnCompleted;
                mat.BeginAnimation(MatrixTransform.MatrixProperty, mt, HandoffBehavior.SnapshotAndReplace);
            }
        }

        private void MatOnChanged(object? sender, EventArgs e)
        {
            if (sender is MatrixTransform mat)
            {
                if (!IsTurned && mat.Value.OffsetX >= 90)
                {
                    ((CardBaseViewModel)this.AssociatedObject.DataContext).IsCover = !((CardBaseViewModel)this.AssociatedObject.DataContext).IsCover;
                    AssociatedObject.LayoutTransform = new ScaleTransform(-1, 1);
                    IsTurned = true;
                }
            }
        }

        private void MtOnCompleted(object? sender, EventArgs e)
        {
            AssociatedObject.LayoutTransform = null;
            AssociatedObject.RenderTransform = null;
            IsCompleted = true;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            // Удаление обработчиков событий
            ((CardBaseViewModel)this.AssociatedObject.DataContext).TurnOver -= OnTurnOver;
        }
    }
}
