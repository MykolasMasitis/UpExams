using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UpExams
{
    public class ExamsListViewModel : BaseViewModel
    {
        public ExamsListViewModel() { }
        /// <summary>
        /// The file list items for the list
        /// </summary>
        public List<ExamsListItemViewModel> Items { get; set; } = new List<ExamsListItemViewModel>();
    }
}
