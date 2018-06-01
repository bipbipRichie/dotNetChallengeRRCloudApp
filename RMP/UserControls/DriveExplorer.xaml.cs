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

namespace RMP.UserControls
{
    /// <summary>
    /// Interaction logic for DriveExplorer.xaml
    /// </summary>
    public partial class DriveExplorer : UserControl
    {

        #region UC Properties

        /// <summary>
        /// To add an empty node.
        /// </summary>
        private object emptyNode = null;

        /// <summary>
        /// The Selected Path to know if the drive/folder contains any media files.
        /// </summary>
        private string SelectedPath = "";

        /// <summary>
        /// Exposed Events to be able to retrieve the list of media files from the window that uses the user control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tv"></param>
        public delegate void SelectionChangedEventHandler (DriveExplorer sender, TreeView tv);
        public event SelectionChangedEventHandler SelectionChanged;

        /// <summary>
        /// List to store the image files
        /// </summary>
        private List<FileInfo> _images;

        /// <summary>
        /// List to store the video files
        /// </summary>
        private List<FileInfo> _videos;

        /// <summary>
        /// List to store the music files
        /// </summary>
        private List<FileInfo> _music;

        /// <summary>
        /// Public propertie for the list of images.
        /// </summary>
        public List<FileInfo> Images {
            get
            {
                if (_images == null)
                    _images = new List<FileInfo>();

                return _images;
            }
            set => _images = value;
        }

        /// <summary>
        /// Public propertie for the list of videos.
        /// </summary>
        public List<FileInfo> Videos {
            get
            {
                if (_videos == null)
                    _videos = new List<FileInfo>();

                return _videos;
            }
            set => _videos = value;
        }

        /// <summary>
        /// /// Public propertie for the list of Music.
        /// </summary>
        public List<FileInfo> Music
        {
            get
            {
                if (_music == null)
                    _music = new List<FileInfo>();

                return _music;
            }
            set => _music = value;
        }

        #endregion

        public DriveExplorer()
        {
            InitializeComponent();
            InitializeTreeView();
        }       

        #region Initializer

        /// <summary>
        /// Gets all the drives and add the items to the treeview control.
        /// 
        /// I used a converter to add ther little folder/drive icon. 
        /// That one is on the XAMl.
        /// </summary>
        private void InitializeTreeView()
        {
            try
            {
                foreach (string s in Directory.GetLogicalDrives())
                {
                    TreeViewItem item = new TreeViewItem();
                    item.Header = s;
                    item.Tag = s;
                    item.FontWeight = FontWeights.Normal;
                    item.Items.Add(emptyNode);
                    item.Expanded += new RoutedEventHandler(FolderExpanded);
                    driveExplorer.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #endregion

        #region UI Interactions        

        /// <summary>
        /// To handle the "open folder" event.
        /// It basically creates a new node and adds it to the
        /// treeview control. Then the converter adds the icon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderExpanded(object sender, RoutedEventArgs e)
        {
            try
            {
                TreeViewItem item = (TreeViewItem)sender;
                if (item.Items.Count == 1 && item.Items[0] == emptyNode)
                {
                    item.Items.Clear();
                    try
                    {
                        foreach (string s in Directory.GetDirectories(item.Tag.ToString()))
                        {
                            TreeViewItem subitem = new TreeViewItem();
                            subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                            subitem.Tag = s;
                            subitem.FontWeight = FontWeights.Normal;
                            subitem.Items.Add(emptyNode);
                            subitem.Expanded += new RoutedEventHandler(FolderExpanded);
                            item.Items.Add(subitem);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Exception: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        /// <summary>
        /// To handle the item selection.
        /// Basically, based on the selected drive/folder, it will try to get
        /// the list of files that the project can open, in this case:
        /// png, jpeg, bmp, mp4, mpeg, mp3,wav.
        /// Once it gets the files that match with the extensions, it will add them to the
        /// corresponding list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void driveExplorer_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            try
            {
                TreeView tree = (TreeView)sender;
                TreeViewItem temp = ((TreeViewItem)tree.SelectedItem);

                if (temp == null)
                    return;
                SelectedPath = "";
                string temp1 = "";
                string temp2 = "";
                while (true)
                {
                    temp1 = temp.Header.ToString();
                    if (temp1.Contains(@"\"))
                        temp2 = "";

                    SelectedPath = temp1 + temp2 + SelectedPath;

                    if (temp.Parent.GetType().Equals(typeof(TreeView)))
                        break;

                    temp = ((TreeViewItem)temp.Parent);
                    temp2 = @"\";
                }


                DirectoryInfo folder = new DirectoryInfo(SelectedPath);


                Images = folder.GetFiles("*.jpg").ToList();
                Images.AddRange(folder.GetFiles("*.png").ToList());
                Images.AddRange(folder.GetFiles("*.bmp").ToList());

                Videos = folder.GetFiles("*.mp4").ToList();
                Videos.AddRange(folder.GetFiles("*.mpeg").ToList());

                Music = folder.GetFiles("*.mp3").ToList();
                Music.AddRange(folder.GetFiles("*.wav").ToList());

                if (this.SelectionChanged != null)
                    this.SelectionChanged(this, sender as TreeView);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"I'm sorry, something went wrong here: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #endregion


    }
}
