using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpExams
{
    /// <summary>
    /// A view model for each file item in the overview files list
    /// </summary>
    public class FilesListItemViewModel : BaseViewModel
    {
        public int lpuid { get; set; }
        public string mcod { get; set; }
        public string name { get; set; }
        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
