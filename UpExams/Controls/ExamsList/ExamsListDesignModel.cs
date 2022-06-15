using foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpExams
{
    public class ExamsListDesignModel
    {
        /// <summary>
        /// The file list items for the list
        /// </summary>
        public List<ExamsListItemViewModel> Items { get; set; } = new List<ExamsListItemViewModel>();
        public static ExamsListDesignModel Instance { get { return new ExamsListDesignModel(); } }
        public ExamsListDesignModel()
        {
            Items = new List<ExamsListItemViewModel>
            {
                new ExamsListItemViewModel
                {
                    exam = new Examination("I34708220708526", 4708, 5398, expertiseCategoryCode.МЭЭ_плановая, new List<string>{"202204"})
                }
            };
        }
    }
}
