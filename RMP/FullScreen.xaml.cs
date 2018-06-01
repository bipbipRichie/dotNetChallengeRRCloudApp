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
using System.Windows.Shapes;

namespace RMP
{
    /// <summary>
    /// Interaction logic for FullScreen.xaml
    /// </summary>
    public partial class FullScreen : Window
    {
        /// <summary>
        /// Window used to show the full screen video user control.
        /// </summary>
        public FullScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Custom Constructor, I'm passing a FileInfo type to set the URI of the media
        /// element, and display the file.
        /// 
        /// The XAML is setted to show up  in full screen with no toolbar.
        /// </summary>
        /// <param name="file">FileInfo file</param>
        public FullScreen(FileInfo file)
        {
            try
            {
                InitializeComponent();
                fullVideo.Source = new Uri(file.FullName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
