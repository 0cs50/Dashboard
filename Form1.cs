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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }


        //IntPtr appWin, appSplunk, appFhs;
        //bool started = false;
        //bool chk = true;
        //bool hideWindow = true;

        //private const int SWP_NOOWNERZORDER = 0x200;
        //private const int SWP_NOREDRAW = 0x8;
        //private const int SWP_NOZORDER = 0x4;
        //private const int SWP_SHOWWINDOW = 0x0040;
        //private const int WS_EX_MDICHILD = 0x40;
        //private const int SWP_FRAMECHANGED = 0x20;
        //private const int SWP_NOACTIVATE = 0x10;
        //private const int SWP_ASYNCWINDOWPOS = 0x4000;
        //private const int SWP_NOMOVE = 0x2;
        //private const int SWP_NOSIZE = 0x1;
        //private const int GWL_STYLE = (-16);
        //private const int WS_VISIBLE = 0x10000000;
        //private const int WM_CLOSE = 0x10;
        //private const int WS_CHILD = 0x40000000;

        //private const int SW_SHOWNORMAL = 1;
        //private const int SW_SHOWMINIMIZED = 2;
        //private const int SW_SHOWMAXIMIZED = 3;

        //[DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        //private static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

        //[DllImport("user32.dll")]
        //static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        //[DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
        //     CharSet = CharSet.Unicode, ExactSpelling = true,
        //     CallingConvention = CallingConvention.StdCall)]
        //private static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //[DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        //private static extern long GetWindowLong(IntPtr hwnd, int nIndex);


        //[DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        //private static extern bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);

        //[DllImport("user32")]
        //private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        //[DllImport("gdi32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //internal static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        //[DllImport("user32.dll")]
        //private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);


        //private void query()
        //{
        //    try
        //    {
        //        db = new SQLiteDatabase();
        //        DataTable data;
        //        String query = "Select ihost_navn from iHosts";

        //        data = db.GetDataTable(query);
        //        foreach (DataRow r in data.Rows)
        //        {
        //            chSubscribable.Items.Add(r[0].ToString());
        //        }


        //    }
        //    catch (Exception fail)
        //    {
        //        failure(fail);
        //    }
        //}


        //private void Selectquery()
        //{
        //    try
        //    {
        //        db = new SQLiteDatabase();
        //        DataTable data;
        //        String query = "Select Name from MyHosts";
        //        data = db.GetDataTable(query);
        //        lselectedHosts.Items.Clear();

        //        foreach (DataRow r in data.Rows)
        //        {
        //            lselectedHosts.Items.Add(r[0].ToString());
        //        }


        //    }
        //    catch (Exception fail)
        //    {
        //        failure(fail);
        //    }
        //}

        //private void Myhosts()
        //{
        //    try
        //    {
        //        db = new SQLiteDatabase();
        //        DataTable data;
        //        String query = "Select host_name from Hosts";
        //        data = db.GetDataTable(query);

        //        foreach (DataRow r in data.Rows)
        //        {
        //            listMyHosts.Items.Add(r[0].ToString());
        //        }
        //    }

        //    catch (Exception fail)
        //    {
        //        failure(fail);
        //    }
        //}

        //private void Services()
        //{
        //    try
        //    {
        //        db = new SQLiteDatabase();
        //        DataTable data;
        //        String query = "Select services from HostService";
        //        data = db.GetDataTable(query);

        //        foreach (DataRow r in data.Rows)
        //        {
        //            listServices.Items.Add(r[0].ToString());
        //        }
        //    }

        //    catch (Exception fail)
        //    {
        //        failure(fail);
        //    }
        //}

        //private void failure(Exception fail)
        //{
        //    String error = "The following error has occurred:\n\n";
        //    error += fail.Message.ToString() + "\n\n";
        //    MessageBox.Show(error);
        //    this.Close();
        //}


        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
                Form1.ActiveForm.Show();
            }

        }

        private void Screencapture()
        {
            string path = @"C:\Users\t112766\Pictures\testpic.bmp";
            saveScreen(path);


            //Graphics mygraphics = wIcinga.CreateGraphics();
            //Size s = new Size(1024, 768);
            //Bitmap memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            //Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            //IntPtr dc1 = mygraphics.GetHdc();
            //IntPtr dc2 = memoryGraphics.GetHdc();
            //// P/Invoke call here
            //BitBlt(dc2, 0, 0, wIcinga.ClientRectangle.Width, wIcinga.ClientRectangle.Height, dc1, 0, 0, 13369376);
            //mygraphics.ReleaseHdc(dc1);
            //memoryGraphics.ReleaseHdc(dc2);
            //memoryImage.Save(@"C:\Users\t112766\Pictures\testpic.bmp");
        }

        //private void saveScreen(string path)
        //{
        //    Size bitmapSize = new Size(1024, 768);

        //    using (Bitmap bitmap = new Bitmap(bitmapSize.Width, bitmapSize.Height, PixelFormat.Format24bppRgb))
        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        graphics.CopyFromScreen(
        //            PointToScreen(webBrowser1.Location),
        //            new Point(0, 0),
        //            bitmapSize);
        //        bitmap.Save(path);
        //    }
        //}




        private void linkLabel1_Click(object sender, EventArgs e)
        {
            LinkLabel lb = (LinkLabel)sender;
            multipageController(lb.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            multipageController("Splunk");
        }

       

        //private void fireSplunk()
        //{

        //    foreach (var process in Process.GetProcessesByName("firefox"))
        //    {
        //        process.Kill();
        //    }

        //    ProcessStartInfo info = new ProcessStartInfo();
        //    info.FileName = @"firefox.exe";
        //    info.Arguments = "search.splunk.telenor.net/";
        //    info.UseShellExecute = true;
        //    info.CreateNoWindow = true;
        //    //info.WindowStyle = ProcessWindowStyle.Maximized;
        //    info.RedirectStandardInput = false;
        //    info.RedirectStandardOutput = false;
        //    info.RedirectStandardError = false;

        //    System.Diagnostics.Process p = System.Diagnostics.Process.Start(info);

        //    //p.WaitForInputIdle();
        //    System.Threading.Thread.Sleep(1000);
        //    appSplunk = p.MainWindowHandle;
        //    Process[] p1;
        //    if (appSplunk == IntPtr.Zero)
        //    {
        //        List<String> arrString = new List<String>();
        //        foreach (Process pp1 in Process.GetProcesses())
        //        {
        //            // Console.WriteLine(p1.MainWindowHandle);
        //            arrString.Add(Convert.ToString(pp1.ProcessName));
        //        }
        //        System.Threading.Thread.Sleep(1000);
        //        p1 = Process.GetProcessesByName("Firefox");
        //        p1[0].WaitForInputIdle();
        //        System.Threading.Thread.Sleep(1000);
        //        appSplunk = p1[0].MainWindowHandle;
        //        SetParent(appSplunk, pSplunk.Handle);
        //        //SetWindowLong(appSplunk, GWL_STYLE, WS_VISIBLE);
        //        MoveWindow(appSplunk, -10, -50, pSplunk.Width + 20, pSplunk.Height + 52, true);
        //        //started = true;
        //        //ResizeEmbeddedApp(); 

        //    }
        //    else
        //    {
        //        SetParent(appSplunk, pSplunk.Handle);
        //        MoveWindow(appSplunk, -10, -30, pSplunk.Width + 20, pSplunk.Height + 32, true);
        //    }
        //    //if (!started)
        //    //{
        //    //    started = true;
        //    //    ////putty();                
        //    //    ////tabControl1.SelectedTab = tabPutty;  
        //    //    //button1_Click(sender, e);
        //    //    //ResizeEmbeddedApp();             
        //    //}
        //}


        //private void xBrowser()
        //{

        //    foreach (var process in Process.GetProcessesByName("ExtendedWebBrowser2"))
        //    {
        //        process.Kill();
        //    }

        //    ProcessStartInfo info = new ProcessStartInfo();
        //    info.FileName = @"ExtendedWebBrowser2.exe";
        //    //info.Arguments = "-load TRA -l [t112766]";            
        //    info.UseShellExecute = true;
        //    info.CreateNoWindow = true;
        //    //info.WindowStyle = ProcessWindowStyle.Maximized;
        //    info.RedirectStandardInput = false;
        //    info.RedirectStandardOutput = false;
        //    info.RedirectStandardError = false;

        //    System.Diagnostics.Process p = System.Diagnostics.Process.Start(info);

        //    //p.WaitForInputIdle();
        //    //System.Threading.Thread.Sleep(3000);
        //    appFhs = p.MainWindowHandle;
        //    Process[] p1;
        //    if (appFhs == IntPtr.Zero)
        //    {
        //        List<String> arrString = new List<String>();
        //        foreach (Process pp1 in Process.GetProcesses())
        //        {
        //            // Console.WriteLine(p1.MainWindowHandle);
        //            arrString.Add(Convert.ToString(pp1.ProcessName));
        //        }
        //        System.Threading.Thread.Sleep(1000);
        //        p1 = Process.GetProcessesByName("ExtendedWebBrowser2");
        //        p1[0].WaitForInputIdle();
        //        System.Threading.Thread.Sleep(1000);
        //        appFhs = p1[0].MainWindowHandle;
        //        SetParent(appFhs, pFhs.Handle);
        //        //SetWindowLong(appFhs, GWL_STYLE, WS_VISIBLE);
        //        MoveWindow(appFhs, -10, -50, pFhs.Width + 20, pFhs.Height + 52, true);
        //        //started = true;
        //        //ResizeEmbeddedApp(); 

        //    }
        //    else
        //    {
        //        SetParent(appFhs, pFhs.Handle);
        //        MoveWindow(appFhs, -10, -30, pFhs.Width + 20, pFhs.Height + 32, true);
        //    }
        //}


        //void multipageController(string lblable)
        //{
        //    tabControl1.SelectedTab = tabWebApp;

        //    TabPage tab = null;
        //    switch (lblable)
        //    {
        //        case "Splunk": tab = tabSplunk; break;
        //        case "Icinga": tab = tabIcinga; break;
        //        case "eDok": tab = tabeDok; break;
        //        case "FHS": tab = tabFHS; break;
        //        case "BAC": tab = tabBac; break;
        //        case "BMO": tab = tabBMO; break;
        //        case "Citrix": tab = tabCitrix; break;
        //        case "Norm KS": tab = tabNormKs; break;
        //        case "NRDB Web": tab = tabNrdbWeb; break;
        //        case "Order Tool": tab = tabOrderTool; break;
        //        case "OTAP Kundeservice": tab = tabOtap; break;
        //        case "SMS Kundedialog": tab = tabSmsKundeDialog; break;
        //        case "Sybase 365": tab = tabSybase; break;
        //        case "Tiara": tab = tabTiara; break;
        //        case "UMS Admin": tab = tabUmsAdmin; break;
        //        case "UMS Kunde Innlogging": tab = tabUmsKundeInnloging; break;
        //        case "Wiki": tab = tabWiki; break;
        //        case "Open Mind": tab = tabOpenMind; break;
        //        default: tab = tabIcinga; break;
        //    }

        //    foreach (Control ww in this.tabControl4.Controls.OfType<TabPage>())//.Where(p => p.Name != w.Name))
        //    {
        //        ww.Visible = ww.Name == tab.Name;
        //        tabControl4.SelectedTab = tab;
        //    }


        //}

        private void webBrowser14_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void activeLabel4_Click(object sender, EventArgs e)
        {
            var process = new Process();
            process.StartInfo.FileName = @"MultiCon.exe";

            if (!started)
            {
                process.Start();
                started = true;


                appWin = IntPtr.Zero;
                while ((appWin = process.MainWindowHandle) == IntPtr.Zero) ;
                SetParent(process.MainWindowHandle, pPutty.Handle);

                MoveWindow(process.MainWindowHandle, -10, -30, pPutty.Width + 20, pPutty.Height + 32, true);

            }

            tabControl1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
                Form1.ActiveForm.Show();
            }

        }

        //private void putty()
        //{
        //    //foreach (var process in Process.GetProcessesByName("MultiCon"))
        //    //{
        //    //    process.Kill();
        //    //}
        //    //foreach (var process in Process.GetProcessesByName("SuperPutty"))
        //    foreach (var process in Process.GetProcessesByName("SuperPutty"))
        //    {
        //        process.Kill();
        //    }

        //    ProcessStartInfo info = new ProcessStartInfo();
        //    info.FileName = @"SuperPutty.exe";
        //    //info.Arguments = "-load TRA -l [t112766]";            
        //    info.UseShellExecute = true;
        //    info.CreateNoWindow = true;
        //    //info.WindowStyle = ProcessWindowStyle.Maximized;
        //    info.RedirectStandardInput = false;
        //    info.RedirectStandardOutput = false;
        //    info.RedirectStandardError = false;
        //    //info.WindowStyle = ProcessWindowStyle.Minimized;//(hideWindow ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal);

        //    System.Diagnostics.Process p = System.Diagnostics.Process.Start(info);

        //    //p.WaitForInputIdle();
        //    System.Threading.Thread.Sleep(3000);
        //    appWin = p.MainWindowHandle;
        //    Process[] p1;
        //    if (appWin == IntPtr.Zero)
        //    {
        //        List<String> arrString = new List<String>();
        //        foreach (Process pp1 in Process.GetProcesses())
        //        {
        //            // Console.WriteLine(p1.MainWindowHandle);
        //            arrString.Add(Convert.ToString(pp1.ProcessName));
        //        }
        //        //System.Threading.Thread.Sleep(1000);
        //        p1 = Process.GetProcessesByName("SuperPutty");
        //        p1[0].WaitForInputIdle();
        //        System.Threading.Thread.Sleep(1000);
        //        appWin = p1[0].MainWindowHandle;
        //        System.Threading.Thread.Sleep(1000);
        //        SetParent(appWin, pPutty.Handle);
        //        System.Threading.Thread.Sleep(1000);
        //        //SetWindowLong(appWin, GWL_STYLE, WS_VISIBLE);
        //        MoveWindow(appWin, -10, -50, pPutty.Width + 20, pPutty.Height + 152, true);
        //        //SetWindowPos(appWin, IntPtr.Zero, -10, -50, (int)pPutty.ClientSize.Width + 20, (int)pPutty.ClientSize.Height + 32, SWP_NOZORDER | SWP_NOACTIVATE);
        //    }
        //    else
        //    {
        //        SetParent(appWin, pPutty.Handle);
        //        MoveWindow(appWin, -10, -30, pPutty.Width + 20, pPutty.Height + 32, true);               
        //    }
        //    //if (!started)
        //    //{
        //    //    started = true;
        //    //    //putty();                
        //    //    //tabControl1.SelectedTab = tabPutty;
        //    //    SetParent(appWin, pPutty.Handle);
        //    //    MoveWindow(appWin, -10, -30, pPutty.Width + 20, pPutty.Height + 32, true); 
        //    //     ResizeEmbeddedApp();             
        //    //}
        //}


        //private void ResizeEmbeddedApp()
        //{
        //    if (appWin == null)
        //        return;
        //    //Process[] p1 = Process.GetProcessesByName("SuperPutty");
        //    //p1[0].StartInfo.WindowStyle = ProcessWindowStyle.Normal;// = (hideWindow ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal);
        //    //p1[0].Refresh();
        //    //ShowWindowAsync(p1[0].Handle, SW_SHOWMAXIMIZED);

        //    SetWindowPos(appWin, IntPtr.Zero, -10, -80, (int)pPutty.ClientSize.Width + 18, (int)pPutty.ClientSize.Height + 90, SWP_NOZORDER | SWP_NOACTIVATE);
        //    //SetWindowPos(appWin, IntPtr.Zero, 0, 0, (int)pPutty.ClientSize.Width, (int)pPutty.ClientSize.Height, SWP_NOZORDER | SWP_NOACTIVATE);
        //}

        private void button2_Click(object sender, EventArgs e)
        {

        }

        //protected override void OnResize(EventArgs e)
        //{

        //    if (appWin != IntPtr.Zero)
        //    {
        //        MoveWindow(appWin, -10, -30, pPutty.Width + 20, pPutty.Height + 32, true);
        //        // System.Threading.Thread.Sleep(1000);
        //        if (chk)
        //        {
        //            chk = false;
        //            //OnSizeChanged(e);
        //            base.OnResize(e);
        //        }
        //    }
        //    base.OnResize(e);
        //    chk = true;
        //}

        //protected override void OnHandleDestroyed(EventArgs e)
        //{
        //    // Stop the application
        //    if (appWin != IntPtr.Zero && appFhs != IntPtr.Zero && appSplunk != IntPtr.Zero)
        //    {
        //        // Post a colse message
        //        //PostMessage(appWin, WM_CLOSE, 0, 0);
        //        //PostMessage(appFhs, WM_CLOSE, 0, 0);
        //        //PostMessage(appSplunk, WM_CLOSE, 0, 0);

        //        // Delay for it to get the message
        //        System.Threading.Thread.Sleep(1000);
        //        // Clear internal handle
        //        appWin = IntPtr.Zero;
        //        appFhs = IntPtr.Zero;
        //        appSplunk = IntPtr.Zero;
        //    }

        //    base.OnHandleDestroyed(e);
        //}

        //private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (panel1.Visible == true)
        //    {
        //        panel1.Visible = false;
        //    }
        //    else
        //    {
        //        panel1.Visible = true;
        //        Form1.ActiveForm.Show();
        //    }
        //}

        private void activeLabel3_Click(object sender, EventArgs e)
        {   string path = @"C:\Program Files\Eureka\31.0.2\";
            string FileName = "Eureka_prod.bat";
            startApp(path,FileName);
        }

        //private static void startApp(string path, string FileName)
        //{
           
        //    Process proc = new Process();
        //    proc.StartInfo.WorkingDirectory = path;
        //    proc.StartInfo.FileName = FileName;
        //    proc.StartInfo.Arguments = string.Format("10");//argument
        //    proc.StartInfo.CreateNoWindow = false;
        //    proc.Start();
        //    proc.WaitForExit();
        //}

        //private void startApp(string appName)
        //{
        //    var process = new Process();
        //    process.StartInfo.FileName = appName;
        //    //process.StartInfo.FileName = "notepad.exe";

        //    process.Start();
        //}

        private void tabPage1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void activeLabel8_Click(object sender, EventArgs e)
        {
            startApp(@"C:\Program Files\KeePass Password Safe 2\KeePass.exe");
        }

        private void winWordControl1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>

        //private static T _download_serialized_json_data<T>(string url) where T : new()
        //{
        //    using (var w = new WebClient())
        //    {
        //        var json_data = string.Empty;
        //        // attempt to download JSON data as a string
        //        try
        //        {
        //            json_data = w.DownloadString(url);
        //            //json_data = status.json;
        //        }
        //        catch (Exception) { }
        //        // if string with JSON data is not empty, deserialize it to class and return its instance 
        //        return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
        //    }
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {

            //var serializer = new JavaScriptSerializer();

            //var myobj = serializer.Deserialize<MyType>(mystring);

            //string json = File.ReadAllText(@"status_cgi.mht");
            //var status = JsonConvert.DeserializeObject<RootObject>(json);
            //var url = "https://monitor.mobil.telenor.no/icinga/cgi-bin/status.cgi?host=all&style=detail&servicestatustypes=2&jsonoutput";
            //var url = "https://monitor.mobil.telenor.no/icinga/cgi-bin/status.cgi?host=all&jsonoutput";
            //var status = _download_serialized_json_data<ServiceStatus>(url);

            //Screencapture();
        }

        //private void myCheckedList()
        //{
        //    List<string> list = new List<string>();
        //    db = new SQLiteDatabase();
        //    DataTable data;
        //    String query = "select Name from MyHosts";
        //    data = db.GetDataTable(query);

        //    foreach (DataRow r in data.Rows)
        //    {
        //        list.Add(r[0].ToString());
        //    }

        //    for (int count = 0; count < chSubscribable.Items.Count; count++)
        //    {
        //        if (list.Contains(chSubscribable.Items[count].ToString()))
        //        {
        //            chSubscribable.SetItemChecked(count, true);
        //        }
        //    }

        //    //chSubscribable.Refresh();
        //}


        /// <summary>
        /// Select a serve, link it up to Icinga and populate its services in the listr boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void chSubscribable_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateIndex(sender);
        }

        //private void populateIndex(object sender)
        //{
        //    ListBox list = (ListBox)sender;


        //    // Get selected index, and then make sure it is valid.
        //    int selected = list.SelectedIndex;
        //    if (selected != -1)
        //    {
        //        string Text = list.Items[selected].ToString();
        //        db = new SQLiteDatabase();
        //        DataTable data;
        //        String query;
        //        string where = "";
        //        where = "hosts = " + "'" + Text + "'";
        //        listServices.Items.Clear();
        //        query = String.Format("Select services from HostService where ({0});", where);
        //        data = db.GetDataTable(query);
        //        foreach (DataRow r in data.Rows)
        //        {
        //            listServices.Items.Add(r[0].ToString());
        //        }
        //        wIcinga.Navigate(@"https://monitor.mobil.telenor.no/icinga/cgi-bin/status.cgi?search_string=" + Text);
        //    }
        //}

        private void activeLabel1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Subscribe/unsubscribe to a server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void chSubscribable_DoubleClick(object sender, EventArgs e)
        {
            suscribeServer();
        }

        //private void suscribeServer()
        //{
        //    int selected = chSubscribable.SelectedIndex;
        //    if (selected != -1)
        //    {
        //        string Text = chSubscribable.Items[selected].ToString();
        //        db = new SQLiteDatabase();
        //        DataTable data;
        //        String query;
        //        string where = "";

        //        if (chSubscribable.CheckedItems.Count != 0)
        //        {
        //            for (int x = 0; x <= lselectedHosts.Items.Count - 1; x++)
        //            {
        //                if (lselectedHosts.Items[x].ToString() == Text)
        //                {
        //                    where = "Name = " + "'" + Text + "'";
        //                    query = String.Format("DELETE FROM MyHosts where ({0});", where);
        //                    data = db.GetDataTable(query);
        //                    chSubscribable.SetItemChecked(selected, false);
        //                    selectQuery();
        //                    return;
        //                }
        //            }
        //        }

        //        where = "ihost_navn = " + "'" + Text + "'";
        //        query = String.Format("INSERT INTO MyHosts Select ihost_id, ihost_navn from iHosts where ({0});", where);
        //        data = db.GetDataTable(query);
        //        chSubscribable.SetItemChecked(selected, true);
        //        selectQuery();
        //    }
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            autoSelect();
        }

        //private void autoSelect()
        //{
        //    string s = textBox1.Text;
        //    for (int x = 0; x <= lselectedHosts.Items.Count - 1; x++)
        //    {

        //        int firstCharacter = lselectedHosts.Items[x].ToString().IndexOf(s);
        //        if (firstCharacter != -1 && s != "")
        //        {
        //            lselectedHosts.SetSelected(x, true);
        //            lselectedHosts.TopIndex = x; //firstCharacter;
        //            break;

        //        }
        //        else
        //            lselectedHosts.SetSelected(0, false);
        //    }

        //    for (int x = 0; x <= listMyHosts.Items.Count - 1; x++)
        //    {

        //        int firstCharacter = listMyHosts.Items[x].ToString().IndexOf(s);
        //        if (firstCharacter != -1 && s != "")
        //        {
        //            listMyHosts.SetSelected(x, true);
        //            listMyHosts.TopIndex = x; //firstCharacter;
        //            break;

        //        }
        //        else
        //            listMyHosts.SetSelected(0, false);
        //    }

        //    for (int x = 0; x <= chSubscribable.Items.Count - 1; x++)
        //    {

        //        int firstCharacter = chSubscribable.Items[x].ToString().IndexOf(s);
        //        if (firstCharacter != -1 && s != "")
        //        {
        //            chSubscribable.SetSelected(x, true);
        //            chSubscribable.TopIndex = x; //firstCharacter;
        //            break;

        //        }
        //        else
        //            chSubscribable.SetSelected(0, false);
        //    }
        //}

        private void btnMainIcinga_Click(object sender, EventArgs e)
        {
            wIcinga.Navigate(@"https://monitor.mobil.telenor.no/icinga");
        }

        private void activeLabel6_Click(object sender, EventArgs e)
        {
            //startApp("firefox.exe");

            //System.Diagnostics.Process.Start("firefox.exe", "http://www.google.com");


            //var process = new Process();
            //process.StartInfo.FileName = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            //if (started)
            //{
            //    process.Start();
            //    //started = true;


            //    appWin = IntPtr.Zero;
            //    while ((appWin = process.MainWindowHandle) == IntPtr.Zero) ;
            //    SetParent(process.MainWindowHandle, pPutty.Handle);

            //    MoveWindow(process.MainWindowHandle, -10, -30, pPutty.Width + 20, pPutty.Height + 32, true);
            //}

            //tabControl1.BringToFront();
        }

        private void pPutty_Resize(object sender, EventArgs e)
        {
            ResizeEmbeddedApp();
        }

        private void tabSplunk_Resize(object sender, EventArgs e)
        {
            //if (appSplunk == null)
            //    return;
            //SetWindowPos(appWin, IntPtr.Zero, -10, -50, (int)pPutty.ClientSize.Width + 20, (int)pPutty.ClientSize.Height + 52, SWP_NOZORDER | SWP_NOACTIVATE);
        }

        private void pSplunk_Resize(object sender, EventArgs e)
        {
            if (appSplunk == null)
                return;
            SetWindowPos(appSplunk, IntPtr.Zero, -10, -50, (int)pSplunk.ClientSize.Width + 20, (int)pSplunk.ClientSize.Height + 52, SWP_NOZORDER | SWP_NOACTIVATE);
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pFhs_Resize(object sender, EventArgs e)
        {
            if (appFhs == null)
                return;
            SetWindowPos(appFhs, IntPtr.Zero, -10, -50, (int)pFhs.ClientSize.Width + 20, (int)pFhs.ClientSize.Height + 52, SWP_NOZORDER | SWP_NOACTIVATE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void tabBac_Click(object sender, EventArgs e)
        {


        }
       

        private void wB(object sender, EventArgs e)
        {

        }

        private void wBac_VisibleChanged(object sender, EventArgs e)
        {
            initializeWebBrowser(sender);

        }

        //private static void initializeWebBrowser(object sender)
        //{
        //    WebBrowser web = (WebBrowser)sender;

        //    string url = "";
        //    if (web.Url != null)
        //    {
        //        url = web.Url.AbsoluteUri;
        //        if (url == "about:blank")
        //        {
        //            switch (web.Name)
        //            {
        //                case "wBac": url = "http://bac.telenor.no/topaz/TopazSiteServlet?createSession=true&userlogin=display&userpassword=display&autologin=yes&requestType=login";
        //                    break;
        //                case "wIcinga": url = "https://monitor.mobil.telenor.no/icinga/";
        //                    break;
        //                case "wBmo": url = "http://bmo.corp.telenor.no:3078/bmo/";
        //                    break;
        //                case "wCitrix": url = "https://citrix.telenor.net/vpn/index.html";
        //                    break;
        //                case "wNrdbWeb": url = "http://atp-nrdb.mobil.telenor.no/";
        //                    break;
        //                case "wEdok": url = "https://edoc360.gi.telenor.com/Global%20desktops/Employee.aspx";
        //                    break;
        //                case "wNormKs": url = "http://normks.telenor.no/normks/logout.do";
        //                    break;
        //                case "wSmsKunde": url = "http://operations.om.telenor.no/mtjenester/dialog/index.asp";
        //                    break;
        //                case "wOrderTool": url = "http://asp-bs01.corp.telenor.no:8101/ordertool_1p0/login.jsp";
        //                    break;
        //                case "wOtapKundesevice": url = "https://p12027.mobilethink.net/telenor_no-customer-care/sendSetting.html?_target0=dummy";
        //                    break;
        //                case "wOpenmind": url = "http://10.122.140.164:8888/provision/index.php";
        //                    break;
        //                case "wSybase": url = "https://365support.sybase.com/portal/ticket.do";
        //                    break;
        //                case "wWiki": url = "http://wiki.mobil.telenor.no/";
        //                    break;
        //                case "wUmsKunde": url = "https://telenormobil.no/adminweb/password/adminpassword.do";
        //                    break;
        //                case "wUmsadmin": url = "https://telenormobil.no/umsadm/menu.do";
        //                    break;
        //                case "wTiara": url = "http://tiara.corp.telenor.no/arsys/shared/login.jsp?/arsys/forms/tiara.corp.telenor.no/";
        //                    break;
        //                default: url = "blank";
        //                    break;
        //            }
        //        }
        //        web.Navigate(url);
        //    }
        //    else return;
        //}

        private void Form1_Shown(object sender, EventArgs e)
        {
            initForm();
        }

        //private void initForm()
        //{
        //    putty();
        //    query();
        //    selectQuery();
        //    myHosts();
        //    myCheckedList();
        //    fireSplunk();
        //    xBrowser();
        //    hideWindow = false;
        //}

        private void Form1_Click(object sender, EventArgs e)
        {
           // Activate();

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
