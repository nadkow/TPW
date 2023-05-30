using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataApi : DataAbstractApi
    {
        private static ConcurrentQueue<string> textToWrite = new ConcurrentQueue<string>();
        Stopwatch stopWatch = new Stopwatch();
        private string filename;
        private static Random rnd = new Random();

        public DataApi()
        {
            stopWatch.Start();
        }
        public override IOrb CreateOrb(int tableWidth, int tableHeight)
        {
            IOrb orb = new Orb(rnd.Next(5, tableWidth - 5), rnd.Next(5, tableHeight - 5));
            orb.PropertyChanged += EnqueuePos;
            return orb;
        }

        private void EnqueuePos(IOrb orb, double x, double y)
        {
            TimeSpan ts = stopWatch.Elapsed;
            string time = ts.ToString();
            string id = Convert.ToString(orb.GetHashCode(), 16);
            string entry = "<Position orb=\"" + id + "\" time=\""+time+"\" x=\"" + x + "\" y=\"" + y + "\" />";
            textToWrite.Enqueue(entry);
        }

        public override void Start(int tableWidth, int tableHeight, int noOfOrbs)
        {
            createFilename();
            WritePrefix(tableWidth, tableHeight, noOfOrbs);
            Write();
        }

        private async Task Write()
        {
            while (true)
            {
                using (StreamWriter sw = File.AppendText(filename))
                {
                    while (textToWrite.TryDequeue(out string line))
                    {
                        await sw.WriteLineAsync(line);
                    }
                    sw.Flush();
                    await Task.Delay(100);
                }
            }
        }

        private void WritePrefix(int tableWidth, int tableHeight, int noOfOrbs)
        {
            StreamWriter sw = File.AppendText(filename);
            string line = "<Table width=\""+tableWidth+"\" height=\""+tableHeight+"\" numberOfOrbs=\""+noOfOrbs+"\" orbDiameter=\"10\" />";
            sw.WriteLineAsync(line);
            sw.Flush();
            sw.Close();
        }

        private void createFilename()
        {
            DateTime dt = DateTime.Now;
            filename = dt.ToString("yyyyMMddhhmmss");
            filename += ".txt";
        }

    }
}
