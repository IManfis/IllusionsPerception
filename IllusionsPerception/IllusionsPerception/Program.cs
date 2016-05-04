using System;
using System.Windows.Forms;
using IllusionsPerception.Model;
using IllusionsPerception.Student;
using IllusionsPerception.Teacher;

namespace IllusionsPerception
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new IllusionsPerceptionContext())
            {
                if (!context.Database.Exists())
                {
                    context.User.Add(new User { Name = "admin", Group = 0, Password = "admin" });

                    context.Settings.Add(new Settings { Name = "Предъявлений1", Value = "30" });
                    context.Settings.Add(new Settings { Name = "Предварительная", Value = "6" });
                    context.Settings.Add(new Settings { Name = "Контрольная", Value = "4" });
                    context.Settings.Add(new Settings { Name = "Экспозиция", Value = "200" });
                    context.Settings.Add(new Settings { Name = "Задержка", Value = "500" });
                    context.Settings.Add(new Settings { Name = "Коэфициент", Value = "1,2" });

                    context.SaveChanges();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
