using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WHLogin());
        }

        static User _user = new User();

        internal static User User { get => _user; set => _user = value; }

        static User _area = new User();

        internal static User Area { get => _area; set => _area = value; }


        static Modifytype _modifys = new Modifytype();

        internal static Modifytype Modifytype { get => _modifys; set => _modifys = value; }
    }
}
