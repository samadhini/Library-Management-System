using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DitecLibrarySystem
{
    public partial class FrmHome : Form
    {
        DataView dv ;
       public bool adminUser;
        public FrmHome()
        {
            InitializeComponent();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            FrmBook b=new FrmBook();
            b.ShowDialog();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            loadDatagridBook();
            if (adminUser) 
            { 
                btnBook.Enabled = true;
                btnIssue.Enabled = true;
                btnMember.Enabled = true; 
                btnReturn.Enabled = true; 
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
{
dv.RowFilter = string.Format(cmboSearchBy.Text +"LIKE'%{0}%'", txtBookName.Text);
dataGridBook.DataSource = dv;
}
catch (Exception ex)
{
MessageBox.Show(ex.Message, 
"Filter data");
}

            try{
                dv.RowFilter=string.Format(cmboSearchBy.Text+" Like '%{0}%'",txtBookName.Text);
                dataGridBook.DataSource=dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Filter data");
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            FrmMember m=new FrmMember();
            m.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           loadDatagridBook();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            FrmIssueBooks ib=new FrmIssueBooks();
            ib.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            FrmReturnBook rb = new FrmReturnBook();
            rb.ShowDialog();
        }

        private void dataGridBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
          //To add data to gride view
        public void loadDataGrideBook()
        {
        }

          
            
               //To add data to gride view
                public void loadDatagridBook()
                {
                    try
                    {
                        //codes for loading data
                        OleDbCommand resultsCommand=null;
                        OleDbDataAdapter adp=new OleDbDataAdapter();
                        DataTable resultstable=new DataTable();
                        resultsCommand=new OleDbCommand("SELECT*from tbl_book;",DataLink.libConnection);
                        adp.Fill(resultstable);
                        dataGridBook.DataSource=resultstable;
                        dv=resultstable.DefaultView;

                        //codes for add items for combobox by code
                        cmboSearchBy.Items.Clear();
                        cmboSearchBy.Items.Add("BookName");
                        cmboSearchBy.Items.Add("Author");
                        cmboSearchBy.Items.Add("Category");
                        cmboSearchBy.Text="BookName";
                        


                    
                    
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"loading data");
            }

                }

        private void lblDateTime_Click(object sender, EventArgs e)
        {
            lblDateTime.Text=DateTime.Now.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            loadDatagridBook();
            if (adminUser)
            {
                btnBook.Enabled = true;
                btnIssue.Enabled = true;
                btnMember.Enabled = true;
                btnReturn.Enabled = true;
            }
        }
    // To add data to grid view 
/*public void loadDatagridBook()
{
try
{
//codes for loading data
OleDbCommand resultscommand = null;
OleDbDataAdapter adp = new OleDbDataAdapter();
DataTable resultstable = new DataTable();
resultscommand = new OleDbCommand("SELECT * from tbl_book;", DataLink.libConnection);
adp.SelectCommand = resultscommand;
adp.Fill(resultstable);
dataGridBook.DataSource=resultstable;
dv=resultstable.DefaultView;
//codes for add items for combobox by code
cmboSearchBy.Items.Clear();
cmboSearchBy.Items.Add("BookName");
cmboSearchBy.Items.Add("Author");
cmboSearchBy.
Items.Add("Category");
cmboSearchBy.Text = "BookName";
}
catch (Exception ex)
{
MessageBox.Show(ex.Message, "Loading data");
}

        }*/
//end of class do not type
    }
}
