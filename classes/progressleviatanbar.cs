using System;
using System.Windows.Forms;

namespace CPJ_Universal.classes
{
    internal class progressleviatanbar
    {
        private ProgressBar progressBar;
        private Label labelProgress;
        private Label labelSpeed;
        private Label labelDownloaded;

        public progressleviatanbar(ProgressBar progressBar, Label labelProgress, Label labelSpeed, Label labelDownloaded)
        {
            this.progressBar = progressBar;
            this.labelProgress = labelProgress;
            this.labelSpeed = labelSpeed;
            this.labelDownloaded = labelDownloaded;
        }

        public void UpdateProgress(int progressPercentage)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() => progressBar.Value = progressPercentage));
                labelProgress.Invoke(new Action(() => labelProgress.Text = $"Progresso: {progressPercentage}%"));
            }
            else
            {
                progressBar.Value = progressPercentage;
                labelProgress.Text = $"Progresso: {progressPercentage}%";
            }
        }

        public void UpdateSpeed(long bytesPerSecond)
        {
            string speed = $"{bytesPerSecond / 1024} KB/s";
            if (labelSpeed.InvokeRequired)
            {
                labelSpeed.Invoke(new Action(() => labelSpeed.Text = $"Velocidade: {speed}"));
            }
            else
            {
                labelSpeed.Text = $"Velocidade: {speed}";
            }
        }

        public void UpdateDownloaded(long downloadedBytes)
        {
            string downloaded = $"{downloadedBytes / 1024} KB";
            if (labelDownloaded.InvokeRequired)
            {
                labelDownloaded.Invoke(new Action(() => labelDownloaded.Text = $"Baixado: {downloaded}"));
            }
            else
            {
                labelDownloaded.Text = $"Baixado: {downloaded}";
            }
        }
        public void Reset()
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() => progressBar.Value = 0));
                labelProgress.Invoke(new Action(() => labelProgress.Text = "Progresso: 0%"));
                labelSpeed.Invoke(new Action(() => labelSpeed.Text = "Velocidade: 0 KB/s"));
                labelDownloaded.Invoke(new Action(() => labelDownloaded.Text = "Baixado: 0 KB"));
            }
            else
            {
                progressBar.Value = 0;
                labelProgress.Text = "Progresso: 0%";
                labelSpeed.Text = "Velocidade: 0 KB/s";
                labelDownloaded.Text = "Baixado: 0 KB";
            }
        }
    }
}
