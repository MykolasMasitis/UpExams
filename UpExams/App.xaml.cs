using foundation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UpExams
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region Public Properties
        /// <summary>
        /// Код СМО (I3 - Ингосстрах, S7 - СОГАЗ-Мед)
        /// </summary>
        internal static string qCod;
        internal static string qName;
        internal static string qMail;
        internal static string pBase = ConfigurationManager.AppSettings["pBase"];
        internal static string pNsi = ConfigurationManager.AppSettings["pNsi"];
        internal static string pCommon = ConfigurationManager.AppSettings["pCommon"];
        /// <summary>
        /// Обрабатываемый период в формате yyyymm, например 202201 - Январь 2022
        /// </summary>
        internal static string gcPeriod;
        /// <summary>
        /// Экземпляр класса аутентификации
        /// </summary>
        internal static AuthInfo authInfo = new AuthInfo();
        #endregion

        /// <summary>
        /// Custom startup so we need to load our IoC Container
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let the base application do what it needs
            base.OnStartup(e);

            // Setup IoC
            IoC.Setup();


            // Настройка и загрузка конфигурации
            qCod = ConfigurationManager.AppSettings["qCod"];
            gcPeriod = ConfigurationManager.AppSettings["period"];
            LoadConfiguration(qCod);

            #region Создаем директорию периода, теперь pBase=pBase+gcPeriod
            //string pBase = null;
            DirectoryInfo dir = null;
            {
                pBase = Path.Combine(pBase, qCod, gcPeriod);
                pNsi = Path.Combine(pBase, "NSI");
                dir = new DirectoryInfo(pBase);
                if (!dir.Exists)
                    dir.Create();
                dir = new DirectoryInfo(pNsi);
                if (!dir.Exists)
                    dir.Create();

            }
            #endregion

            // Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();

        }
        /// <summary>
        /// Загрузка конфигурации из кастомных секций (описаны в CustomSections) файла конфигурации App.config
        /// </summary>
        private void LoadConfiguration(string qCod)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Console.WriteLine($"Конфигурационный файл: {cfg.FilePath}");

            //Читаем секцию Congig конфигурационного файл. То,что читаем, пишем в Private members
            SmoSection.CustomSection section = cfg.GetSection("Config") as SmoSection.CustomSection;
            if (section == null)
            {
                //ConsoleColor ordinaryColor = Console.ForegroundColor;
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine($"Не задана конфиругация {qCod} в файле {cfg.FilePath}.");
                //Console.WriteLine("Продолжение работы невозможно!");
                //Console.ForegroundColor = ordinaryColor;
                //Console.ReadLine();
                return;
            }
            SmoSection.Company smoConfig = section.companies[qCod];
            qName = smoConfig.qName;
            qMail = smoConfig.qMail;
            pBase = smoConfig.Nested.pBase;
            pNsi = smoConfig.Nested.pNsi;

            if (pNsi == null)
            {
                //ConsoleColor ordinaryColor = Console.ForegroundColor;
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine($"Значение переменной {pNsi} не определено. Видимо, поврежден конфигурационный файл.");
                //Console.WriteLine("Продолжение работы невозможно!");
                //Console.ForegroundColor = ordinaryColor;
                //Console.ReadLine();
                return;
            }
            else
            {
                if (!Directory.Exists(pNsi))
                {
                    //ConsoleColor ordinaryColor = Console.ForegroundColor;
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine($"Отсутствует или не доступна директория {pNsi}!");
                    //Console.WriteLine("Продолжение работы невозможно!");
                    //Console.ForegroundColor = ordinaryColor;
                    //Console.ReadLine();
                    return;
                }
            }

            // Читаем секцию Soap конфигурацию
            AuthSection.CustomSection auth = cfg.GetSection("Soap") as AuthSection.CustomSection;
            if (auth == null)
            {
                //ConsoleColor ordinaryColor = Console.ForegroundColor;
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine($"Не задана конфигурация auth {qCod} в файле {cfg.FilePath}.");
                //Console.WriteLine("Продолжение работы невозможно!");
                //Console.ForegroundColor = ordinaryColor;
                //Console.ReadLine();
                return;
            }
            AuthSection.Company authConfig = auth.companies[qCod];
            string orgId = authConfig.Nested.orgId;
            string system = authConfig.Nested.system;
            string user = authConfig.Nested.login;
            string password = authConfig.Nested.password;

            authInfo.orgId = orgId;
            authInfo.system = system;
            authInfo.user = user;
            authInfo.password = password;

        }
    }
}
