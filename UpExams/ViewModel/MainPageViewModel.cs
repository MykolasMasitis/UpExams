using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UpExams
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Private members
        #endregion

        #region Public properties
        #endregion

        #region Commands
        public ICommand AttachCommand { get; set; }
        #endregion

        public MainPageViewModel()
        {
            AttachCommand = new RelayCommand(AttachMethod);
        }
        public void AttachMethod()
        {
            MessageBox.Show("OK!");
        }
    }
}
