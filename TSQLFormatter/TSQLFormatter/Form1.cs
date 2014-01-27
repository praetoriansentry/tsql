using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSQLFormatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void formatSqlButton_Click(object sender, EventArgs e)
        {

            // Take from here: http://stackoverflow.com/questions/363377/how-do-i-run-a-simple-bit-of-code-in-a-new-thread

            BackgroundWorker bw = new BackgroundWorker();

            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;

                Formatter f = new Formatter();
                string sqlString = "";
                if (inputSql.InvokeRequired)
                {
                    inputSql.Invoke(new MethodInvoker(delegate { sqlString = inputSql.Text; }));
                }

                args.Result = f.Format(sqlString, b);

            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {
                outputSql.Text = string.Format("{0}% Completed", args.ProgressPercentage);
            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate(object o, RunWorkerCompletedEventArgs args)
            {
                outputSql.Text = args.Result.ToString();
            });
            bw.RunWorkerAsync();
        }

    }
}
