using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EmployeeMover
{
    public partial class EmployeeMover : Form
    {
        private string Username => listBoxUsers.SelectedItem?.ToString();
        private string SaveId => listBoxSaves.SelectedItem?.ToString();
        private string SelectedBusinessEntry => listBoxBusinesses.SelectedItem?.ToString();
        private string EmployeeFolder => listBoxEmployees.SelectedItem?.ToString();

        public EmployeeMover()
        {
            InitializeComponent();
            listBoxSaves.SelectedIndexChanged += listBoxSaves_SelectedIndexChanged;
            listBoxBusinesses.SelectedIndexChanged += listBoxBusinesses_SelectedIndexChanged;
            btnSendToBungalo.Click += (s, e) => MoveEmployeeTo("Bungalow");
            btnSendToWarehouse.Click += (s, e) => MoveEmployeeTo("Docks Warehouse");
            btnSendToSweatshop.Click += (s, e) => MoveEmployeeTo("Sweatshop");
            btnSendToBarn.Click += (s, e) => MoveEmployeeTo("Barn");
            btnSendToMotel.Click += (s, e) => MoveEmployeeTo("Motel room");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Get the full resource name
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().FirstOrDefault(name => name.EndsWith("Image1.png"));

            if (resourceName != null)
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
            else
            {
                MessageBox.Show("Embedded image not found.");
            }

            const string usersFolder = @"C:\Users";
            try
            {
                string[] userDirectories = Directory.GetDirectories(usersFolder);

                foreach (string dir in userDirectories)
                {
                    // Just get the folder name (username)
                    string username = Path.GetFileName(dir);
                    listBoxUsers.Items.Add(username);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxSaves.Items.Clear();
            listBoxBusinesses.Items.Clear();

            if (string.IsNullOrEmpty(Username))
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            string saveRootPath = $@"C:\Users\{Username}\AppData\LocalLow\TVGS\Schedule I\Saves";

            if (Directory.Exists(saveRootPath))
            {
                string[] saveFolders = Directory.GetDirectories(saveRootPath);
                foreach (string folder in saveFolders)
                {
                    listBoxSaves.Items.Add(Path.GetFileName(folder));
                }
            }
            else
            {
                MessageBox.Show("No saves found for this user.");
            }
        }

        private void listBoxSaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxBusinesses.Items.Clear();
            listBoxEmployees.Items.Clear(); // optional: reset employee view too

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(SaveId))
            {
                MessageBox.Show("Please select a user and save first.");
                return;
            }

            string basePath = $@"C:\Users\{Username}\AppData\LocalLow\TVGS\Schedule I\Saves\{SaveId}\SaveGame_1";

            string propertiesPath = Path.Combine(basePath, "Properties");
            string businessesPath = Path.Combine(basePath, "Businesses");

            // Load from Properties
            if (Directory.Exists(propertiesPath))
            {
                string[] propertyFolders = Directory.GetDirectories(propertiesPath);
                foreach (string folder in propertyFolders)
                {
                    string name = Path.GetFileName(folder);
                    listBoxBusinesses.Items.Add($"{name} (Properties)");
                }
            }

            // Load from Businesses
            if (Directory.Exists(businessesPath))
            {
                string[] businessFolders = Directory.GetDirectories(businessesPath);
                foreach (string folder in businessFolders)
                {
                    string name = Path.GetFileName(folder);
                    listBoxBusinesses.Items.Add($"{name} (Businesses)");
                }
            }

            if (listBoxBusinesses.Items.Count == 0)
            {
                MessageBox.Show("No properties or businesses found.");
            }
        }

        private void listBoxBusinesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxEmployees.Items.Clear();

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(SaveId) || string.IsNullOrEmpty(SelectedBusinessEntry))
            {
                MessageBox.Show("Please select a user, save and business first.");
                return;
            }

            // Determine source and actual business name
            string businessType;
            string businessName;

            if (SelectedBusinessEntry.EndsWith(" (Properties)"))
            {
                businessType = "Properties";
                businessName = SelectedBusinessEntry.Replace(" (Properties)", "");
            }
            else if (SelectedBusinessEntry.EndsWith(" (Businesses)"))
            {
                businessType = "Businesses";
                businessName = SelectedBusinessEntry.Replace(" (Businesses)", "");
            }
            else
            {
                MessageBox.Show("Unknown business entry format.");
                return;
            }

            string basePath = $@"C:\Users\{Username}\AppData\LocalLow\TVGS\Schedule I\Saves\{SaveId}\SaveGame_1";
            string finalPath = Path.Combine(basePath, businessType, businessName, "Employees");

            if (Directory.Exists(finalPath))
            {
                string[] employeeFolders = Directory.GetDirectories(finalPath);
                foreach (string folder in employeeFolders)
                {
                    listBoxEmployees.Items.Add(Path.GetFileName(folder));
                }
            }
            else
            {
                MessageBox.Show("No Employees folder found in this business.");
            }
        }

        private void MoveEmployeeTo(string targetBusinessDisplayName)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(SaveId) || string.IsNullOrEmpty(SelectedBusinessEntry) || string.IsNullOrEmpty(EmployeeFolder))
            {
                MessageBox.Show("Please select a user, save, business, and employee first.");
                return;
            }

            // 🔁 Map full display names to internal codes (used in JSON)
            var businessCodeMap = new Dictionary<string, string>
            {
                { "Bungalow", "bungalow" },
                { "Docks Warehouse", "dockswarehouse" },
                { "Sweatshop", "sweatshop" },
                { "Barn", "barn" },
                { "Motel room", "motel" }
            };

            if (!businessCodeMap.ContainsKey(targetBusinessDisplayName))
            {
                MessageBox.Show("Unknown destination business.");
                return;
            }

            string targetBusinessFolderName = targetBusinessDisplayName; // Used for path
            string targetBusinessCode = businessCodeMap[targetBusinessDisplayName]; // Used for JSON

            // 🔎 Parse source business
            string currentBusinessType;
            string currentBusinessFolderName;

            if (SelectedBusinessEntry.EndsWith(" (Properties)"))
            {
                currentBusinessType = "Properties";
                currentBusinessFolderName = SelectedBusinessEntry.Replace(" (Properties)", "");
            }
            else if (SelectedBusinessEntry.EndsWith(" (Businesses)"))
            {
                currentBusinessType = "Businesses";
                currentBusinessFolderName = SelectedBusinessEntry.Replace(" (Businesses)", "");
            }
            else
            {
                MessageBox.Show("Unknown current business format.");
                return;
            }

            string basePath = $@"C:\Users\{Username}\AppData\LocalLow\TVGS\Schedule I\Saves\{SaveId}\SaveGame_1";

            string sourcePath = Path.Combine(basePath, currentBusinessType, currentBusinessFolderName, "Employees", EmployeeFolder);
            string destinationPath = Path.Combine(basePath, "Properties", targetBusinessFolderName, "Employees", EmployeeFolder);
            string npcJsonPath = Path.Combine(destinationPath, "NPC.json");

            try
            {
                if (!Directory.Exists(sourcePath))
                {
                    MessageBox.Show("Selected employee folder not found.");
                    return;
                }

                if (!Directory.Exists(Path.Combine(basePath, "Properties", targetBusinessFolderName, "Employees")))
                {
                    MessageBox.Show($"Target property '{targetBusinessFolderName}' doesn't exist or has no Employees folder.");
                    return;
                }

                if (sourcePath == destinationPath)
                {
                    MessageBox.Show($"Cannot move Employee {EmployeeFolder} to the same property");
                    return;
                }

                // 🚫 Delete existing destination if it already exists
                if (Directory.Exists(destinationPath))
                {
                    Directory.Delete(destinationPath, true); // true = recursive
                }

                // ✅ Move the folder
                Directory.Move(sourcePath, destinationPath);

                // ✅ Update JSON
                if (File.Exists(npcJsonPath))
                {
                    string json = File.ReadAllText(npcJsonPath);
                    dynamic npc = JsonConvert.DeserializeObject(json);

                    npc.AssignedProperty = targetBusinessCode;

                    // Optional: Set position per location
                    float x = 0, y = 0, z = 0;
                    switch (targetBusinessCode)
                    {
                        case "bungalow":
                            x = -50.0f; y = 0.0f; z = 120.0f; break;
                        case "sweatshop":
                            x = -62.0f; y = -40.0f; z = 143.0f; break;
                        case "barn":
                            x = 179.0f; y = 0.0f; z = -4.0f; break;
                        case "dockswarehouse":
                            x = -78.0f; y = -2.0f; z = -63.0f; break;
                        case "motel":
                            x = 0f; y = 0f; z = 0f; break; // Placeholder
                    }

                    npc.Position.x = x;
                    npc.Position.y = y;
                    npc.Position.z = z;

                    string updatedJson = JsonConvert.SerializeObject(npc, Formatting.Indented);
                    File.WriteAllText(npcJsonPath, updatedJson);
                }

                MessageBox.Show($"Moved {EmployeeFolder} to {targetBusinessDisplayName}!");
                listBoxBusinesses_SelectedIndexChanged(null, null); // Refresh employees
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error moving employee: {ex.Message}");
            }
        }
    }
}