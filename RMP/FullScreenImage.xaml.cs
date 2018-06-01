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
    /// Interaction logic for FullScreenImage.xaml
    /// </summary>
    public partial class FullScreenImage : Window
    {
        /// <summary>
        /// Window used to show the full screen image user control.
        /// </summary>
        public FullScreenImage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Custom Constructor, I'm passing a FileInfo type to set the URI of the image
        /// element, and display the file.
        /// 
        /// The XAML is setted to show up  in full screen with no toolbar.
        /// </summary>
        /// <param name="file">FileInfo file</param>
        public FullScreenImage(FileInfo file)
        {
            try
            {
                InitializeComponent();
                fullImage.Source = new Uri(file.FullName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        
    }
}
