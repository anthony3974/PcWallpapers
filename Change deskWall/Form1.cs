#pragma warning disable IDE0044 // Add readonly modifier
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Change_deskWall
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        public Form1()
        {
            InitializeComponent();
            InitializeOne();
            InitializeTwo();
            
            System.Timers.Timer timer = new System.Timers.Timer() { AutoReset = false, Enabled = true, Interval = 50 };
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            { // remove doubles
                isRunning = new StreamWriter(@".\isRuningW.txt");
            }
            catch (IOException)
            {
                Visible = false;
                MessageBox.Show("Program already running.", "Change Wall", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit(null, null);
            }
        }

        Form formDelete = new Form();
        Form formImport = new Form();
        Label label1_one;
        string[] files;
        Random rn = new Random();
        int number;
        string mainPath = @"C:\Users\Anthony\OneDrive\Pictures\Wallpapers Master";
        StreamWriter fileDel;
        StreamWriter isRunning;

        #region init
        public void InitializeOne()
        {
            // other form
            formDelete.StartPosition = FormStartPosition.CenterScreen;
            formDelete.FormClosing += new FormClosingEventHandler(ShowOneForDel);
            formDelete.Text = "Delete";

            // button one
            Button button1_one = new Button
            {
                Enabled = true,
                Text = "Delete all",
                Location = new Point(55, 175),
                Size = new Size(90, 40)
            };
            button1_one.FlatAppearance.BorderSize = 0;
            button1_one.Click += new EventHandler(DeletAll);

            formDelete.Controls.Add(button1_one);
            // button two
            Button button2_two = new Button
            {
                Enabled = true,
                Text = "Extract all",
                Size = new Size(90, 40),
                Location = new Point(155, 175)
            };
            button2_two.FlatAppearance.BorderSize = 0;
            button2_two.Click += new EventHandler(Extract);

            formDelete.Controls.Add(button2_two);
            // button set
            Button button3_three = new Button
            {
                Text = "Imp",
                Size = new Size(50, 40),
                Location = new Point(225, 10)
            };
            button3_three.FlatAppearance.BorderSize = 0;
            button3_three.Click += new EventHandler(BtnImp);

            formDelete.Controls.Add(button3_three);
            // label one
            Label label1_one = new Label
            {
                Enabled = true,
                BackColor = Color.MediumPurple,
                Text = " I",
                Font = new Font(Font.FontFamily.Name, 90F),
                Size = new Size(140, 140),
                Location = new Point(80, 25)
            };

            formDelete.Controls.Add(label1_one);
        }
        public void InitializeTwo()
        {
            // other form
            formImport.StartPosition = FormStartPosition.CenterScreen;
            formImport.FormClosing += new FormClosingEventHandler(ShowOneForImp);
            formImport.Text = "Import";

            // button one
            Button button1_one = new Button
            {
                Enabled = true,
                Text = "Import",
                Size = new Size(90, 40),
                Location = new Point(55, 175)
            };
            button1_one.FlatAppearance.BorderSize = 0;
            button1_one.Click += new System.EventHandler(this.import);

            formImport.Controls.Add(button1_one);
            // button two
            Button button2_two = new Button
            {
                Enabled = true,
                Text = "Move"
            };
            button2_two.FlatAppearance.BorderSize = 0;
            button2_two.Size = new Size(90, 40);
            button2_two.Location = new Point(155, 175);
            button2_two.Click += new System.EventHandler(this.move);

            formImport.Controls.Add(button2_two);
            // label one
            label1_one = new Label
            {
                Enabled = true,
                BackColor = Color.MediumAquamarine,
                Text = "E",
                Font = new Font(Font.FontFamily.Name, 90F),
                Size = new Size(140, 140),
                Location = new Point(80, 25)
            };

            formImport.Controls.Add(label1_one);
        }
        #endregion
        #region Cycle
        private void ShowOne()
        {
            formDelete.Hide();
            formImport.Hide();
            Show();
        }
        private void ShowTwo()
        {
            formDelete.Hide();
            formImport.Show();
            Hide();
        }
        private void ShowOneForDel(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ShowOne();
        }
        private void ShowOneForImp(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ShowOne();
        }
        private void BtnImp(object sender, EventArgs e)
        {
            ShowTwo();
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            // check if main path exist
            try { StreamReader sw = new StreamReader(Directory.GetCurrentDirectory() + "\\Path.txt"); mainPath = sw.ReadLine(); sw.Close(); }
            catch (IOException) { Stream r = File.Create(Directory.GetCurrentDirectory() + "\\Path.txt"); r.Close(); }

            // if not then make it
            if (Directory.Exists(mainPath) == false)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog(); // ask for it
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                dialog.ShowDialog(); // show it 
                mainPath = dialog.SelectedPath; // set it
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\Path.txt"); // load to 
                sw.WriteLine(mainPath); // save it
                sw.Close(); // close the file
            }
            // check if other files exist
            if (Directory.Exists(mainPath + "\\Back Up") == false) Directory.CreateDirectory(mainPath + "\\Back Up");
            if (Directory.Exists(mainPath + "\\Delete") == false) Directory.CreateDirectory(mainPath + "\\Delete");
            if (Directory.Exists(mainPath + "\\New") == false) Directory.CreateDirectory(mainPath + "\\New");
            if (Directory.Exists(mainPath + "\\Used") == false) Directory.CreateDirectory(mainPath + "\\Used");
            if (Directory.Exists(mainPath + "\\Wallpapers") == false) Directory.CreateDirectory(mainPath + "\\Wallpapers");

            // load timer checked
            try { string r1; using (StreamReader sw = new StreamReader(Directory.GetCurrentDirectory() + "\\timerOn.txt")) r1 = sw.ReadLine(); changeTimer.Checked = bool.Parse(r1); } catch (FileNotFoundException) { }
            // load txt2
            try { string r2; using (StreamReader sw = new StreamReader(Directory.GetCurrentDirectory() + "\\amtTime.txt")) r2 = sw.ReadLine(); txt2.Text = r2; } catch (FileNotFoundException) { }
            // load intray
            try { string r3; using (StreamReader sw = new StreamReader(Directory.GetCurrentDirectory() + "\\inTray.txt")) r3 = sw.ReadLine(); putInTray.Checked = bool.Parse(r3); } catch (FileNotFoundException) { }
            // set the timer
            if (changeTimer.Checked == true)
            {
                // one hour
                if (txt2.Text.StartsWith("h")) timer.Interval = Convert.ToInt32(txt2.Text.Substring(txt2.Text.LastIndexOf("h") + 1)) * 1000 * 60 * 60;
                // one minute
                else if (txt2.Text.StartsWith("m")) timer.Interval = Convert.ToInt32(txt2.Text.Substring(txt2.Text.LastIndexOf("m") + 1)) * 1000 * 60;
                // one second
                else timer.Interval = Convert.ToInt32(txt2.Text) * 1000;

                timer.Enabled = changeTimer.Checked;
                txt2.Enabled = !changeTimer.Checked;

            }
            
        }
        // Main
        private void Reset()
        {
            label1_one.BackColor = Color.MediumAquamarine;
            // Move all files in a directory    
            string[] files1 = Directory.GetFiles($@"{mainPath}\Used\");
            foreach (string file in files1)
            {
                try
                {
                    File.Move(file, $@"{mainPath}\Wallpapers\{file.Substring(file.LastIndexOf('\\'))}");
                }
                catch (IOException)
                {
                    bool error;
                    do
                    {
                        // try renaming the file
                        try { File.Move(file, $@"{mainPath}\Wallpapers\{rn.Next(1_000, 10_000)} {file.Substring(file.LastIndexOf('\\') + 1)}"); error = false; } catch (IOException) { error = true; }
                    } while (error);
                }
            }

        }
        private void Exit(object sender, EventArgs e) { Visible = false;  Application.Exit(); }
        private void BtnChange_Click(object sender, EventArgs e)
        {
            // get dierectory
            files = System.IO.Directory.GetFiles($@"{mainPath}\Wallpapers");
            // pick file
            number = rn.Next(0, files.Length);
            try
            {
                // move the file
                try
                {
                    File.Move(files[number], $@"{mainPath}\Used\{files[number].Substring(files[number].LastIndexOf('\\'))}");
                }
                catch (IOException)
                {
                    // try renaming the file
                    string newName = $@"{mainPath}\Wallpapers\{rn.Next(1_000, 10_000)} {files[number].Substring(files[number].LastIndexOf('\\') + 1)}"; // set new name
                    try { File.Move(files[number], newName); } // rename the file 
                    catch { MessageBox.Show("fatal error"); }
                    files[number] = newName; // set the current file to the new loctacion
                    File.Move(files[number], $@"{mainPath}\Used\{files[number].Substring(files[number].LastIndexOf('\\'))}"); // moving the file
                }
                // action of setting the paper
                string curr = $@"{mainPath}\Used\{files[number].Substring(files[number].LastIndexOf('\\'))}"; // save the new loction to the temp string
                textBox1.Text = curr; // output to the box
                SystemParametersInfo(0x14, 0, curr, 0x01 | 0x02); // set the paper
            }
            catch (IndexOutOfRangeException)
            {
                Reset();
                BtnChange_Click(null, null);
            }
        }
        private void BtnSet_Click(object sender, EventArgs e)
        {
            formDelete.Show();
            Hide();
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void BtnDelTxt_Click(object sender, EventArgs e)
        {
            if (files != null)
            {
                fileDel = new StreamWriter($@"{mainPath}\Delete list.txt", append: true);
                fileDel.Write($"{files[number]}\n");
                fileDel.Close();
                System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer
                {
                    Interval = 1650,
                    Enabled = true
                };
                tmr.Tick += Tmr_Elapsed;
            }
        }
        private void Tmr_Elapsed(object sender, EventArgs e)
        {
            BtnChange_Click(null, null);
            ((System.Windows.Forms.Timer)(sender)).Stop();
        }
        #region Saving
        private void ChangeTimer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // one hour
                if (txt2.Text.StartsWith("h")) timer.Interval = Convert.ToInt32(txt2.Text.Substring(txt2.Text.LastIndexOf("h") + 1)) * 1000 * 60 * 60;
                // one minute
                else if (txt2.Text.StartsWith("m")) timer.Interval = Convert.ToInt32(txt2.Text.Substring(txt2.Text.LastIndexOf("m") + 1)) * 1000 * 60;
                // one second
                else timer.Interval = Convert.ToInt32(txt2.Text) * 1000;

                timer.Enabled = changeTimer.Checked;
                txt2.Enabled = !changeTimer.Checked;

                // save
                using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\timerOn.txt"))
                    sw.Write(changeTimer.Checked);
            }
            catch (FormatException) { changeTimer.Checked = false; MessageBox.Show("Incorrect Format (m5)", "Format", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Txt2_TextChanged(object sender, EventArgs e)
        {
            // save
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\amtTime.txt"))
                sw.Write(txt2.Text);
        }
        private void PutInTray_CheckedChanged(object sender, EventArgs e)
        {
            // save
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\inTray.txt"))
                sw.Write(putInTray.Checked);
        }
        #endregion
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Visible && putInTray.Checked)
            {
                Hide();
                e.Cancel = true;
            }
        }
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }
        private void DeletAll(object sender, EventArgs e)
        {
            Reset();

            // Delete all files in the directory    
            string[] files = Directory.GetFiles($@"{mainPath}\Delete\");
            foreach (string file in files)
                File.Delete(file);

            // read the file
            StreamReader move = new StreamReader($@"{mainPath}\Delete list.txt");
            // store it
            string fileRead = move.ReadToEnd();
            string[] array = fileRead.Split('\n');
            move.Close();
            
            // delete it
            for (int x = 0; x < array.Length - 1; x++)
                File.Delete(array[x]);

            // delete text
            StreamWriter c = new StreamWriter($@"{mainPath}\Delete list.txt");
            c.Close();
        }
        private void Extract(object sender, EventArgs e)
        {
            Reset();

            // read the file
            StreamReader move = new StreamReader($@"{mainPath}\Delete list.txt");

            // store it
            string fileRead = move.ReadToEnd();
            string[] array = fileRead.Split('\n');
            move.Close();

            // Delete all files in the directory    
            string[] files = Directory.GetFiles($@"{mainPath}\Delete\");
            foreach (string file in files)
                File.Delete(file);

            // copy files
            for (int x = 0; x < array.Length - 1; x++)
            {
                File.Copy(array[x], $@"{mainPath}\Delete\{array[x].Substring(array[x].LastIndexOf('\\'))}");
            }
        }
        private void import(object sender, EventArgs e)
        {
            Reset();
            label1_one.BackColor = Color.Red;
            backgroundWorker.RunWorkerAsync();
        }
        private void move(object sender, EventArgs e)
        {
            label1_one.BackColor = Color.MediumAquamarine;
            // Delete all files in a directory    
            string[] files = Directory.GetFiles($@"{mainPath}\Back Up\");
            foreach (string file in files)
                File.Delete(file);

            // Move all files in a directory    
            string[] files1 = Directory.GetFiles($@"{mainPath}\Wallpapers\");
            foreach (string file in files1)
                File.Move(file, $@"{mainPath}\Back Up\{file.Substring(file.LastIndexOf('\\'))}");

            // copy files
            string[] files2 = Directory.GetFiles($@"{mainPath}\New\");
            foreach (string file in files2)
            {
                //Console.WriteLine(array[x]);
                File.Move(file, $@"{mainPath}\Wallpapers\{file.Substring(file.LastIndexOf('\\'))}");
            }
            MessageBox.Show("done");
        }

        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string[] files = Directory.GetFiles($@"{mainPath}\Wallpapers\");

            for (int a = 0; a < files.Length; a++)
            { //int a = 0;
                try
                {
                    // load main image
                    Image b = Image.FromFile(files[a]);
                    // make a new image
                    Image c = new Bitmap(1920, 1080);
                    // make a Graphics object with the image
                    Graphics GFX = Graphics.FromImage(c);
                    // draw the new image
                    GFX.DrawImage(b, new Rectangle(Point.Empty, new Size(1920, 1080)));
                    // save the new image
                    c.Save($@"{mainPath}\New\{a,0:000}.png");
                    // dispose of unneeded resouses
                    b.Dispose();
                    c.Dispose();
                    GFX.Dispose();
                }
                catch (OutOfMemoryException) { }
            }
            MessageBox.Show("done");
        }
    }
}
#pragma warning restore IDE0044 // Add readonly modifier
