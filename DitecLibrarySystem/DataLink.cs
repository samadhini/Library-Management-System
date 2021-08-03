using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DitecLibrarySystem
{
    class DataLink
    {
        public static OleDbConnection   libConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;User Id=;Password=;Data Source=db_library.accdb");

        //to use insert,update,delete commands
        public static bool runOleDbCommand(string Command) 
        {

OleDbCommand OleDbCommand = new OleDbCommand(Command, libConnection);
try
{
    libConnection.Open();
    OleDbCommand.ExecuteNonQuery();
    return true;
}
catch (Exception ex)
{
    MessageBox.Show(ex.Message, "Error While Command Execution !", MessageBoxButtons.OK, MessageBoxIcon.Error);
    return false;
}
finally
{
    libConnection.Close();
}
        }


            //end of class do not type
    
}}
