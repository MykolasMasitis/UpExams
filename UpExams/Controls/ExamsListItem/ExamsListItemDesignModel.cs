using foundation;
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
    public class ExamsListItemDesignModel : ExamsListItemViewModel
    {
        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ExamsListItemDesignModel Instance { get { return new ExamsListItemDesignModel(); } }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ExamsListItemDesignModel()
        {
            exam = new Examination("I35130110708490", 4522, 5398, expertiseCategoryCode.МЭЭ_плановая, new List<string> { "202204" }) { Id = 1 };
        }
        #endregion
    }
}
