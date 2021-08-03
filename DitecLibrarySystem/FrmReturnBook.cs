using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DitecLibrarySystem
{
    public partial class FrmReturnBook : Form
    {
        public FrmReturnBook()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string sqlCommand = "SELECT*from tbl_barrow_books where RefCode=" + txtRefCode.Text + ";";
            OleDbCommand command = new OleDbCommand(sqlCommand, DataLink.libConnection);
            try
            {
                DataLink.libConnection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lblIsbn.Text = reader["BookID"].ToString();
                        lblMemberId.Text = reader["MemberID"].ToString();
                        lblBarrowDate.Text = Convert.ToDateTime(reader["IssueDate"]).ToString("yyyy-MM-dd");
                        lblReturnDate.Text = Convert.ToDateTime(reader["ReturnDate"]).ToString("yyyy-MM-dd");

                        if (Convert.ToDateTime(lblReturnDate.Text) < DateTime.Now)
                        {
                            MessageBox.Show("You Have Fine !");
                        }
                        btnReturnBooks.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Barrow Book Details");
            }
            finally
            {
                DataLink.libConnection.Close();
            }


        }

        private void btnReturnBooks_Click(object sender, EventArgs e)
        {
            bool result = DataLink.runOleDbCommand("UPDATE tbl_booksSET Status='Available'WHERE BookID=" + lblIsbn.Text + ";");
            DataLink.runOleDbCommand("UPDATE tbl_barrow_books SET Status='completed'WHERE RefCode=" + txtRefCode.Text + ";");
            if (result)
            {
                btnReturnBooks.Enabled = false;
                MessageBox.Show("Book Returned Successfully !", "Ditec Library System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
