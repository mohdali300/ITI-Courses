namespace Lab10_WinForms;


public partial class Form1 : Form
{
    private ListBox leftListBox;
    private ListBox rightListBox;
    private TextBox leftTextBox;
    private TextBox rightTextBox;
    private Button moveRightButton;
    private Button moveLeftButton;
    private Button copyButton;
    private Button deleteButton;
    private Button backButton;

    private string leftCurrentPath = "";
    private string rightCurrentPath = "";
    private ListBox lastAccessedPane = null;

    public Form1()
    {
        InitializeComponent();
        InitializeCustomComponents();
        LoadDrives(leftListBox, leftTextBox);
        LoadDrives(rightListBox, rightTextBox);
    }


    private void InitializeCustomComponents()
    {
        leftTextBox = new TextBox
        {
            Location = new Point(10, 10),
            Size = new Size(400, 25),
            ReadOnly = false
        };
        leftTextBox.KeyPress += LeftTextBox_KeyPress;

        rightTextBox = new TextBox
        {
            Location = new Point(490, 10),
            Size = new Size(400, 25),
            ReadOnly = false
        };
        rightTextBox.KeyPress += RightTextBox_KeyPress;

        leftListBox = new ListBox
        {
            Location = new Point(10, 40),
            Size = new Size(400, 400)
        };
        leftListBox.Click += (s, e) => lastAccessedPane = leftListBox;
        leftListBox.DoubleClick += LeftListBox_DoubleClick;

        rightListBox = new ListBox
        {
            Location = new Point(490, 40),
            Size = new Size(400, 400)
        };
        rightListBox.Click += (s, e) => lastAccessedPane = rightListBox;
        rightListBox.DoubleClick += RightListBox_DoubleClick;

        moveRightButton = new Button
        {
            Text = ">",
            Location = new Point(420, 150),
            Size = new Size(60, 40)
        };
        moveRightButton.Click += MoveRightButton_Click;

        moveLeftButton = new Button
        {
            Text = "<",
            Location = new Point(420, 200),
            Size = new Size(60, 40)
        };
        moveLeftButton.Click += MoveLeftButton_Click;

        copyButton = new Button
        {
            Text = "Copy",
            Location = new Point(420, 250),
            Size = new Size(60, 40),
            Enabled = false
        };
        copyButton.Click += CopyButton_Click;

        deleteButton = new Button
        {
            Text = "Delete",
            Location = new Point(420, 300),
            Size = new Size(60, 40),
            Enabled = false
        };
        deleteButton.Click += DeleteButton_Click;

        backButton = new Button
        {
            Text = "Back",
            Location = new Point(420, 350),
            Size = new Size(60, 40)
        };
        backButton.Click += BackButton_Click;

        // Add controls to form
        this.Controls.Add(leftTextBox);
        this.Controls.Add(rightTextBox);
        this.Controls.Add(leftListBox);
        this.Controls.Add(rightListBox);
        this.Controls.Add(moveRightButton);
        this.Controls.Add(moveLeftButton);
        this.Controls.Add(copyButton);
        this.Controls.Add(deleteButton);
        this.Controls.Add(backButton);

        leftListBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
        rightListBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
    }

    private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        bool leftSelected = leftListBox.SelectedIndex >= 0;
        bool rightSelected = rightListBox.SelectedIndex >= 0;

        copyButton.Enabled = leftSelected || rightSelected;
        deleteButton.Enabled = leftSelected || rightSelected;

        moveRightButton.Enabled = leftSelected && !string.IsNullOrEmpty(rightCurrentPath);
        moveLeftButton.Enabled = rightSelected && !string.IsNullOrEmpty(leftCurrentPath);
    }

    private void LoadDrives(ListBox listBox, TextBox textBox)
    {
        listBox.Items.Clear();
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in drives)
        {
            if (drive.IsReady)
            {
                listBox.Items.Add(drive.Name);
            }
        }

        if (listBox == leftListBox)
            leftCurrentPath = "";
        else
            rightCurrentPath = "";

        textBox.Text = "Drives";
    }

    private void LoadDirectory(string path, ListBox listBox, TextBox textBox)
    {
        try
        {
            listBox.Items.Clear();

            // Add navigation items
            listBox.Items.Add(".");
            listBox.Items.Add("..");

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            // Add directories first
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                listBox.Items.Add("[DIR] " + dir.Name);
            }

            // Add files
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                listBox.Items.Add(file.Name);
            }

            textBox.Text = path;

            if (listBox == leftListBox)
                leftCurrentPath = path;
            else
                rightCurrentPath = path;
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("Access denied to this directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LeftListBox_DoubleClick(object sender, EventArgs e)
    {
        HandleDoubleClick(leftListBox, leftTextBox, ref leftCurrentPath);
    }

    private void RightListBox_DoubleClick(object sender, EventArgs e)
    {
        HandleDoubleClick(rightListBox, rightTextBox, ref rightCurrentPath);
    }

    private void HandleDoubleClick(ListBox listBox, TextBox textBox, ref string currentPath)
    {
        if (listBox.SelectedIndex < 0) return;

        string selectedItem = listBox.SelectedItem.ToString();

        // Handle navigation items
        if (selectedItem == ".")
        {
            // Go up one level
            GoUpOneLevel(listBox, textBox, ref currentPath);
            return;
        }
        else if (selectedItem == "..")
        {
            // Go to drives
            LoadDrives(listBox, textBox);
            return;
        }

        // If at drive level
        if (string.IsNullOrEmpty(currentPath))
        {
            // Selected item is a drive
            LoadDirectory(selectedItem, listBox, textBox);
            return;
        }

        // Check if it's a directory
        if (selectedItem.StartsWith("[DIR] "))
        {
            string dirName = selectedItem.Substring(6);
            string newPath = Path.Combine(currentPath, dirName);
            LoadDirectory(newPath, listBox, textBox);
        }
        else
        {
            // It's a file
            string filePath = Path.Combine(currentPath, selectedItem);

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("This is a file and cannot be opened in the explorer.",
                                "File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void GoUpOneLevel(ListBox listBox, TextBox textBox, ref string currentPath)
    {
        if (string.IsNullOrEmpty(currentPath)) return;

        DirectoryInfo dirInfo = new DirectoryInfo(currentPath);
        if (dirInfo.Parent != null)
        {
            LoadDirectory(dirInfo.Parent.FullName, listBox, textBox);
        }
        else
        {
            LoadDrives(listBox, textBox);
        }
    }

    private void MoveRightButton_Click(object sender, EventArgs e)
    {
        MoveItem(leftListBox, rightListBox, leftCurrentPath, rightCurrentPath, ref leftCurrentPath);
    }

    private void MoveLeftButton_Click(object sender, EventArgs e)
    {
        MoveItem(rightListBox, leftListBox, rightCurrentPath, leftCurrentPath, ref rightCurrentPath);
    }

    private void MoveItem(ListBox sourceListBox, ListBox targetListBox, string sourcePath, string targetPath, ref string sourceCurrentPath)
    {
        if (sourceListBox.SelectedIndex < 0) return;
        if (string.IsNullOrEmpty(targetPath))
        {
            MessageBox.Show("Cannot move to drive level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string selectedItem = sourceListBox.SelectedItem.ToString();

        // Skip navigation items
        if (selectedItem == "." || selectedItem == "..") return;

        try
        {
            string itemName = selectedItem.StartsWith("[DIR] ") ? selectedItem.Substring(6) : selectedItem;
            string sourceFullPath = Path.Combine(sourcePath, itemName);
            string targetFullPath = Path.Combine(targetPath, itemName);

            if (selectedItem.StartsWith("[DIR] "))
            {
                Directory.Move(sourceFullPath, targetFullPath);
            }
            else
            {
                File.Move(sourceFullPath, targetFullPath);
            }

            // Refresh both panes
            LoadDirectory(sourcePath, sourceListBox, sourceListBox == leftListBox ? leftTextBox : rightTextBox);
            LoadDirectory(targetPath, targetListBox, targetListBox == leftListBox ? leftTextBox : rightTextBox);

            MessageBox.Show("Item moved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error moving item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CopyButton_Click(object sender, EventArgs e)
    {
        if (lastAccessedPane == null) return;

        ListBox sourceListBox = lastAccessedPane;
        ListBox targetListBox = (sourceListBox == leftListBox) ? rightListBox : leftListBox;
        string sourcePath = (sourceListBox == leftListBox) ? leftCurrentPath : rightCurrentPath;
        string targetPath = (targetListBox == leftListBox) ? leftCurrentPath : rightCurrentPath;

        if (sourceListBox.SelectedIndex < 0) return;
        if (string.IsNullOrEmpty(targetPath))
        {
            MessageBox.Show("Cannot copy to drive level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string selectedItem = sourceListBox.SelectedItem.ToString();

        // Skip navigation items
        if (selectedItem == "." || selectedItem == "..") return;

        try
        {
            string itemName = selectedItem.StartsWith("[DIR] ") ? selectedItem.Substring(6) : selectedItem;
            string sourceFullPath = Path.Combine(sourcePath, itemName);
            string targetFullPath = Path.Combine(targetPath, itemName);

            if (selectedItem.StartsWith("[DIR] "))
            {
                CopyDirectory(sourceFullPath, targetFullPath);
            }
            else
            {
                File.Copy(sourceFullPath, targetFullPath, true);
            }

            // Refresh target pane
            LoadDirectory(targetPath, targetListBox, targetListBox == leftListBox ? leftTextBox : rightTextBox);

            MessageBox.Show("Item copied successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error copying item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CopyDirectory(string sourceDir, string targetDir)
    {
        Directory.CreateDirectory(targetDir);

        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string fileName = Path.GetFileName(file);
            File.Copy(file, Path.Combine(targetDir, fileName), true);
        }

        foreach (string subDir in Directory.GetDirectories(sourceDir))
        {
            string dirName = Path.GetFileName(subDir);
            CopyDirectory(subDir, Path.Combine(targetDir, dirName));
        }
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        if (lastAccessedPane == null) return;

        ListBox sourceListBox = lastAccessedPane;
        string sourcePath = (sourceListBox == leftListBox) ? leftCurrentPath : rightCurrentPath;

        if (sourceListBox.SelectedIndex < 0) return;

        string selectedItem = sourceListBox.SelectedItem.ToString();

        // Skip navigation items
        if (selectedItem == "." || selectedItem == "..") return;

        DialogResult result = MessageBox.Show($"Are you sure you want to delete '{selectedItem}'?",
                                                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result != DialogResult.Yes) return;

        try
        {
            string itemName = selectedItem.StartsWith("[DIR] ") ? selectedItem.Substring(6) : selectedItem;
            string fullPath = Path.Combine(sourcePath, itemName);

            if (selectedItem.StartsWith("[DIR] "))
            {
                Directory.Delete(fullPath, true);
            }
            else
            {
                File.Delete(fullPath);
            }

            // Refresh the pane
            LoadDirectory(sourcePath, sourceListBox, sourceListBox == leftListBox ? leftTextBox : rightTextBox);

            MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        if (lastAccessedPane == null) return;

        if (lastAccessedPane == leftListBox)
        {
            GoUpOneLevel(leftListBox, leftTextBox, ref leftCurrentPath);
        }
        else
        {
            GoUpOneLevel(rightListBox, rightTextBox, ref rightCurrentPath);
        }
    }

    private void LeftTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
            string path = leftTextBox.Text.Trim();
            if (Directory.Exists(path))
            {
                LoadDirectory(path, leftListBox, leftTextBox);
            }
            else
            {
                MessageBox.Show("Invalid path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void RightTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
            string path = rightTextBox.Text.Trim();
            if (Directory.Exists(path))
            {
                LoadDirectory(path, rightListBox, rightTextBox);
            }
            else
            {
                MessageBox.Show("Invalid path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    

}