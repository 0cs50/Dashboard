using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;


namespace Dashboard
{
    [System.ComponentModel.DesignerCategory("")]
    public partial class Form1
    {
        private SQLiteDatabase db = new SQLiteDatabase();
        DataTable data;
        // Fill the listboxes from the database
        private void getDataFromDb(string query, ListBox lstBox)
        {
            try
            {
                lstBox.Items.Clear();           
                data = db.GetDataTable(query);
                foreach (DataRow r in data.Rows)
                {
                    lstBox.Items.Add(r[0].ToString());                    
                }
            }
            catch (Exception fail)
            {
                failure(fail);
            }
        }

        //Show error in case the query fails
        private void failure(Exception fail)
        {
            String error = "The following error has occurred:\n\n";
            error += fail.Message.ToString() + "\n\n";
            MessageBox.Show(error);
            this.Close();
        }
        
        private void query()
        {
            String query = "Select ihost_navn from iHosts";
            getDataFromDb(query, chSubscribable);
        }

        private void selectQuery()
        {

            String query = "Select Name from MyHosts";
            getDataFromDb(query, lselectedHosts);
            
        }

        private void myHosts()
        {
            String query = "Select host_name from Hosts";
            getDataFromDb(query, listMyHosts);
            
        }

        private void services()
        {
            String query = "Select services from HostService";
            getDataFromDb(query, listServices);
            
        }

        //show subscribed servers
        private void myCheckedList()
        {
            List<string> lst = new List<string>();
            
            String query = "select Name from MyHosts";
            data = db.GetDataTable(query);
            //getDataFromDb(query, lst);

            foreach (DataRow r in data.Rows)
            {
                lst.Add(r[0].ToString());
            }
            //Show subscribed servers as checked
            for (int count = 0; count < chSubscribable.Items.Count; count++)
            {
                if (lst.Contains(chSubscribable.Items[count].ToString()))
                {
                    chSubscribable.SetItemChecked(count, true);
                }
            }

        }

        private void populateIndex(object sender)
        {
            ListBox list = (ListBox)sender;


            // Get selected index and  make sure it is valid.
            int selected = list.SelectedIndex;
            if (selected != -1)
            {
                string idx = list.Items[selected].ToString();                
                string where = "hosts = " + "'" + idx + "'";
                listServices.Items.Clear();
                string query = String.Format("Select services from HostService where ({0});", where);
                data = db.GetDataTable(query);
                //Add services from the host to services list
                foreach (DataRow r in data.Rows)
                {
                    listServices.Items.Add(r[0].ToString());
                }
                //Forward the host to Icinga for monitering
                wIcinga.Navigate(@"https://monitor.mobil.telenor.no/icinga/cgi-bin/status.cgi?search_string=" + Text);
            }
        }

        private void suscribeServer()
        {
            int selected = chSubscribable.SelectedIndex;
            if (selected != -1)
            {
                string Text = chSubscribable.Items[selected].ToString();                
                string query;
                string where = "";
                //Unsubscribe if the item is already checked
                if (chSubscribable.CheckedItems.Count != 0)
                {
                    for (int x = 0; x <= lselectedHosts.Items.Count - 1; x++)
                    {
                        if (lselectedHosts.Items[x].ToString() == Text)
                        {
                            where = "Name = " + "'" + Text + "'";
                            query = String.Format("DELETE FROM MyHosts where ({0});", where);
                            data = db.GetDataTable(query);
                            chSubscribable.SetItemChecked(selected, false);
                            selectQuery();
                            return;
                        }
                    }
                }
                //Suscribe and check in the list
                where = "ihost_navn = " + "'" + Text + "'";
                query = String.Format("INSERT INTO MyHosts Select ihost_id, ihost_navn from iHosts where ({0});", where);
                data = db.GetDataTable(query);
                chSubscribable.SetItemChecked(selected, true);
                selectQuery();
            }
        }

    }
}
