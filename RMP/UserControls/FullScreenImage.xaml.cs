using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RMP.UserControls
{
    /// <summary>
    /// Interaction logic for FullScreenImage.xaml
    /// </summary>
    public partial class FullScreenImage : UserControl
    {
        #region Properties
        /// <summary>
        /// I'm adding this propertie to be able to bind the file source to my Image control.
        /// </summary>
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(Uri), typeof(FullScreenImage));

        /// <summary>
        /// Exposed propertie to bind the image source.
        /// </summary>
        public Uri Source
        {
            get
            {
                return (Uri)this.GetValue(SourceProperty);
            }
            set
            {
                this.SetValue(SourceProperty, value);
            }
        }

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FullScreenImage()
        {
            InitializeComponent();
        }        

        #region UI Events

        /// <summary>
        /// Method used to zoom in/zoom out using the Mouse Wheel;
        /// Basically we take the mouse position and based on that we increment/decrement the scale.
        /// </summary>
        /// <param name="sender">The ImageControl</param>
        /// <param name="e">Mouse Event Args</param>
        private void imageViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            try
            {
                var position = e.MouseDevice.GetPosition(imageViewer);
                var renderTransformValue = imageViewer.RenderTransform.Value;

                if (e.Delta > 0)
                    renderTransformValue.ScaleAtPrepend(1.1, 1.1, position.X, position.Y);
                else
                    renderTransformValue.ScaleAtPrepend(1 / 1.1, 1 / 1.1, position.X, position.Y);

                imageViewer.RenderTransform = new MatrixTransform(renderTransformValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Method to exit the full screen mode.
        /// Really simple, if the user clicks on the image, the full screen
        /// window closes and the main window shows up.
        /// 
        /// Could be improved passing current zoom.
        /// </summary>
        /// <param name="sender">Icon/Inage/Button</param>
        /// <param name="e">Mouse Event Args</param>
        private void OnMouseDownFullScreen(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Window parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        
        }
        #endregion
    }
}
