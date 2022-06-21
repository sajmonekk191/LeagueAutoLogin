using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using LeagueAutoLogin.Essentials;

namespace LeagueAutoLogin
{
    public partial class Form1 : Form
    {
        public static IntPtr handle;
        private string CLIENT_WINDOW_NAME = "Riot Client Main";
        private string LEAGUE_WINDOW_NAME = "League of Legends";
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
            Properties.Settings.Default.Save();
        }
        private void ExecuteLeague()
        {
            Process[] p_Client = Process.GetProcessesByName(CLIENT_WINDOW_NAME);
            Process[] p_League = Process.GetProcessesByName(LEAGUE_WINDOW_NAME);
            string LeaguePath = "C:\\Riot Games\\Riot Client\\RiotClientServices.exe";
            if (p_Client.Length == 0)
            {
                Process.Start(LeaguePath);
                ClientStart:
                try
                {
                    Rectangle rect;
                    handle = Imports.FindWindow(null, CLIENT_WINDOW_NAME);
                    Imports.GetWindowRect(handle, out rect);
                    Point Position = ScreenCapture.PixelSearch(rect, Values.RiotClient_Find);
                    if (Position != new Point(0, 0))
                    {
                        Cursor.Position = new Point(Position.X + 120, Position.Y - 110);
                    }
                    else { goto ClientStart; }
                }
                catch { goto ClientStart; }
                
            }
            else
            {

            }
        }
        private void CheckWhereIsLeague()
        {

        }
    }
}
