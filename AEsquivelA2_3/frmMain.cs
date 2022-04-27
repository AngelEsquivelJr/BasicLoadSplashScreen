using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AEsquivelA2_3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void bkgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            for(int i = 1; i <= 100; i++)
            {
                Thread.Sleep(50);
                bkgWorker.ReportProgress(i);
            }
        }

        private void bkgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgrBarSplash.Value = e.ProgressPercentage;
            lblProgress.Text = "Progress: " + e.ProgressPercentage.ToString()+ "%";
            if(pgrBarSplash.Value >= 100)
            {
                MessageBox.Show("Your application is open.");
                //for a new form
                //new formName().Show()
                //this.Hide()
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //makes progress bar run
            bkgWorker.WorkerReportsProgress = true;
            bkgWorker.RunWorkerAsync();
        }
    }
}
