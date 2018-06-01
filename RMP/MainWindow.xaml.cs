using RMP.Pages;
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

namespace RMP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Drive Explorer User Control Selection Changed
        /// Implementation:
        /// Basically, I get the list of available failes that meet
        /// the criteria I specified on the UC to pass those as parameters to
        /// my File List Page;
        /// </summary>
        /// <param name="sender">User Control as Sender</param>
        /// <param name="tv">TreeView inside UC</param>
        private void ucDriveExplorer_SelectionChanged(UserControls.DriveExplorer sender, TreeView tv)
        {
            try
            {
                var images = sender.Images;
                var music = sender.Music;
                var videos = sender.Videos;

                frameFiles.Content = new FileListPage(images, videos, music);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        /// <summary>
        /// Auto-Generated Method
        /// </summary>
        /// <param name="sender">User Control as Sender</param>
        /// <param name="tv">TreeView inside UC</param>
        private void ucDriveExplorer_SelectionChanged(object sender, TreeView tv)
        {
            
        }
    }
}
