using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UpExams
{
    public class FilesListViewModel : BaseViewModel
    {

        /// <summary>
        /// Путь к базе вида C:\Examinations\Base\I3\202204
        /// </summary>
        private string pBase = App.pBase;
        /// <summary>
        /// Массив FileInfo считанных файлов
        /// </summary>
        private FileInfo[] files;
        public FilesListViewModel()
        {
            files = ReadAllFiles(pBase);
            foreach (FileInfo datfile in files)
            {
                int lpu_id = Int32.Parse(datfile.Name.Substring(4, 4));
                Items.Add(new FilesListItemViewModel { lpuid = lpu_id, mcod = "Unknown", name = "Unknown", IsSelected = false });
            }

        }
        /// <summary>
        /// The file list items for the list
        /// </summary>
        public List<FilesListItemViewModel> Items { get; set; } = new List<FilesListItemViewModel>();
        /// <summary>
        /// Читаем файлы вида meI31840.dat из рабочей директории
        /// </summary>
        /// <param name="pBase">Рабочая директория вида C:\Examinations\Base\I3\202204 </param>
        /// <returns></returns>
        private FileInfo[] ReadAllFiles(string pBase)
        {
            DirectoryInfo dir = new DirectoryInfo(pBase);
            string fileTemplate = "me??????.dat";
            files = dir.GetFiles(fileTemplate).Where<FileInfo>(file => file.Name.Length == fileTemplate.Length).ToArray<FileInfo>();
            return files;
        }
    }
}
