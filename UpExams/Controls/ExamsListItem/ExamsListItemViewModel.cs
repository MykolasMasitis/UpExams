using foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UpExams
{
    /// <summary>
    /// A view model for each file item in the overview files list
    /// </summary>
    public class ExamsListItemViewModel : BaseViewModel
    {
        #region Public Properties
        public Examination exam { get; set; }
        #endregion

        #region Public Commands
        //public ICommand ReadDataFileCommand { get; set; }
        #endregion

        #region Constructors
        public ExamsListItemViewModel()
        {
        }
        public ExamsListItemViewModel(Examination _exam) : base()
        {
            exam = _exam;
        }
        #endregion

        #region Command Methods
        #endregion
    }
}
