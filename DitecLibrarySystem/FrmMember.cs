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
    public partial class FrmMember : Form
    {
        static string gender;
        static string _lifeLong;
        public FrmMember()
        {
            InitializeComponent();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
bool result = DataLink.runOleDbCommand("insert into tbl_member (NIC,MemberName,Phone,Gender,Lifelong) values ('" + txtMemberId.Text + "','" + txtName.Text + "','"+txtPhone.Text+"','"+gender+"','"+_lifeLong+"');");
if (result)
{
MessageBox.Show("New Member Added successfully !", "Ditec Library System ", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
loadDatagridMember();
clearAll_UI();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string sqlCommand = "SELECT*from tbl_member  where NIC = '" + txtMemberId.Text + "';";
OleDbCommand command = new OleDbCommand(sqlCommand, DataLink.libConnection);
try
{
DataLink.libConnection.Open();
using(OleDbDataReader reader = command.ExecuteReader())
{
while (reader.Read())
{
txtName.Text = reader["MemberName"].ToString();
txtPhone.Text = reader["Phone"].ToString();
lblGender.Text = reader["Gender"].ToString();
chkLifeLong.Text = reader["Lifelong"].ToString();


/*if (lblGender="male")
{
rbtnMale.Checked = true;
}
else
{
rbtnFemale.Checked = true;
}
if (chkLifeLong="yes")
{
chkLifeLong.Checked = true;
}
else
{
chkLifeLong.Checked = false;
}*/
}
}
}
catch (Exception ex)
{
MessageBox.Show(ex.Message, "Error While Command Execution !", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
finally
{
DataLink.libConnection.Close();
}
        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMale.Checked == true)
            {
               gender="male";
            }
        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFemale.Checked == true)
            {
                gender="female";
            }
        }

        private void chkLifeLong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLifeLong.Checked == true)
            {
                _lifeLong="yes";
            }
            else
            {
                _lifeLong="no";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = DataLink.runOleDbCommand("DELETE * FROM tbl_member where NIC = '" + txtMemberId.Text + "';");
            if (result)
            {
                MessageBox.Show
                ("Book deleted successfully !", "Ditec Library System ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadDatagridMember();
            clearAll_UI();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
bool result = DataLink.runOleDbCommand("UPDATE tbl_member SET MemberName = '" + txtName.Text + "',Phone='" + txtPhone.Text + "',Gender= '" + gender + "',Lifelong = '" + _lifeLong + "'  WHERE NIC ='" + txtMemberId.Text + "';");
if (result)
{
MessageBox.Show("Updated successfully !", "Ditec Library System ", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
loadDatagridMember();
clearAll_UI();
        }

        private void FrmMember_Load(object sender, EventArgs e)
        {
            loadDatagridMember();
        }
        // To add data to grid view 
public void loadDatagridMember()
{
try
{
OleDbCommand resultscommand = null;
OleDbDataAdapter adp = new OleDbDataAdapter();
DataTable resultstable = new DataTable();
resultscommand = new OleDbCommand("SELECT * from tbl_member;", DataLink.libConnection);
adp.SelectCommand = resultscommand;
adp.Fill(resultstable);
dataGridMember.DataSource = resultstable;
}
catch (Exception ex)
{
MessageBox.Show(ex.Message,"Error Loading Memebr Details");                
}     
}
private void clearAll_UI()
{
txtMemberId.Clear();
txtName.Clear();
txtPhone.Clear();
chkLifeLong.Checked = false;
rbtnFemale.Checked = false;
rbtnMale.Checked = false;
}

private void txtMemberId_TextChanged(object sender, EventArgs e)
{

}

private void txtName_TextChanged(object sender, EventArgs e)
{

}

    }
}
