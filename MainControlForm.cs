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
    public partial class MainControlForm : Form
    {
        // 6.2 Create a global List<T> of type Information called Wiki.
        private List<Information> Wiki = new List<Information>();
        private List<ViewDefinition> tabPageControls = new List<ViewDefinition>();
        private bool workModified = false;
        private string searchType = "names";
        private string filePath = String.Empty;
        public MainControlForm()
        {
            InitializeComponent();
            lst_items.FullRowSelect = true;
        }

        private void MainControlForm_Load(object sender, EventArgs e)
        {
            tabController.TabPages.Clear();
        }

        #region PrivateFunctions
        private void OpenDefinition(Information definition)
        {
            for (int i = 0; i < tabPageControls.Count; i++)
            {
                if(definition.CheckIdentical(tabPageControls[i].GetBaseDefinition()))
                {
                    tabController.SelectedIndex = i;
                    return;
                }
            }

            ViewDefinition newDefinitionViewer = new ViewDefinition(definition, this, tabController.TabCount, Wiki.IndexOf(definition), false);
            newDefinitionViewer.Dock = DockStyle.Fill;
            tabPageControls.Add(newDefinitionViewer);

            TabPage newTabPage = new TabPage();
            newTabPage.Controls.Add(newDefinitionViewer);

            tabController.TabPages.Add(newTabPage);
            tabController.TabPages[tabController.TabPages.IndexOf(newTabPage)].Text = definition.GetItemName();
        }
        private void NewDefinition()
        {
            // 6.3 Create a button method to ADD a new item to the list.
            // Use a TextBox for the Name input, ComboBox for the Category,
            // Radio group for the Structure and Multiline TextBox for the
            // Definition.
            Information newDefinition = new Information();

            ViewDefinition newDefinitionViewer = new ViewDefinition(newDefinition, this, tabController.TabCount, Wiki.Count, true);
            newDefinitionViewer.Dock = DockStyle.Fill;
            tabPageControls.Add(newDefinitionViewer);

            TabPage newTabPage = new TabPage();
            newTabPage.Controls.Add(newDefinitionViewer);
            newTabPage.Controls[0].Name = "tabController";

            tabController.TabPages.Add(newTabPage);
            tabController.TabPages[tabController.TabPages.IndexOf(newTabPage)].Text = "New Item";

            SortNames();
        }
        private bool ValidName(string check)
        {
            // 6.5 Create a custom ValidName method which will take a parameter
            // string value from the Textbox Name and returns a Boolean after
            // checking for duplicates. Use the built in List<T> method “Exists”
            // to answer this requirement.

            Wiki.Sort();
            Information searchFor = new Information(textBox1.Text, null, null, null);
            int index = Wiki.BinarySearch(searchFor);
            if (index == -1)
            {
                return true;
            }

            return false;
        }
        private bool wouldUserLikeToSaveTheirWork()
        {
            if (workModified)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "You didn't save your work! Would you like to go back and do that?";
                string caption = "Your work has not been saved!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // If the user clicks yes, return
                    return true;
                }
            }

            return false;
        }
        // 6.14 Create two buttons for the manual open and save option; this must use a dialog box to select
        // a file or rename a saved file. All Wiki data is stored/retrieved using a binary file format.
        // See Save() and SaveAs()
        private void Save()
        {
            // If there is no file currently open
            // Show dialogue to save the file to a specific place.
            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine($"Saving as new file...");
                SaveAs();
            }
            // Otherwise just save the file to the specified variable.
            else
            {
                Console.WriteLine($"saving the file to {filePath}");

                // Write the string array to a new file named "WriteLines.txt".
                using (BinaryWriter bw = new BinaryWriter(File.Open(filePath, FileMode.Create), Encoding.UTF8, false))
                {
                    // Save the amount of items in this list, so to open funciton knows how many iterations it needs
                    // to go through.
                    bw.Write(Wiki.Count);
                    foreach (Information item in Wiki)
                    {
                        bw.Write((string)item.GetItemName());
                        bw.Write((string)item.GetItemType());
                        bw.Write((string)item.GetItemSubType());
                        bw.Write((string)item.GetItemDescription());
                    }
                }
            }
        }
        private void SaveAs()
        {
            // Always specifiy a location to save the document
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "All files (*.*)|*.*|CoWA files (*.cwa)|*.cowa";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog1.FileName;
                using (BinaryWriter bw = new BinaryWriter(File.Open(filePath, FileMode.Create), Encoding.UTF8, false))
                {
                    // Same as Save function.
                    bw.Write(Wiki.Count);
                    foreach (Information item in Wiki)
                    {
                        bw.Write((string)item.GetItemName());
                        bw.Write((string)item.GetItemType());
                        bw.Write((string)item.GetItemSubType());
                        bw.Write((string)item.GetItemDescription());
                    }
                }
                UpdateList();
            }
        }
        private void OpenFile()
        {
            // Dialogue box which specifies a file to be opened.
            var localFilePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                openFileDialog.Filter = "All files (*.*)|*.*|CoWA files (*.cowa)|*.cowa";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    localFilePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    try
                    {
                        // Open the text file using a stream reader.
                        using (BinaryReader br = new BinaryReader(File.Open(localFilePath, FileMode.Open), Encoding.UTF8, false))
                        {
                            // Clear the current wiki before adding new items to it.
                            Wiki.Clear();

                            int defAmount = br.ReadInt32();
                            for (int i = 0; i < defAmount; i++)
                            {
                                string name = br.ReadString();
                                string type = br.ReadString();
                                string subtype = br.ReadString();
                                string description = br.ReadString();

                                Information newDef = new Information(name, type, subtype, description);
                                Wiki.Add(newDef);
                            }
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("That file is currently in use by another program!", "IOException! Failed to load!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error!");
                    }
                }
                else
                {
                    localFilePath = filePath;
                }
            }

            filePath = localFilePath;

            UpdateList();
            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }
        // 6.9 Create a single custom method that will sort and then display the Name and
        // Category from the wiki information in the list.
        private void SortNames()
        {
            Wiki.Sort();
            UpdateList();
        }
        #endregion

        #region PublicFunctions
        public void UpdateItem(int itemIndex, Information overwrite)
        {
            Wiki[itemIndex].SetAll(overwrite.GetItemName(), overwrite.GetItemType(), overwrite.GetItemSubType(), overwrite.GetItemDescription());
            workModified = true;
            UpdateList();
        }
        public void UpdateList()
        {
            lst_items.Items.Clear();

            foreach (var item in Wiki)
            { // Update Items In List
                lst_items.Items.Add(item.GetItemName()).SubItems.Add(item.GetItemType());
            }

            foreach (TabPage tabPage in tabController.TabPages)
            { // Update TabPage headers
                string name = tabPageControls[tabController.TabPages.IndexOf(tabPage)].GetBaseDefinition().GetItemName();
                if(name != null)
                {
                    tabPage.Text = name;
                }
                else
                {
                    tabPage.Text = "New Item";
                }

                foreach (ViewDefinition page in tabPage.Controls)
                {
                    // Update the pages tab index
                    page.UpdateTabIndex(tabController.TabPages.IndexOf(tabPage));
                    
                    // Update the pages item list reference
                    Wiki.Sort();
                    Information searchFor = page.GetBaseDefinition();
                    int index = Wiki.BinarySearch(searchFor);

                    page.UpdateDefIndex(index);
                }
            }
            Wiki.Sort();
        }
        // Update please???
        public bool AddItem(Information itemToAdd)
        {
            workModified = true;
            foreach (Information item in Wiki)
            { // If this item already exists, do not add it.
                if(item.CheckIdentical(itemToAdd))
                {
                    SortNames();
                    return false;
                }
            }

            if (ValidName(itemToAdd.GetItemName()))
            {
                Wiki.Add(itemToAdd);
                SortNames();
                return true;
            }

            return false;
        }
        public void CloseTab(int tabIndex)
        {
            tabController.TabPages.RemoveAt(tabIndex); // remove tab page
            tabPageControls.RemoveAt(tabIndex); // remove reference to control

            // Update the index of all active pages
            for (int i = 0; i < tabPageControls.Count; i++)
            {
                tabPageControls[i].UpdateTabIndex(i);
            }
        }
        public void DeleteItem(Information itemToRemove, int tabIndex)
        {
            workModified = true;
            CloseTab(tabIndex);
            Wiki.Remove(itemToRemove);
            UpdateList();
        }
        public void DeleteItem(int itemToRemove, int tabIndex)
        { // Delete at index instead of deleting the definition
            workModified = true;
            CloseTab(tabIndex);
            Wiki.RemoveAt(itemToRemove);
            UpdateList();
        }
        public void UpdateSearchType(string updateTo)
        {
            searchType = updateTo;
            Console.WriteLine(searchType);
        }
        public string GetSearchType()
        {
            return searchType;
        }
        #endregion

        #region Interaction
        private void button1_Click(object sender, EventArgs e)
        {
            NewDefinition();
        }
        // 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names
        // and the associated information will be displayed in the related text boxes combo box and radio button.
        private void lst_items_DoubleClick(object sender, EventArgs e)
        {
            if (lst_items.SelectedIndices.Count != -1)
            { // If you double click an item in the list, open it
                OpenDefinition(Wiki[lst_items.SelectedIndices[0]]);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(lst_items.SelectedIndices.Count != -1)
            {
                OpenDefinition(Wiki[lst_items.SelectedIndices[0]]);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void button4_MouseHover(object sender, EventArgs e)
        {
            ToolTip newToolTip = new ToolTip();
            newToolTip.Show("You can also double click an item in the list to open it", button4);
        }
        private void lst_items_KeyUp(object sender, KeyEventArgs e)
        {
            if (lst_items.Focused)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (lst_items.SelectedIndices.Count != -1)
                    {
                        OpenDefinition(Wiki[lst_items.SelectedIndices[0]]);
                    }
                }

            }
        }
        private void tabController_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabController.SelectedIndex != -1)
            {
                tabPageControls[tabController.SelectedIndex].UpdateForm();
            }
        }
        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!wouldUserLikeToSaveTheirWork())
            {
                Wiki.Clear();
                tabPageControls.Clear();
                tabController.TabPages.Clear();

                UpdateList();
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!wouldUserLikeToSaveTheirWork())
            {
                Application.Exit();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        { // Change Filters Button
            //FiltersForm filters = new FiltersForm(this);
            //filters.ShowDialog();
        }
        // 6.10 Create a button method that will use the builtin binary search to find a Data Structure name.
        // If the record is found the associated details will populate the appropriate input controls and
        // highlight the name in the ListView. At the end of the search process the search input TextBox
        // must be cleared.
        private void button2_Click(object sender, EventArgs e)
        { // Search Button
            Wiki.Sort();
            Information searchFor = new Information(textBox1.Text, null, null, null);
            int index = Wiki.BinarySearch(searchFor);
            if(index == -1) 
            {
                MessageBox.Show("Item was not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return; 
            }

            textBox1.Text = String.Empty;
            OpenDefinition(Wiki[index]);
        }
        #endregion


    }
}
