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
    public class FilesListItemViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// Название dat-файла
        /// </summary>
        public string FileName { get; set; }
        public int lpuid { get; set; }
        public string mcod { get; set; }
        public string name { get; set; }
        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }

        public Dictionary<string, Examination> exams = new Dictionary<string, Examination>();
        #endregion

        #region Public Commands
        public ICommand ReadDataFileCommand { get; set; }
        #endregion

        #region Constructors
        public FilesListItemViewModel()
        {
            ReadDataFileCommand = new RelayCommand(ReadDatFile);
        }

        #endregion

        #region Command Methods
        private void ReadDatFile()
        {
            // IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.MainPage);
            string fullPathToFile = Path.Combine(App.pBase, FileName);
            BinaryFormatter formatter = new BinaryFormatter(); // Объект класса для сериализации/десериализации
            try
            {
                using (FileStream fs = new FileStream(fullPathToFile, FileMode.Open, FileAccess.ReadWrite))
                {
                    try
                    {
                        // Устанавливаем свойство, с которым потом будем работать в методе Load
                        exams = (Dictionary<string, Examination>)formatter.Deserialize(fs);
                        MessageBox.Show(exams.Count.ToString());
                        //exams = examFile.exams;


                    }
                    catch (Exception ex) { }
                    finally { fs.Position = 0; }
                }
            }
            catch (Exception ex) { }
        }
        #endregion
    }
}
