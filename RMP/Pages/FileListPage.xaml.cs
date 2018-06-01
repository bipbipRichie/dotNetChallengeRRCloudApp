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
    /// Interaction logic for FileListPage.xaml
    /// </summary>
    public partial class FileListPage : Page
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FileListPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Custom Constructor
        /// It takes the lists of FileInfo items to populate the 
        /// different listviews that are inside the Tabs.
        /// </summary>
        /// <param name="Images">List of Images</param>
        /// <param name="Videos">List of Videos</param>
        /// <param name="Music">List of Music</param>
        public FileListPage(List<FileInfo> Images, List<FileInfo> Videos, List<FileInfo> Music)
        {
            try
            {
                InitializeComponent();
                SetTabs(Images, Videos, Music);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #region Initializer

        /// <summary>
        /// This method is used to set the listviews item sources based on the lists i got from the constructor.
        /// </summary>
        /// <param name="images">Image List</param>
        /// <param name="videos">Video List</param>
        /// <param name="music">Music List</param>
        private void SetTabs(List<FileInfo> images, List<FileInfo> videos, List<FileInfo> music)
        {
            try
            {
                if (images.Any())
                    lvImages.ItemsSource = images;
                if (music.Any())
                    lvMusic.ItemsSource = music;
                if (videos.Any())
                    lvVideos.ItemsSource = videos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region UI Events

        /// <summary>
        /// Based on the selected item on the image listview,
        /// I create a new MediaPlayer file sending as parameter
        /// the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var file = (FileInfo)lvImages.SelectedItem;

                var parent = Window.GetWindow(this);
                var mainWindow = (MainWindow)parent;
                mainWindow.frameMediaViewer.Content = new MediaPlayer(file);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Based on the selected item on the image listview,
        /// I create a new MediaPlayer file sending as parameter
        /// the file and sending also a bool var that tells the mediaplayer page that
        /// this is a media file (music/video).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvVideos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var file = (FileInfo)((ListView)sender).SelectedItem;

                var parent = Window.GetWindow(this);
                var mainWindow = (MainWindow)parent;
                mainWindow.frameMediaViewer.Content = new MediaPlayer(file, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #endregion
    }
}
