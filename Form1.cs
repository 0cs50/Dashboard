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

        }


        private void linkLabel1_Click(object sender, EventArgs e)
        {
            LinkLabel lb = (LinkLabel)sender;
            multipageController(lb.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            multipageController("Splunk");
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
       
        private void activeLabel3_Click(object sender, EventArgs e)
        {   string path = @"C:\Program Files\Eureka\31.0.2\";
            string FileName = "Eureka_prod.bat";
            startApp(path,FileName);
        }      
       
        private void activeLabel8_Click(object sender, EventArgs e)
        {
            startApp(@"C:\Program Files\KeePass Password Safe 2\KeePass.exe");
        }       

        /// <summary>
        /// Select a serve, link it up to Icinga and populate its services in the listr boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void chSubscribable_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateIndex(sender);
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
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            autoSelect();
        }
     
        private void btnMainIcinga_Click(object sender, EventArgs e)
        {
            wIcinga.Navigate(@"https://monitor.mobil.telenor.no/icinga");
        }
     
        private void pPutty_Resize(object sender, EventArgs e)
        {
            ResizeEmbeddedApp();
        }
     
        private void pSplunk_Resize(object sender, EventArgs e)
        {
            if (appSplunk == null)
                return;
            SetWindowPos(appSplunk, IntPtr.Zero, -10, -50, (int)pSplunk.ClientSize.Width + 20, (int)pSplunk.ClientSize.Height + 52, SWP_NOZORDER | SWP_NOACTIVATE);
        }
       
        private void pFhs_Resize(object sender, EventArgs e)
        {
            if (appFhs == null)
                return;
            SetWindowPos(appFhs, IntPtr.Zero, -10, -50, (int)pFhs.ClientSize.Width + 20, (int)pFhs.ClientSize.Height + 52, SWP_NOZORDER | SWP_NOACTIVATE);
        }          

        private void wB(object sender, EventArgs e)
        {

        }

        private void wBac_VisibleChanged(object sender, EventArgs e)
        {
            initializeWebBrowser(sender);

        }   

        private void Form1_Shown(object sender, EventArgs e)
        {
            initForm();
        }  

        private void Form1_Click(object sender, EventArgs e)
        {
           // Activate();

        }       
    }
}
