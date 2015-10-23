using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Kerido.Controls;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net;
using Newtonsoft.Json;
using System.IO;


namespace Dashboard
{
   
    public partial class Form1 
    {
        public class ServiceStatus
        {
            public string host_name { get; set; }
            public string host_display_name { get; set; }
            public string service_description { get; set; }
            public string service_display_name { get; set; }
            public string status { get; set; }
            public string last_check { get; set; }
            public string duration { get; set; }
            public string attempts { get; set; }
            public string state_type { get; set; }
            public bool is_flapping { get; set; }
            public bool in_scheduled_downtime { get; set; }
            public bool active_checks_enabled { get; set; }
            public bool passive_checks_enabled { get; set; }
            public bool notifications_enabled { get; set; }
            public bool has_been_acknowledged { get; set; }
            public string action_url { get; set; }
            public object notes_url { get; set; }
            public string status_information { get; set; }
        }

        public class Status
        {
            public List<ServiceStatus> service_status { get; set; }
        }

        public class RootObject
        {
            public string cgi_json_version { get; set; }
            public Status status { get; set; }
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnSizeChanged(e);
        }

        private Process GetaProcess(string processname)
        {
            Process[] aProc = Process.GetProcessesByName(processname);

            if (aProc.Length > 0)
                return aProc[0];

            else return null;
        }

        private void appStarted(Process process)
        {
            if (!started)
            {
                process.Start();
                started = true;


                appWin = IntPtr.Zero;
                while ((appWin = process.MainWindowHandle) == IntPtr.Zero) ;
                SetParent(process.MainWindowHandle, pPutty.Handle);

                MoveWindow(process.MainWindowHandle, -10, -30, pPutty.Width + 20, pPutty.Height + 32, true);

            }
        }

        private void ResizeEmbeddedApp()
        {
            if (appWin == null)
                return;

            SetWindowPos(appWin, IntPtr.Zero, -10, -80, (int)pPutty.Width + 18, (int)pPutty.ClientSize.Height + 90, SWP_NOZORDER | SWP_NOACTIVATE);
        }

        void multipageController(string lblable)
        {            
            tabControl1.SelectedTab = tabWebApp;

            TabPage tab = null;
            switch (lblable)
            {
                case "Splunk": tab = tabSplunk; break;
                case "Icinga": tab = tabIcinga; break;
                case "eDok": tab = tabeDok; break;
                case "FHS": tab = tabFHS; break;
                case "BAC": tab = tabBac; break;
                case "BMO": tab = tabBMO; break;
                case "Citrix": tab = tabCitrix; break;
                case "Norm KS": tab = tabNormKs; break;
                case "NRDB Web": tab = tabNrdbWeb; break;
                case "Order Tool": tab = tabOrderTool; break;
                case "OTAP Kundeservice": tab = tabOtap; break;
                case "SMS Kundedialog": tab = tabSmsKundeDialog; break;
                case "Sybase 365": tab = tabSybase; break;
                case "Tiara": tab = tabTiara; break;
                case "UMS Admin": tab = tabUmsAdmin; break;
                case "UMS Kunde Innlogging": tab = tabUmsKundeInnloging; break;
                case "Wiki": tab = tabWiki; break;
                case "Open Mind": tab = tabOpenMind; break;
                default: tab = tabIcinga; break;
            }

            //Fill the contents and display the tab
            foreach (Control ww in this.tabControl4.Controls.OfType<TabPage>())
            {
                ww.Visible = ww.Name == tab.Name;
                tabControl4.SelectedTab = tab;
            }


        }

        private void putty()
        {
            //Make sure only one instance of SuperPutter is running
            foreach (var process in Process.GetProcessesByName("SuperPutty"))
            {
                process.Kill();
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"SuperPutty.exe";
            //info.Arguments = "-load TRA -l [t112766]";            
            info.UseShellExecute = true;
            info.CreateNoWindow = true;
            //info.WindowStyle = ProcessWindowStyle.Maximized;
            info.RedirectStandardInput = false;
            info.RedirectStandardOutput = false;
            info.RedirectStandardError = false;
            //info.WindowStyle = ProcessWindowStyle.Minimized;//(hideWindow ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal);

            System.Diagnostics.Process p = System.Diagnostics.Process.Start(info);

            //p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);
            appWin = p.MainWindowHandle;
            Process[] p1;
            if (appWin == IntPtr.Zero)
            {
                List<String> arrString = new List<String>();
                foreach (Process pp1 in Process.GetProcesses())
                {
                    // Console.WriteLine(p1.MainWindowHandle);
                    arrString.Add(Convert.ToString(pp1.ProcessName));
                }
                //System.Threading.Thread.Sleep(1000);
                p1 = Process.GetProcessesByName("SuperPutty");
                p1[0].WaitForInputIdle();
                System.Threading.Thread.Sleep(1000);
                appWin = p1[0].MainWindowHandle;
                System.Threading.Thread.Sleep(1000);
                SetParent(appWin, pPutty.Handle);
                System.Threading.Thread.Sleep(1000);
                //SetWindowLong(appWin, GWL_STYLE, WS_VISIBLE);
                MoveWindow(appWin, -10, -50, pPutty.Width + 20, pPutty.Height + 152, true);
                //SetWindowPos(appWin, IntPtr.Zero, -10, -50, (int)pPutty.ClientSize.Width + 20, (int)pPutty.ClientSize.Height + 32, SWP_NOZORDER | SWP_NOACTIVATE);
            }
            else
            {
                SetParent(appWin, pPutty.Handle);
                MoveWindow(appWin, -10, -30, pPutty.Width + 20, pPutty.Height + 32, true);
            }            
        }

        private static void initializeWebBrowser(object sender)
        {
            WebBrowser web = (WebBrowser)sender;

            string url = "";
            if (web.Url != null)
            {
                url = web.Url.AbsoluteUri;
                if (url == "about:blank")
                {
                    switch (web.Name)
                    {
                        case "wBac": url = "http://bac.telenor.no/topaz/TopazSiteServlet?createSession=true&userlogin=display&userpassword=display&autologin=yes&requestType=login";
                            break;
                        case "wIcinga": url = "https://monitor.mobil.telenor.no/icinga/";
                            break;
                        case "wBmo": url = "http://bmo.corp.telenor.no:3078/bmo/";
                            break;
                        case "wCitrix": url = "https://citrix.telenor.net/vpn/index.html";
                            break;
                        case "wNrdbWeb": url = "http://atp-nrdb.mobil.telenor.no/";
                            break;
                        case "wEdok": url = "https://edoc360.gi.telenor.com/Global%20desktops/Employee.aspx";
                            break;
                        case "wNormKs": url = "http://normks.telenor.no/normks/logout.do";
                            break;
                        case "wSmsKunde": url = "http://operations.om.telenor.no/mtjenester/dialog/index.asp";
                            break;
                        case "wOrderTool": url = "http://asp-bs01.corp.telenor.no:8101/ordertool_1p0/login.jsp";
                            break;
                        case "wOtapKundesevice": url = "https://p12027.mobilethink.net/telenor_no-customer-care/sendSetting.html?_target0=dummy";
                            break;
                        case "wOpenmind": url = "http://10.122.140.164:8888/provision/index.php";
                            break;
                        case "wSybase": url = "https://365support.sybase.com/portal/ticket.do";
                            break;
                        case "wWiki": url = "http://wiki.mobil.telenor.no/";
                            break;
                        case "wUmsKunde": url = "https://telenormobil.no/adminweb/password/adminpassword.do";
                            break;
                        case "wUmsadmin": url = "https://telenormobil.no/umsadm/menu.do";
                            break;
                        case "wTiara": url = "http://tiara.corp.telenor.no/arsys/shared/login.jsp?/arsys/forms/tiara.corp.telenor.no/";
                            break;
                        default: url = "blank";
                            break;
                    }
                }
                web.Navigate(url);
            }
            else return;
        }

        //Start Splunk in firefox
        private void fireSplunk()
        {

            foreach (var process in Process.GetProcessesByName("firefox"))
            {
                process.Kill();
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"firefox.exe";
            info.Arguments = "search.splunk.telenor.net/";
            info.UseShellExecute = true;
            info.CreateNoWindow = true;
            //info.WindowStyle = ProcessWindowStyle.Maximized;
            info.RedirectStandardInput = false;
            info.RedirectStandardOutput = false;
            info.RedirectStandardError = false;

            System.Diagnostics.Process p = System.Diagnostics.Process.Start(info);

            //p.WaitForInputIdle();
            System.Threading.Thread.Sleep(1000);
            appSplunk = p.MainWindowHandle;
            Process[] p1;
            if (appSplunk == IntPtr.Zero)
            {
                List<String> arrString = new List<String>();
                foreach (Process pp1 in Process.GetProcesses())
                {
                    // Console.WriteLine(p1.MainWindowHandle);
                    arrString.Add(Convert.ToString(pp1.ProcessName));
                }
                System.Threading.Thread.Sleep(1000);
                p1 = Process.GetProcessesByName("Firefox");
                p1[0].WaitForInputIdle();
                System.Threading.Thread.Sleep(1000);
                appSplunk = p1[0].MainWindowHandle;
                SetParent(appSplunk, pSplunk.Handle);
                //SetWindowLong(appSplunk, GWL_STYLE, WS_VISIBLE);
                MoveWindow(appSplunk, -10, -50, pSplunk.Width + 20, pSplunk.Height + 52, true);
                //started = true;
                //ResizeEmbeddedApp(); 

            }
            else
            {
                SetParent(appSplunk, pSplunk.Handle);
                MoveWindow(appSplunk, -10, -30, pSplunk.Width + 20, pSplunk.Height + 32, true);
            }
            
        }
               

        private void xBrowser()
        {

            foreach (var process in Process.GetProcessesByName("ExtendedWebBrowser2"))
            {
                process.Kill();
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"ExtendedWebBrowser2.exe";
            //info.Arguments = "-load TRA -l [t112766]";            
            info.UseShellExecute = true;
            info.CreateNoWindow = true;
            //info.WindowStyle = ProcessWindowStyle.Maximized;
            info.RedirectStandardInput = false;
            info.RedirectStandardOutput = false;
            info.RedirectStandardError = false;

            System.Diagnostics.Process p = System.Diagnostics.Process.Start(info);

            //p.WaitForInputIdle();
            //System.Threading.Thread.Sleep(3000);
            appFhs = p.MainWindowHandle;
            Process[] p1;
            if (appFhs == IntPtr.Zero)
            {
                List<String> arrString = new List<String>();
                foreach (Process pp1 in Process.GetProcesses())
                {
                    // Console.WriteLine(p1.MainWindowHandle);
                    arrString.Add(Convert.ToString(pp1.ProcessName));
                }
                System.Threading.Thread.Sleep(1000);
                p1 = Process.GetProcessesByName("ExtendedWebBrowser2");
                p1[0].WaitForInputIdle();
                System.Threading.Thread.Sleep(1000);
                appFhs = p1[0].MainWindowHandle;
                SetParent(appFhs, pFhs.Handle);
                //SetWindowLong(appFhs, GWL_STYLE, WS_VISIBLE);
                MoveWindow(appFhs, -10, -50, pFhs.Width + 20, pFhs.Height + 52, true);
                //started = true;
                //ResizeEmbeddedApp(); 

            }
            else
            {
                SetParent(appFhs, pFhs.Handle);
                MoveWindow(appFhs, -10, -30, pFhs.Width + 20, pFhs.Height + 32, true);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            // Stop the application
            if (appWin != IntPtr.Zero && appFhs != IntPtr.Zero && appSplunk != IntPtr.Zero)
            {
                // Post a close message
                //PostMessage(appWin, WM_CLOSE, 0, 0);
                //PostMessage(appFhs, WM_CLOSE, 0, 0);
                //PostMessage(appSplunk, WM_CLOSE, 0, 0);

                // Delay for it to get the message
                System.Threading.Thread.Sleep(1000);
                // Clear internal handle
                appWin = IntPtr.Zero;
                appFhs = IntPtr.Zero;
                appSplunk = IntPtr.Zero;
            }

            base.OnHandleDestroyed(e);
        }

        

        //Resize views to fit the parent window
        protected override void OnResize(EventArgs e)
        {

            if (appWin != IntPtr.Zero)
            {
                MoveWindow(appWin, -10, -30, pPutty.Width + 20, pPutty.Height + 32, true);
                // System.Threading.Thread.Sleep(1000);
                if (chk)
                {
                    chk = false;
                    //OnSizeChanged(e);
                    base.OnResize(e);
                }
            }
            base.OnResize(e);
            chk = true;
        }

        private void startApp(string appName)
        {
            var process = new Process();
            process.StartInfo.FileName = appName;
            //process.StartInfo.FileName = "notepad.exe";

            process.Start();
        }


        private static void startApp(string path, string FileName)
        {
            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = path;
            proc.StartInfo.FileName = FileName;
            proc.StartInfo.Arguments = string.Format("10");
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();
        }

        //Intialise the view for the first time and start Putty
        private void initForm()
        {
            putty();
            query();
            selectQuery();
            myHosts();
            myCheckedList();
            fireSplunk();
            xBrowser();
            hideWindow = false;
        }
        //Auto select server in the listboxes
        private void autoSelect()
        {
            string s = textBox1.Text;
            List<ListBox> list = new List<ListBox>();
            list.Add(lselectedHosts);
            list.Add(listMyHosts);
            list.Add(chSubscribable);

            foreach (ListBox li in list)            
                autoSearch(li, s);
            
        }

        private void autoSearch(ListBox l, string s)
        {
            for (int x = 0; x <= l.Items.Count - 1; x++)
            {

                int firstCharacter = l.Items[x].ToString().IndexOf(s);
                if (firstCharacter != -1 && s != "")
                {
                    l.SetSelected(x, true);
                    l.TopIndex = x; //firstCharacter;
                    break;

                }
                else
                    l.SetSelected(0, false);
            }
        }

        //Capture the screen and save it
        private void saveScreen(string path)
        {
            Size bitmapSize = new Size(1024, 768);

            using (Bitmap bitmap = new Bitmap(bitmapSize.Width, bitmapSize.Height, PixelFormat.Format24bppRgb))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(
                    PointToScreen(webBrowser1.Location),
                    new Point(0, 0),
                    bitmapSize);
                bitmap.Save(path);
            }
        }
    }
}
