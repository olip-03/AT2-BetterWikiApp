using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AT2_BetterWikiApp
{
    public partial class ViewDefinition : UserControl
    {
        private bool editing;
        private bool isNew = true;
        private Information baseDefinition;
        private MainControlForm parent;
        private int tabIndex;
        private int definitionIndex;
        private string selectedStructure = "linear";
        private string[] dataStructCats = { "Abstract", "Array", "Graphs", "Hash", "List", "Tree" };

        public ViewDefinition(Information definition, MainControlForm fromParent, int fromTabIndex, int fromDefIndex, bool isEditing)
        { // Overload used for creating new item
            editing = isEditing;
            baseDefinition = definition;
            parent = fromParent;
            tabIndex = fromTabIndex;
            definitionIndex = fromDefIndex;

            InitializeComponent();
            UpdateForm();

            // 6.4 Create and initialise a global string array with the six categories as indicated in the Data
            // Structure Matrix. Create a custom method to populate the ComboBox when the Form Load method is called.
            if (File.Exists("DataStructures.txt"))
            {
                txt_ItemType.Items.Clear();
                string[] lines = System.IO.File.ReadAllLines("DataStructures.txt");
                txt_ItemType.Items.AddRange(lines);
            }
            else
            {
                txt_ItemType.Items.Clear();
                txt_ItemType.Items.AddRange(dataStructCats);
            }
        }
        public Information GetBaseDefinition()
        {
            return baseDefinition;
        }
        #region Methods
        private bool AreFiledsFilledOut()
        {
            if(String.IsNullOrWhiteSpace(txt_ItemDefinition.Text)) { return false; }
            if (String.IsNullOrWhiteSpace(txt_ItemName.Text)) { return false; }
            if(String.IsNullOrWhiteSpace(txt_ItemType.Text)) { return false; }
            return true;
        }
        public void UpdateTabIndex(int fromIndex)
        {
            tabIndex = fromIndex;
        }
        public void UpdateDefIndex(int fromIndex)
        {
            definitionIndex = fromIndex;
        }
        private void SelectSubType(string subtype)
        {
            radiobx_linearSubtype.Checked = true;
            radiobx_nonLinearSubtype.Checked = false;
            if (subtype == "non-linear")
            {
                radiobx_linearSubtype.Checked = false;
                radiobx_nonLinearSubtype.Checked = true;
                return;
            }
        }
        public void UpdateForm()
        {
            if (editing)
            {
                btn_SaveOrEdit.Text = "Save";
            }
            else
            {
                btn_SaveOrEdit.Text = "Edit";
            }

            txt_ItemName.ReadOnly = !editing;
            txt_ItemName.Text = baseDefinition.GetItemName();

            txt_ItemType.Select(0, 0);
            txt_ItemType.Enabled = editing;
            btn_clear.Visible = editing;
            txt_ItemType.Text = baseDefinition.GetItemType();

            radiobx_linearSubtype.Enabled = editing;
            radiobx_nonLinearSubtype.Enabled = editing;
            SelectSubType(baseDefinition.GetItemSubType());

            txt_ItemDefinition.ReadOnly = !editing;
            txt_ItemDefinition.Text = baseDefinition.GetItemDescription();
        }
        // 6.6 Create two methods to highlight and return the values from the Radio button GroupBox.
        // The first method must return a string value from the selected radio button (Linear or Non-Linear).
        // The second method must send an integer index which will highlight an appropriate radio button.
        private String whatStructureIsSelected()
        {
            return selectedStructure;
        }
        private void selectStructure(int value)
        {
            // 1 or below = linear
            // 2 or above - non-linear;
            if (value <= 1)
            {
                selectedStructure = "linear";
            }
            else if (value >= 2)
            {
                selectedStructure = "non-linear";
            }
        }
        #endregion
        #region Interactions
        private void ViewDefinition_Load(object sender, EventArgs e)
        {
            if (editing)
            { // Because the edit state being called on load is only possible if a new item is being created
              // if the editing variable is called on load, we can assume that the user is creating a new item.
                isNew = true;
                btn_SaveOrEdit.Text = "Save Item As New";
                btn_clear.Enabled = true;
                btn_clear.Visible = true;
            }
            else
            {
                isNew = false;
                btn_SaveOrEdit.Text = "Edit";
            }

            UpdateForm();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            parent.CloseTab(tabIndex);
        }
        // 6.8 Create a button method that will save the edited record of the currently selected
        // item in the ListView. All the changes in the input controls will be written back to
        // the list. Display an updated version of the sorted list at the end of this process.
        //
        // What is being asked is half performed here, and half performed in the parent.updateList() 
        // method.
        private void btn_SaveOrEdit_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                if (!AreFiledsFilledOut())
                {
                    MessageBox.Show("All fields need to be filled out before saving!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                baseDefinition = new Information(txt_ItemName.Text, txt_ItemType.Text, whatStructureIsSelected(), txt_ItemDefinition.Text);
                if (isNew)
                {
                    bool added = parent.AddItem(baseDefinition);
                    if (!added)
                    {
                        parent.CloseTab(tabIndex);
                        MessageBox.Show("Item already exists", "Duplicate item found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    parent.UpdateItem(definitionIndex, baseDefinition);
                }
                isNew = false;
                editing = false;
                btn_delete.Enabled = false;
                btn_delete.Visible = false;
                btn_clear.Enabled = false;
                btn_clear.Visible = false;
            }
            else
            {
                editing = true;
                btn_delete.Enabled = true;
                btn_delete.Visible = true;
                btn_clear.Enabled = true;
                btn_clear.Visible = true;
            }

            parent.UpdateList();
            UpdateForm();
        }
        private void ViewDefinition_TabIndexChanged(object sender, EventArgs e)
        {
            UpdateForm();
            Console.WriteLine("Update");
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void radiobx_linearSubtype_CheckedChanged(object sender, EventArgs e)
        {
            selectStructure(1);
        }
        private void radiobx_nonLinearSubtype_CheckedChanged(object sender, EventArgs e)
        {
            selectStructure(2);
        }
                // 6.7 Create a button method that will delete the currently selected record in the ListView.
        // Ensure the user has the option to backout of this action by using a dialog box. Display
        // an updated version of the sorted list at the end of this process.
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this item?????", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // This will update the list and stuff. See the method for it in MainControlForm.cs :)
                parent.DeleteItem(definitionIndex, tabIndex);
            }
        }
        // 6.12 Create a custom method that will clear and reset the TextBboxes, ComboBox and Radio button
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_ItemName.Text = String.Empty;
            txt_ItemType.Text = String.Empty;
            selectedStructure = "linear";
            txt_ItemDefinition.Text = String.Empty;
            SelectSubType(selectedStructure);
        }
        // 6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button.
        private void txt_ItemName_DoubleClick(object sender, EventArgs e)
        {
            txt_ItemName.Text = String.Empty;
        }
        private void txt_ItemType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_ItemType.Text = String.Empty;
        }
        private void txt_ItemDefinition_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_ItemDefinition.Text = String.Empty;
        }
        #endregion
    }
}
