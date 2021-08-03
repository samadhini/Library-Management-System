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
    public partial class FrmIssueBooks : Form
    {
        public FrmIssueBooks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dtpBarrow_ValueChanged(object sender, EventArgs e)
        {
            dtpReturn.Value = dtpBarrow.Value.AddDays(7);
        }

        private void btnRefCode_Click(object sender, EventArgs e)
        {
            getRefCode();
        }
       
            
        private void btnIssueBooks_Click(object sender, EventArgs e)
        {
            bool result = DataLink.runOleDbCommand("INSERT INTO tbl_barrow_books(RefCode,BookID,MemberID,IssueDate,ReturnDate,Status)values('" + lblRefCode.Text + "','" + txtISBN.Text + "','" + txtMemberID.Text + "','" + dtpBarrow.Value.Date.ToShortDateString() + "','" + dtpReturn.Value.Date.ToShortDateString() + "','issued');");
            DataLink.runOleDbCommand("UPDATE tbl_book SET Status='issued to" + txtMemberID.Text + "'WHERE BookID=" + txtISBN.Text + ";");//update book status
            if (result)
            {
                MessageBox.Show("New Record Added Successfully !", "Ditec Library System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
           

            

        private void FrmIssueBooks_Load(object sender, EventArgs e)
        {
            dtpReturn.Value = dtpBarrow.Value.AddDays(7);
            getRefCode();
        }

        private void label5_Click(object sender, EventArgs e)
        {
         
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblRefCode_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
             private void getRefCode()
        {
            try
{
        OleDbCommand resultscommand = null;
        OleDbDataAdapter adp = new OleDbDataAdapter();
        DataTable resultstable = new DataTable();
        resultscommand=new OleDbCommand("SELECT*from tbl_barrow_books;",DataLink.libConnection);
        adp.Fill(resultstable);
        int _refCode=resultstable.Rows.Count+1;
        lblRefCode.Text=(_refCode.ToString());
            }
    catch(Exception ex)
{
    MessageBox.Show(ex.Message,"Error Loading tbl_barrow_books");
}
}

    }//end of class do not type
}
