using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UpExams
{
    /// <summary>
    /// A view model for each file item in the overview files list
    /// </summary>
    public class FilesListItemViewModel : BaseViewModel
    {
        #region Public Properties
        public int lpuid { get; set; }
        public string mcod { get; set; }
        public string name { get; set; }
        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }
        #endregion

        #region Public Commands
        public ICommand OpenMessageCommand { get; set; }
        #endregion

        #region Constructors
        public FilesListItemViewModel()
        {
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }

        #endregion

        #region Command Methods
        private void OpenMessage()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.MainPage);
            
        }
        #endregion

    }
}
