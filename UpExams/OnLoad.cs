using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpExams
{
    public static class OnLoad
    {
        public static string Read()
        {
            return ConfigurationManager.AppSettings["qCod"];
        }
    }
}
