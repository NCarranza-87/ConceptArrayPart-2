using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConceptArrayPart2
{
    public partial class frmNameList : Form
    {
        /***************************************************
         * Create a Windows forms application that allows
         * the user to type a name in a textbox and add 
         * them to a user list. The names should be stored 
         * in an array. When the array gets to 10 elements,
         * pop up a messagebox telling the user that no
         * more names may be entered. Finally the user can 
         * click a display button that will show the SORTED
         * list of names in REVERSE alphabetical order.  
         **************************************************/
        List<string> userNames = new List<string>();

        public frmNameList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// when Submit Name has been clicked on names
        /// will be held in memory until Display has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitName_Click(object sender, EventArgs e)
        {
            if (userNames.Count == 10)
            {
                MessageBox.Show("Only 10 usernames are allowed.");
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a user name.");
                txtName.Clear();
                txtName.Focus();
            }
            else
            {
                userNames.Add(txtName.Text.Trim());
                MessageBox.Show("User name has been added.");
            }
            txtName.Clear();
            txtName.Focus();
        }

        /// <summary>
        /// when DisplayList button is clicked the 
        /// list of usernames will be populated in 
        /// the list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDisplayList_Click(object sender, EventArgs e)
        {
            if (userNames.Count == 0)
            {
                MessageBox.Show("Username arraylist is not populated!", "Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string display = string.Join("\n", userNames);
            MessageBox.Show(display, "Usernames");

        }

        /// <summary>
        /// when user enters a search critiria a name
        /// containing that critiria wil populate on the list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //list will now show names of users
            lstNames.Items.Clear();

            string searchTerm = txtSearch.Text.Trim().ToLower();

            //if no search term is not present
            //exit out of method
            if (searchTerm == string.Empty)
            {
                return;
            }

            //when search term is present
            //result should show in list
            foreach (string uNames in userNames)
            {
                
                if (uNames.ToLower().Contains(searchTerm) || uNames.ToUpper().Contains(searchTerm))
                {
                    lstNames.Items.Add(uNames);
                }

            }
        }

        /// <summary>
        /// When user clicks on Sort button
        /// username list will be sorted in
        /// alphabetical order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSort_Click(object sender, EventArgs e)
        {
            if(userNames != null)
            {
                userNames.Reverse();
            }
        }

        /// <summary>
        /// when user click on the Clear button
        /// name that have been added to list
        /// will be cleared and a message box
        /// will confirm that usernames have 
        /// been cleared
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            userNames.Clear();
            MessageBox.Show("Usernames have been clear from list!");
        }

        /// <summary>
        /// when user click on the close button
        /// they will be prompt to close the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            //code when the user clicks on the "Close" button
            //call a method to close the program
            CloseApplication();
        }

        /// <summary>
        /// when user click on the close button
        /// BtnClose_Click will call CloseApplication()
        /// </summary>
        private void CloseApplication()
        {
            //code for closing the program when
            //the CloseAppication() method is
            //called from BtnClose()
            DialogResult result = MessageBox.Show("Are you sure?",
                                                  "Quit?",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }


    }
}
