using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpExams
{
    /// <summary>
    /// The design-time data for a <see cref="FilesListItemViewModel"/>
    /// </summary>
    public class FilesListItemDesignModel : FilesListItemViewModel
    {
        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static FilesListItemDesignModel Instance { get { return new FilesListItemDesignModel(); } }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public FilesListItemDesignModel()
        {
            lpuid = 1795;
            mcod = "0306121";
            name = "Детская городская поликлиника 121";
            IsSelected = false;
        }
        #endregion
    }
}
