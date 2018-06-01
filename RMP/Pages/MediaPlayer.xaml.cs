using System;
using System.Collections.Generic;
using System.IO;
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

namespace RMP.Pages
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : Page
    {
        #region Properties
        private bool isPlaying = false;
        private bool isMedia = false;
        private FileInfo file;
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MediaPlayer()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Custom Constructor
        /// Takes a file as parameter and also a bool to know if the file is a media file (audio/video)
        /// or an image file.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="isMultimedia"></param>
        public MediaPlayer(FileInfo file, bool isMultimedia = false)
        {
            InitializeComponent();
            isMedia = isMultimedia;
            SetUI(file,isMultimedia);
        }

        /// <summary>
        /// Method used to set the UI based on the file type, media or image.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="isMultimedia"></param>
        private void SetUI(FileInfo file, bool isMultimedia)
        {
            if (isMultimedia)
                SetMediaElement(file);
            else
                SetImageViewer(file);            
        }

        /// <summary>
        /// Method used to initialize the Media PLayer in the Image Configuration.
        /// </summary>
        /// <param name="file"></param>
        private void SetImageViewer(FileInfo file)
        {
            mediaPlayer.Visibility = Visibility.Hidden;
            imageViewer.Visibility = Visibility.Visible;
            imageViewer.Source = new BitmapImage((new Uri(file.FullName)));
            mediaControls.Visibility = Visibility.Hidden;
            imageControls.Visibility = Visibility.Visible;
            this.file = file;
        }

        /// <summary>
        /// Method used to initialize the Media PLayer in the Media Configuration.
        /// </summary>
        /// <param name="file"></param>
        private void SetMediaElement(FileInfo file)
        {
            mediaPlayer.Visibility = Visibility.Visible;
            imageViewer.Visibility = Visibility.Hidden;
            mediaPlayer.Source = new Uri(file.FullName);
            mediaControls.Visibility = Visibility.Visible;
            imageControls.Visibility = Visibility.Hidden;

            this.file = file;
            isPlaying = true;
            mediaPlayer.Play();
            
        }

        /// <summary>
        /// I added this methodS to play/pause the file if the user clicks on the media element.
        /// It only works for videos :(
        /// </summary>
        /// <param name="sender">Media Elementr</param>
        /// <param name="e"></param>
        private void mediaPlayer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (!isPlaying)
                {
                    mediaPlayer.Play();
                    isPlaying = true;
                }
                else
                {
                    mediaPlayer.Pause();
                    isPlaying = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        // Play method will begin the media if it is not active or 
        // resume media if it is paused. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDownPlayMedia(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (mediaPlayer != null)
                {
                    mediaPlayer.Play();
                    InitializePropertyValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        // The Pause method pauses the media if it is currently running.
        // The Play method can be used to resume.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDownPauseMedia(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (mediaPlayer != null)
                    mediaPlayer.Pause();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        // The Stop method stops and resets the media to be played from
        // the beginning.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDownStopMedia(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (mediaPlayer != null)
                    mediaPlayer.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// I took an example from the microsoft documentation to do this.
        /// Basically this method takes the value of the volume slider and use it to
        /// change the media element volume.
        /// </summary>
        /// <param name="sender">Slider</param>
        /// <param name="e">Slider Routed Events</param>
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (mediaPlayer != null)
                    mediaPlayer.Volume = (double)volumeSlider.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// This method is to change the speed ratio/reproduction
        /// of the media element.
        /// </summary>
        /// <param name="sender">Slider</param>
        /// <param name="e">Slider Routed Events</param>
        private void ChangeMediaSpeedRatio(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (mediaPlayer != null)
                    mediaPlayer.SpeedRatio = (double)speedRatioSlider.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// I used this method to move trought the file position.
        /// I think it can be improved since this implementation is quite slow.
        /// </summary>
        /// <param name="sender">Slider</param>
        /// <param name="e">Slider Routed Events</param>
        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (mediaPlayer != null)
                {
                    int SliderValue = (int)timelineSlider.Value;

                    // Overloaded constructor takes the arguments days, hours, minutes, seconds, miniseconds.
                    // Create a TimeSpan with miliseconds equal to the slider value.
                    TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
                    mediaPlayer.Position = ts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Method used to set the time line slider (seek) once a media file is opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mediaPlayer != null)
                    timelineSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Method used to handle the mediaEnded event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mediaPlayer != null)
                    mediaPlayer.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        // Set the media's starting Volume and SpeedRatio to the current value of the
        // their respective slider controls.
        /// </summary>
        private void InitializePropertyValues()
        {
            try
            {
                if (mediaPlayer != null)
                {
                    mediaPlayer.Volume = (double)volumeSlider.Value;
                    mediaPlayer.SpeedRatio = (double)speedRatioSlider.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Method used to zoom in/zoom out using the Mouse Wheel;
        /// Basically we take the mouse position and based on that we increment/decrement the scale.
        /// </summary>
        /// <param name="sender">The ImageControl</param>
        /// <param name="e">Mouse Event Args</param>
        private void imageViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var position = e.MouseDevice.GetPosition(imageViewer);
            var renderTransformValue = imageViewer.RenderTransform.Value;

            if (e.Delta > 0)
                renderTransformValue.ScaleAtPrepend(1.1, 1.1, position.X, position.Y);
            else
                renderTransformValue.ScaleAtPrepend(1 / 1.1, 1 / 1.1, position.X, position.Y);

            imageViewer.RenderTransform = new MatrixTransform(renderTransformValue);
        }
        
        /// <summary>
        /// Method to enter the full screen mode.
        /// Really simple, if the user clicks on the image, the full screen
        /// window closes and the main window shows up.
        /// 
        /// Could be improved passing current zoom.
        /// </summary>
        /// <param name="sender">Icon/Inage/Button</param>
        /// <param name="e">Mouse Event Args</param>
        private void OnMouseDownFullScreen(object sender, MouseButtonEventArgs e)
        {
            if (isMedia)
            {
                mediaPlayer.Stop();
                var fsw = new FullScreen(file);
                fsw.Show();
            }
            else
            {
                var fsw = new FullScreenImage(file);
                fsw.Show();
            }
        }

        /// <summary>
        /// I tried to implement the zoomSlider feature but due to the lack of time i wasnt able to make it work :(
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }
    }
}
