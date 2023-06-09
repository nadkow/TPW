using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace Data
{
    internal class FileWriter
    {
        private static ConcurrentQueue<orbSet> textToWrite = new ConcurrentQueue<orbSet>();
        Stopwatch stopWatch = new Stopwatch();
        private string? filename;
        //private ManualResetEvent resetEvent = new ManualResetEvent(true);
        private AsyncManualResetEvent resetEvent = new AsyncManualResetEvent(false);
        internal void setEvent()
        {
            resetEvent.Set();
        }
        public FileWriter()
        {
            stopWatch.Start();
        }

        public void EnqueuePos(IOrb orb, double x, double y)
        {
            orbSet entry = new orbSet(orb.GetHashCode(), stopWatch.Elapsed, x, y);
            textToWrite.Enqueue(entry);
            resetEvent.Set();
        }

        private async Task Write()
        {
            while (true)
            {
                using (StreamWriter sw = File.AppendText(filename))
                {
                    while (textToWrite.TryDequeue(out orbSet os))
                    {
                        string id = Convert.ToString(os.id, 16);
                        string line = "<Position orb=\"" + id + "\" time=\"" + os.ts.ToString() + "\" x=\"" + os.x + "\" y=\"" + os.y + "\" />";
                        await sw.WriteLineAsync(line);
                    }
                    sw.Flush();
                }
                await resetEvent.WaitAsync();
                resetEvent.Reset();
            }
            
        }

        public void Start(int tableWidth, int tableHeight, int noOfOrbs)
        {
            createFilename();
            WritePrefix(tableWidth, tableHeight, noOfOrbs);
            Write();
        }


        private void WritePrefix(int tableWidth, int tableHeight, int noOfOrbs)
        {
            StreamWriter sw = File.AppendText(filename);
            string line = "<Table width=\"" + tableWidth + "\" height=\"" + tableHeight + "\" numberOfOrbs=\"" + noOfOrbs + "\" orbDiameter=\"10\" />";
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

        struct orbSet
        {
            public int id;
            public TimeSpan ts;
            public double x, y;

            public orbSet(int id, TimeSpan ts, double x, double y)
            {
                this.id = id;
                this.ts = ts;
                this.x = x;
                this.y = y;
            }
        }

    }
}
