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
    public class MainPageViewModel : BaseViewModel
    {
        #region Private members
        #endregion

        #region Public properties
        /// <summary>
        /// View model for Files list control
        /// </summary>
        public FilesListViewModel FilesListVM { get; set; }
        /// <summary>
        /// View model for Exams list control
        /// </summary>
        public ExamsListViewModel ExamsListVM { get; set; }

        public Dictionary<string, Examination> exams = new Dictionary<string, Examination>();
        #endregion

        #region Commands
        public ICommand AttachCommand { get; set; }
        public ICommand ReadDataFileCommand { get; set; }

        #endregion

        public MainPageViewModel()
        {
            FilesListVM = new FilesListViewModel();
            ExamsListVM = new ExamsListViewModel();

            AttachCommand = new RelayCommand(AttachMethod);
            ReadDataFileCommand = new RelayParameterizedCommand((parameter) => ReadDatFile(parameter as string));
        }
        public void AttachMethod()
        {
            MessageBox.Show("OK!");
        }
        private void ReadDatFile(string FileName)
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
                        //ExamsListVM.Items = new List<ExamsListItemViewModel>() { new ExamsListItemViewModel}
                        ExamsListVM.Items = exams.Values.Select(item => new ExamsListItemViewModel { exam = item }).ToList();
                    }
                    catch (Exception ex) { }
                    finally { fs.Position = 0; }
                }
            }
            catch (Exception ex) { }
        }
    }
}
