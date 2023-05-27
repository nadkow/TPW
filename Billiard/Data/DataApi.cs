using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataApi : DataAbstractApi
    {
        private static ConcurrentQueue<string> textToWrite = new ConcurrentQueue<string>();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private CancellationToken token;
        private string filename;
        private static Random rnd = new Random();
        public override IOrb CreateOrb(int tableWidth, int tableHeight)
        {
            IOrb orb = new Orb(rnd.Next(5, tableWidth - 5), rnd.Next(5, tableHeight - 5));
            orb.PropertyChanged += EnqueuePos;
            return orb;
        }

        private void EnqueuePos(IOrb orb, double x, double y)
        {
            string id = Convert.ToString(orb.GetHashCode(), 16);
            string entry = "<Position orb=\"" + id + "\" x=\"" + x + "\" y=\"" + y + "\" >";
            textToWrite.Enqueue(entry);
        }

        public override void Start(int tableWidth, int tableHeight)
        {
            createFilename();
            WritePrefix(tableWidth, tableHeight);
            Write();
        }

        private async Task Write()
        {
            token = tokenSource.Token;
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    return; // TODO tu bedzie zakonczenie struktury dokumentu xml
                }
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

        private void WritePrefix(int tableWidth, int tableHeight)
        {

        }

        private void createFilename()
        {
            DateTime dt = DateTime.Now;
            filename = dt.ToString("yyyyMMddhhmmss");
            filename += ".txt";
        }

    }
}
