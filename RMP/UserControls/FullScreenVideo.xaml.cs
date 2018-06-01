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
    /// Interaction logic for FullScreenVideo.xaml
    /// </summary>
    public partial class FullScreenVideo : UserControl
    {

        #region Properties

        /// <summary>
        /// Private propertie used to know if a media file is playing.
        /// </summary>
        private bool isPlaying = false;

        /// <summary>
        /// Exposed propertie to bind the media source.
        /// </summary>
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(Uri), typeof(FullScreenVideo));
        
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

        public FullScreenVideo()
        {
            try
            {
                InitializeComponent();
                if (mediaPlayer != null)
                    mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #region UI Events

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
        /// Method used to handle the fullscreen option.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
