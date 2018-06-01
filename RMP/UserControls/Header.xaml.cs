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
    /// This is a super simple and dumb User Control
    /// to handle the application header.
    /// 
    /// On future iterations it could have some buttons or additional options in it.
    /// </summary>
    public partial class Header : UserControl
    {
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public Header()
        {
            InitializeComponent();
        }
    }
}
