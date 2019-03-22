using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardImageSaver {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();

            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        }

        private void fullname_TextChanged(object sender, EventArgs e) {
            if (Directory.Exists(txtPath.Text)
                && IsValidFileName(txtPrefix.Text)) {
                this.id = 0;
                this.StoringPath = txtPath.Text;
                this.Prefix = txtPrefix.Text;
                this.btnStart.Enabled = true;
                this.btnDistinct.Enabled = true;
                this.btnBrowsePath.Enabled = true;
                this.txtPath.ReadOnly = false;
                this.txtPrefix.ReadOnly = false;
            }
            else {
                this.btnStart.Enabled = false;
                this.btnDistinct.Enabled = false;
                this.btnBrowsePath.Enabled = true;
                this.txtPath.ReadOnly = false;
                this.txtPrefix.ReadOnly = false;
            }
        }

        /// <summary>
        /// 检查文件名是否合法.文字名中不能包含字符\/:*?"<>|
        /// </summary>
        /// <param name="fileName">文件名,不包含路径</param>
        /// <returns></returns>
        private static bool IsValidFileName(string fileName) {
            bool isValid = true;
            string errChar = "\\/:*?\"<>|";  //
            if (string.IsNullOrEmpty(fileName)) {
                isValid = false;
            }
            else {
                for (int i = 0; i < errChar.Length; i++) {
                    if (fileName.Contains(errChar[i].ToString())) {
                        isValid = false;
                        break;
                    }
                }
            }
            return isValid;
        }

        private void btnBrowsePath_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        //
        //定义几个方法
        //
        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        //
        //定义几个方法
        //

        IntPtr nextClipboardViewer;

        //const int WM_DRAWCLIPBOARD = 0x308;
        //const int WM_CHANGECBCHAIN = 0x030D;
        //protected override void WndProc(ref Message m)
        //{
        //    if (nextClipboardViewer == null)
        //        nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        //    switch (m.Msg)
        //    {
        //        case WM_CHANGECBCHAIN:
        //            if (m.WParam == nextClipboardViewer) { nextClipboardViewer = m.LParam; }
        //            else { SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam); }
        //            break;
        //        case WM_DRAWCLIPBOARD:
        //            SaveClipboardImage();
        //            //将WM_DRAWCLIPBOARD 消息传递到下一个观察链中的窗口
        //            SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
        //            //将WM_DRAWCLIPBOARD 消息传递到下一个观察链中的窗口 
        //            break;
        //        default:
        //            base.WndProc(ref m);
        //            break;
        //    }
        //}

        protected override void WndProc(ref Message m) {
            if (isStarted && nextClipboardViewer != null) {
                const int WM_DRAWCLIPBOARD = 0x308;
                const int WM_CHANGECBCHAIN = 0x030D;
                switch (m.Msg) {
                    case WM_CHANGECBCHAIN:
                        //DisplayClipboardData();
                        if (m.WParam == nextClipboardViewer) { nextClipboardViewer = m.LParam; }
                        else { SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam); }
                        break;
                    case WM_DRAWCLIPBOARD:
                        SaveClipboardImage();

                        //将WM_DRAWCLIPBOARD 消息传递到下一个观察链中的窗口
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                        //将WM_DRAWCLIPBOARD 消息传递到下一个观察链中的窗口 

                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
            else {
                base.WndProc(ref m);
            }
        }

        private bool isStarted;
        private int id;

        private void btnStart_Click(object sender, EventArgs e) {
            if (isStarted) {
                this.btnStart.Text = "Start";
                this.isStarted = false;
                this.btnDistinct.Enabled = true;
                this.btnBrowsePath.Enabled = true;
                this.txtPath.ReadOnly = false;
                this.txtPrefix.ReadOnly = false;
                this.btnOpenFolder.Visible = false;
            }
            else {
                this.btnStart.Text = "Stop";
                this.isStarted = true;
                this.btnDistinct.Enabled = false;
                this.btnBrowsePath.Enabled = false;
                this.txtPath.ReadOnly = true;
                this.txtPrefix.ReadOnly = true;
                this.btnOpenFolder.Visible = true;

                this.id = Directory.GetFiles(this.txtPath.Text).Length;
                this.StoringPath = this.txtPath.Text;
                this.Prefix = this.txtPrefix.Text;
            }
        }


        SolidBrush drawBrush = new SolidBrush(Color.Red);
        Font drawFont = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Millimeter);

        private string m_prefix = "bitzhuwei.cnblogs.com";

        public string Prefix { get; set; }

        private bool cancel;
        public string StoringPath { get; set; }

        void SaveClipboardImage() {
            try {
                var data = System.Windows.Forms.Clipboard.GetDataObject();
                this.txtInfo.Text = string.Format("{1}{0}{2}", Environment.NewLine,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    string.Join(Environment.NewLine, data.GetFormats()));
                var bmap = (Image)(data.GetData(typeof(System.Drawing.Bitmap)));
                if (bmap != null) {
                    //var g = Graphics.FromImage(bmap);
                    //var xPos = bmap.Height - (bmap.Height - 25);
                    //var yPos = 3;
                    //g.DrawString("http://bitzhuwei.cnblogs.com", drawFont, drawBrush, xPos, yPos);
                    bmap.Save(
                        Path.Combine(this.StoringPath, string.Format("{0}{1:000000000}.png", this.Prefix, this.id)),
                        System.Drawing.Imaging.ImageFormat.Png);
                    this.id++;
                    bmap.Dispose();
                    //g.Dispose();
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }
        //void SaveClipboardImage()
        //{
        //    var data = System.Windows.Forms.Clipboard.GetDataObject();
        //    var bmap = (Image)(data.GetData(typeof(System.Drawing.Bitmap)));
        //    if (bmap != null)
        //    {
        //        bmap.Save("bitzhuwei.cnblogs.com.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        //        bmap.Dispose();
        //    }
        //}

        private void FormMain_Load(object sender, EventArgs e) {
            try {
                this.txtPath.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                this.txtPrefix.Text = "bitzhuwei.cnblogs.com";
            }
            catch (Exception) {
            }

            this.fullname_TextChanged(sender, e);

        }

        private void btnDistinct_Click(object sender, EventArgs e) {
            //ready = this.btnStart.Enabled;

            this.txtPath.ReadOnly = true;
            this.txtPrefix.ReadOnly = true;
            this.btnBrowsePath.Enabled = false;
            this.btnStart.Enabled = false;
            this.btnDistinct.Enabled = false;
            this.pgbDistinct.Visible = true;
            this.cancel = false;

            backgroundWorker1.RunWorkerAsync(txtPath.Text);

        }

        //private static bool IsSameContent(FileInfo[] files, int i, int j)
        //{
        //    var result = true;
        //    using (FileStream fsi = new FileStream(files[i].FullName, FileMode.Open))
        //    {
        //        using (FileStream fsj = new FileStream(files[j].FullName, FileMode.Open))
        //        {
        //            var counti = 0;
        //            var countj = 0;
        //            do
        //            {
        //                const int length = 100;
        //                var bytesi = new byte[length];
        //                var bytesj = new byte[length];
        //                counti = fsi.Read(bytesi, 0, length);
        //                countj = fsj.Read(bytesj, 0, length);
        //                if (counti != countj)
        //                {
        //                    result = false;
        //                }
        //                else
        //                {
        //                    for (int k = 0; k < counti; k++)
        //                    {
        //                        if (bytesi[k] != bytesj[k])
        //                        {
        //                            result = false;
        //                            break;
        //                        }
        //                    }
        //                }
        //            } while (result && counti > 0 && countj > 0);
        //        }
        //    }
        //    return result;
        //}

        private static bool IsSameContent(FileInfo[] files, int i, int j) {
            var result = true;
            using (FileStream fsi = new FileStream(files[i].FullName, FileMode.Open)) {
                using (FileStream fsj = new FileStream(files[j].FullName, FileMode.Open)) {
                    var counti = 0;
                    var countj = 0;
                    do {
                        const int length = 100;
                        var bytesi = new byte[length];
                        var bytesj = new byte[length];
                        counti = fsi.Read(bytesi, 0, length);
                        countj = fsj.Read(bytesj, 0, length);
                        if (counti != countj) {
                            result = false;
                        }
                        else {
                            for (int k = 0; k < counti; k++) {
                                if (bytesi[k] != bytesj[k]) {
                                    result = false;
                                    break;
                                }
                            }
                        }
                    } while (result && counti > 0 && countj > 0);
                }
            }
            return result;
        }

        //private void DeleteRedundancyFiles(string directory)
        //{
        //    var files = (new DirectoryInfo(directory)).GetFiles("*.jpg");
        //    for (int i = 0; i < files.Length; i++)
        //    {
        //        for (int j = i + 1; j < files.Length; j++)
        //        {
        //            if (File.Exists(files[i].FullName) && File.Exists(files[j].FullName))
        //            {
        //                bool removeJ = IsSameContent(files, i, j);
        //                if (removeJ)
        //                {
        //                    try
        //                    {
        //                        File.Delete(files[j].FullName);
        //                    }
        //                    catch (Exception)
        //                    { }
        //                }
        //            }
        //        }
        //    }
        //}

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    var directory = new DirectoryInfo(e.Argument as string);
        //    var deletedCount = 0;
        //    e.Result = deletedCount;
        //    FileInfo[] files = directory.GetFiles("*.jpg");
        //    e.Result = deletedCount;
        //    for (int i = 0; i < files.Length; i++)
        //    {
        //        for (int j = i + 1; j < files.Length; j++)
        //        {
        //            if (File.Exists(files[i].FullName) && File.Exists(files[j].FullName))
        //            {
        //                bool removeJ = IsSameContent(files, i, j);
        //                if (removeJ)
        //                {
        //                    try
        //                    {
        //                        File.Delete(files[j].FullName);
        //                        deletedCount++;
        //                        e.Result = deletedCount;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        MessageBox.Show("无法删除文件" + files[j].FullName + Environment.NewLine
        //                            + ex.Message, "提示");
        //                    }
        //                }
        //            }
        //            backgroundWorker1.ReportProgress(
        //                (int)(
        //                (pgbDistinct.Maximum - pgbDistinct.Minimum)
        //                * (0.0 + i * files.Length + j)
        //                / (files.Length * files.Length)),
        //                string.Format("Progress: {0} of {1}{2}{3}",
        //                i * files.Length + j, files.Length * files.Length,
        //                Environment.NewLine,
        //                "You can click on the progress bar(the green one) to cancel this distinction operation.")
        //                );
        //            if (this.cancel)
        //            {
        //                e.Cancel = true;
        //                break;
        //            }
        //        }
        //        if (e.Cancel)
        //            break;
        //    }
        //}


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            var directory = new DirectoryInfo(e.Argument as string);
            FileInfo[] files;
            var deletedCount = 0;
            e.Result = deletedCount;
            files = directory.GetFiles();
            var toBeDeleted = new List<int>();
            for (int i = 0; i < files.Length && (!e.Cancel); i++) {
                if (!toBeDeleted.Contains(i)) {
                    using (FileStream fsi = new FileStream(files[i].FullName, FileMode.Open)) {
                        var pos = fsi.Position;
                        for (int j = i + 1; j < files.Length; j++) {
                            bool removeJ = IsSameContent(fsi, files[j]);
                            if (removeJ) {
                                toBeDeleted.Add(j);
                            }
                            if (this.cancel) {
                                e.Cancel = true;
                                break;
                            }
                        }
                    }
                }
                backgroundWorker1.ReportProgress(
                    (int)(
                    (pgbDistinct.Maximum - pgbDistinct.Minimum)
                    * (0.0 + i)
                    / (
                    files.Length)),
                    string.Format("Progress: {0} of {1}{2}{3}",
                    i * files.Length, files.Length * files.Length,
                    Environment.NewLine,
                    "You can click on the progress bar(the green one) to cancel this distinction operation.")
                    );
            }
            if (!e.Cancel) {
                deletedCount = toBeDeleted.Count;
                foreach (var item in toBeDeleted) {
                    try {
                        File.Delete(files[item].FullName);
                    }
                    catch (Exception ex) {
                        MessageBox.Show("无法删除文件" + files[item].FullName + Environment.NewLine
                            + ex.Message, "提示");
                        deletedCount--;
                    }
                }
                e.Result = deletedCount;
            }
            else {
                e.Result = 0;
            }
        }

        private bool IsSameContent(FileStream fsi, FileInfo fileInfo) {
            var result = true;
            using (FileStream fsj = new FileStream(fileInfo.FullName, FileMode.Open)) {
                var counti = 0;
                var countj = 0;
                do {
                    const int length = 100;
                    var bytesi = new byte[length];
                    var bytesj = new byte[length];
                    counti = fsi.Read(bytesi, 0, length);
                    countj = fsj.Read(bytesj, 0, length);
                    if (counti != countj) {
                        result = false;
                    }
                    else {
                        for (int k = 0; k < counti; k++) {
                            if (bytesi[k] != bytesj[k]) {
                                result = false;
                                break;
                            }
                        }
                    }
                } while (result && counti > 0 && countj > 0);
            }
            return result;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            this.pgbDistinct.Value = this.pgbDistinct.Minimum + e.ProgressPercentage;
            this.txtInfo.Text = e.UserState.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                MessageBox.Show(e.Error.ToString(), "Error occured");
            }
            if (e.Cancelled) {
                MessageBox.Show("The distinction operation is cancelled.", "Cancelled");
            }
            MessageBox.Show("为您删掉了" + e.Result + "个内容重复的文件", "提示");

            fullname_TextChanged(sender, e);
            this.pgbDistinct.Visible = false;
            this.cancel = false;
        }

        private void pgbDistinct_Click(object sender, EventArgs e) {
            this.cancel = true;
        }

        private void lblPath_DoubleClick(object sender, EventArgs e) {
            Process.Start("explorer", this.txtPath.Text);
        }

        private void btnOpenFolder_Click(object sender, EventArgs e) {
            Process.Start("explorer", this.txtPath.Text);

        }

        private void notifyIcon1_Click(object sender, EventArgs e) {
            this.Visible = !this.Visible;
        }


    }
}
