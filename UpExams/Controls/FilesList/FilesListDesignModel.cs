using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpExams
{
    public class FilesListDesignModel
    {
        /// <summary>
        /// The file list items for the list
        /// </summary>
        public List<FilesListItemViewModel> Items { get; set; } = new List<FilesListItemViewModel>();
        public static FilesListDesignModel Instance { get { return new FilesListDesignModel(); } }
        public FilesListDesignModel()
        {
            Items = new List<FilesListItemViewModel>
            {
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                },
                new FilesListItemViewModel
                {
                    lpuid=1795,
                    mcod="0306121",
                    name="Детская городская поликлиника 121",
                    IsSelected=false
                }
            };
        }
        
    }
}
