using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using LeagueAutoLogin.Essentials;

namespace LeagueAutoLogin
{
    public partial class Form1 : Form
    {
        private Point Position;
        private IntPtr handle;
        const int MOUSEEVENTF_LEFTDOWN = 0x02;
        const int MOUSEEVENTF_LEFTUP = 0x04;
        uint X = (uint)Cursor.Position.X;
        uint Y = (uint)Cursor.Position.Y;
        private string CLIENT_WINDOW_NAME = "Riot Client Main";
        public Form1()
        {
            InitializeComponent();
        }

        private void autologinBTN_Click(object sender, EventArgs e)
        {
            Values.username = userTB.Text;
            Values.password = passTB.Text;
            ExecuteLeague();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            passTB.UseSystemPasswordChar = true;
            try
            {
                userTB.Text = Properties.Settings.Default.Username;
                passTB.Text = Properties.Settings.Default.Password;
                executeCB.Checked = Properties.Settings.Default.AutoExecute;
                savelogCB.Checked = Properties.Settings.Default.SaveData;
                Values.LeaguePath = Properties.Settings.Default.Path;
            }
            catch { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (executeCB.Checked == true)
            {
                Values.autologin_execute = true;
                Properties.Settings.Default.AutoExecute = Values.autologin_execute;
            }
            else
            {
                Values.autologin_execute = false;
                Properties.Settings.Default.AutoExecute = Values.autologin_execute;
            }
            if (savelogCB.Checked == true)
            {
                Values.autologin_data = true;
                Properties.Settings.Default.Username = Values.username;
                Properties.Settings.Default.Password = Values.password;
                Properties.Settings.Default.SaveData = Values.autologin_data;
            }
            else
            {
                Values.autologin_data = false;
                Properties.Settings.Default.SaveData = Values.autologin_data;
            }
            Properties.Settings.Default.Path = Values.LeaguePath;
            Properties.Settings.Default.Save();
        }
        private void ExecuteLeague()
        {
            Process[] p_Client = Process.GetProcessesByName(CLIENT_WINDOW_NAME);
            if (p_Client.Length == 0)
            {
                Process.Start(Values.LeaguePath);
            }

            try
            {
                FindPatern:
                handle = Imports.FindWindow(null, CLIENT_WINDOW_NAME);
                Imports.SetForegroundWindow(handle);
                SelectWhere("Login");
                SelectWhere("MyGames");
                SelectWhere("Play");
                if (Values.playSucc) return;
                goto FindPatern;
            }
            catch { };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "RiotClientServices.exe|*.exe";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Values.LeaguePath = openFileDialog1.FileName;
                }
            }
        }
        private Point FindLocation(Color col)
        {
            Rectangle rect;
            Imports.GetWindowRect(handle, out rect);
            rect = new Rectangle(rect.X, rect.Y, rect.Width - rect.X, rect.Height - rect.Y);
            Position = ScreenCapture.PixelSearch(rect, col);
            if(Position != new Point(0, 0))
            {
                return new Point(Position.X, Position.Y);
            }
            return new Point(0, 0);
        }
        private bool SelectWhere(string pos)
        {
            switch(pos)
            {
                case "Login":
                    Position = FindLocation(Values.RiotClient_Find);
                    if (Position != new Point(0, 0))
                    {
                        Cursor.Position = new Point(Position.X + 120, Position.Y - 110);
                        Thread.Sleep(20);
                        Imports.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                        SendKeys.Send(Values.username);
                        Cursor.Position = new Point(Position.X + 120, Position.Y - 50);
                        Thread.Sleep(20);
                        Imports.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                        SendKeys.Send(Values.password);
                        Thread.Sleep(20);
                        Cursor.Position = new Point(Position.X + 140, Position.Y + 330);
                        Imports.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                        Values.loginSucc = true;
                        return true;
                    }
                    break;

                case "MyGames":
                    Position = FindLocation(Values.RiotClient_MyGames);
                    if (Position != new Point(0, 0))
                    {
                        Cursor.Position = new Point(Position.X, Position.Y);
                        Thread.Sleep(20);
                        Imports.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                        Values.mygamesSucc = true;
                        return true;
                    }
                    break;
                case "Play":
                    Position = FindLocation(Values.RiotClient_Play);
                    if (Position != new Point(0, 0))
                    {
                        Cursor.Position = new Point(Position.X, Position.Y);
                        Thread.Sleep(20);
                        Imports.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                        Values.playSucc = true;
                        SelectWhere("Reset");
                        return true;
                    }
                    break;
                case "Reset":
                    if (Values.playSucc)
                    {
                        Values.loginSucc = false;
                        Values.mygamesSucc = false;
                        Values.playSucc = false;
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}
