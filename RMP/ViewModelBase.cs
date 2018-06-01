using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMP
{
    /// <summary>
    /// This is class that helps us identify if the View is in Design Mode and also helps us 
    /// to handle the RaisePropertyChanged Event.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Indicates if the View is in Design mode, so we can tell our 
        /// view how to behave when is in design mode.
        /// </summary>
        public bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        /// <summary>
        /// This method will notify the View when a Binded property is changed.
        /// </summary>
        /// <param name="propertyName">Name of the Binded Property.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
