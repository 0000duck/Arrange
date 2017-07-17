using System.Threading;
using System.Windows.Forms;
using System.Text;

namespace ConsoleProcess {
    class Program {
        static KeyBoardForm keyBoardForm = new KeyBoardForm();
        static TestForm testForm = new TestForm();

        static void ShowData() {
            while (true) {
                System.Console.ForegroundColor = System.ConsoleColor.Blue;
                System.Console.WriteLine("鼠标位置" + keyBoardForm.Text);
                System.Console.ForegroundColor = System.ConsoleColor.Cyan;
                System.Console.WriteLine("关节位置");

                foreach (var i in testForm.BodiesDataQueue) {
                    foreach (var j in i.JointsMap) {
                        System.Console.WriteLine("关节位置");
                        System.Console.WriteLine(j.ToString());
                    }
                }
                Thread.Sleep(500);
                System.Console.Clear();

            }
        }

        static void OpenTestForm() {
            Application.Run(testForm);
        }

        static void OpenKeyBoard() {
            Application.Run(keyBoardForm);
        }

        static void Main(string[] args) {
            ThreadStart threadStart = new ThreadStart(ShowData);
            Thread thread = new Thread(threadStart);
            thread.Start();
            threadStart = new ThreadStart(OpenKeyBoard);
            Thread b = new Thread(threadStart);
            b.Start();
            threadStart = new ThreadStart(OpenTestForm);
            Thread c = new Thread(threadStart);
            c.Start();
            System.Console.ReadKey();
        }
    }
}
