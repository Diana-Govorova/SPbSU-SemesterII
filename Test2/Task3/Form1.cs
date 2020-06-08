using System;
using System.Windows.Forms;

namespace Task3
{
    /// <summary>
    /// Progress indicator class
    /// </summary>
    public partial class ProgressIndicatorForm : Form
    {
        /// <summary>
        /// Initialize progress indicator.
        /// </summary>
        public ProgressIndicatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize progress bar.
        /// </summary>
        public void ProgressBarInitialize()
        {
            this.progressBar.Step = 1;
            this.progressBar.Minimum = 1;
            this.progressBar.Maximum = 100;
        }

        /// <summary>
        /// Scale filling
        /// </summary>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (this.progressBar.Value == 100)
            {
                this.Close();
            }
            timer.Interval = 300;
            this.timer.Tick += new EventHandler(this.timer_Tick);
            timer.Start();
        }

        /// <summary>
        /// Increases the scale of filling.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.progressBar.Value == 100)
            {
                this.buttonStart.Text = "Done, click to exit";
                return;
            }
            this.progressBar.PerformStep();
        }
    }
}