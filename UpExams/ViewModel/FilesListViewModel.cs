using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpExams
{
    public class FilesListViewModel : BaseViewModel
    {
        /// <summary>
        /// The file list items for the list
        /// </summary>
        public List<FilesListItemViewModel> Items { get; set; }
    }
}
