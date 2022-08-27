using System;
using System.IO;

namespace DoCards
{
    internal class Program
    {
        static string path = "text.txt";
        static void Main(string[] args)
        {
            Console.Clear();
            bool off = false;
            while (off != true) {
                centerText("------ DoCards {Alpha} ------");
                Console.WriteLine("[1]-Add Card [2]-Delete Card [3]-Change Card [4]-Exit");
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    int f = 1;
                    while ((s = sr.ReadLine()) != null)
                    {                        
                        Console.WriteLine("[{0}]-{1}",f,s);
                        f++;
                    }
                }
                int vyber = Convert.ToInt32(Console.ReadLine());
                switch (vyber) {
                    case 1:
                        Console.WriteLine("Write your To Do Card");
                        Write();
                        break;
                    case 2:
                        Console.WriteLine("Write Card to Delete");
                        int numtask = Convert.ToInt32(Console.ReadLine());
                        DelLine(numtask);
                        File.Delete("text.txt");
                        File.Copy("temp.txt", "text.txt");
                        File.Delete("temp.txt");
                        break;
                    case 3:
                        Console.WriteLine("Number of line you want to change: ");
                        numtask = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write your change version:");
                        string chang = Console.ReadLine();
                        lineChanger(chang,"text.txt",numtask);
                        break;
                    case 4:
                        off = true;
                        break;
                }
                Console.Clear();
            }
        }
        static void Write() 
        {
            string card = Console.ReadLine();
            File.AppendAllText(path, card);
            File.AppendAllText(path,"\n");
        }
        static void DelLine(int line_to_delete) {
            string line = null;
            int line_number = 0;

            using (StreamReader reader = new StreamReader("text.txt")) {
                using (StreamWriter writer = new StreamWriter("temp.txt")) {
                    while ((line = reader.ReadLine()) != null) {
                        line_number++;

                        if (line_number == line_to_delete)
                            continue;

                        writer.WriteLine(line);
                    }
                }
            }
        }
        static void ChangeLine() {
            using (StreamReader sr = File.OpenText(path)){
                sr.ReadLine();
            }
        }
        private static void centerText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
   
    }
}
