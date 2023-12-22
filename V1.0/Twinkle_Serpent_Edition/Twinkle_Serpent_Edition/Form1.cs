/*
Twinkle Serpent Edition
Distributed under the MIT License
© Copyright Maxim Bortnikov 2023
For more information please visit
https://github.com/Northstrix/Twinkle-Serpent-Edition
https://sourceforge.net/projects/twinkle-serpent-edition/
*/
using System;
using System.Collections;
using System.IO;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
namespace Twinkle_Serpent_Edition
{
    public partial class Form1 : Form
    {
        protected static string key; //Encryption/Decryption Key
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the font selection dialog
            using (FontDialog fontDialog = new FontDialog())
            {
                // Show the dialog
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    // Set the chosen font to richTextBox1
                    SetFontToRichTextBox(richTextBox1, fontDialog.Font);
                }
            }
        }

        private void SetFontToRichTextBox(RichTextBox richTextBox, Font font)
        {
            // Set the font to the RichTextBox
            richTextBox.Font = font;
        }

        private void openDocumentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            open_text_document();
        }

        private void openEncryptedDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (check_key_validity())
                open_encrypted_document();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_text_document();
        }

        private void saveEncryptedDocumentAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (check_key_validity())
                save_encrypted_document();
        }

        private void generateKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Generate 32 random ASCII characters (excluding space ' ')
            string randomAscii = GenerateRandomAscii(32);
            key = randomAscii;

            // Open SaveFileDialog to prompt user for file location
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Encryption/Decryption Key Files|*.key";
                saveFileDialog.Title = "Save Generated Key to File";
                saveFileDialog.DefaultExt = "key";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save generated ASCII to the selected file
                    File.WriteAllText(saveFileDialog.FileName, randomAscii);
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void selectKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Encryption/Decryption Key Files|*.key";
                openFileDialog.Title = "Select The Key";
                openFileDialog.DefaultExt = "key";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Open the file for reading
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Read the content of the file
                        string fileContent = File.ReadAllText(filePath);

                        // Check if the file has exactly 32 characters
                        if (fileContent.Length == 32)
                        {
                            key = fileContent;
                        }
                        else
                        {
                            throw new InvalidOperationException("Wrong key format!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void open_encrypted_document()
        {
            // Open the file selection dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Encrypted Text Files|*.etxt|All Files|*.*";
                openFileDialog.Title = "Select an Encrypted Text File To Open";

                // Show the dialog
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Read the selected text file and display its content
                    DecryptTextFileContent(openFileDialog.FileName);
                }
            }
        }

        private void save_encrypted_document()
        {
            try
            {
                // Check if richTextBox1 is empty
                if (string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    MessageBox.Show("Cannot save an empty file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Open the save file dialog
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Encrypted Text Files|*.etxt|All Files|*.*";
                    saveFileDialog.Title = "Save Encrypted Text File";

                    // Show the dialog
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the content of richTextBox1 to the selected file
                        SaveEncryptedDocument(saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save_text_document()
        {
            // Open the save file dialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                saveFileDialog.Title = "Save Text File";

                // Show the dialog
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the content of richTextBox1 to the selected file
                    SaveRichTextBoxContent(saveFileDialog.FileName);
                }
            }
        }

        private void SaveRichTextBoxContent(string filePath)
        {
            try
            {
                // Save the content of richTextBox1 to the selected file
                File.WriteAllText(filePath, richTextBox1.Text);
                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveEncryptedDocument(string filePath)
        {
            try
            {
                byte[] iv = GenerateRandomIV();
                byte[] encryptedIV = EncryptSerpent(iv);
                byte[] inputData = Encoding.UTF8.GetBytes(richTextBox1.Text);
                // Encrypt the byte array using Serpent in CBC mode
                byte[] encryptedData = EncryptSerpentCBC(inputData, iv);
                File.WriteAllText(filePath, BitConverter.ToString(encryptedIV).Replace("-", "") + BitConverter.ToString(encryptedData).Replace("-", ""));
                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void open_text_document()
        {
            // Open the file selection dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                openFileDialog.Title = "Select a Text File To Open";

                // Show the dialog
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Read the selected text file and display its content
                    DisplayTextFileContent(openFileDialog.FileName);
                }
            }
        }

        private void DisplayTextFileContent(string filePath)
        {
            try
            {
                // Read the content of the text file
                string fileContent = File.ReadAllText(filePath);

                // Display the content in the richTextBox1
                richTextBox1.Text = fileContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DecryptTextFileContent(string filePath)
        {
            try
            {
                // Read the content of the text file
                string fileContent = File.ReadAllText(filePath);
                // Split the ciphertext to the encrypted IV and the encrypted text
                string encryptedIV = fileContent.Substring(0, 32);
                string encryptedText = fileContent.Substring(32);
                byte[] IVArray = Enumerable.Range(0, encryptedIV.Length)
                                     .Where(x => x % 2 == 0)
                                     .Select(x => Convert.ToByte(encryptedIV.Substring(x, 2), 16))
                                     .ToArray();
                byte[] CTArray = Enumerable.Range(0, encryptedText.Length)
                                     .Where(x => x % 2 == 0)
                                     .Select(x => Convert.ToByte(encryptedText.Substring(x, 2), 16))
                                     .ToArray();

                byte[] decryptedIV = DecryptSerpent(IVArray);
                byte[] decryptedData = DecryptSerpentCBC(CTArray, decryptedIV);
                richTextBox1.Text = Encoding.UTF8.GetString(decryptedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool check_key_validity()
        {
            bool key_is_valid = false;
            // Assume "key" is a string variable that you want to check
            if (string.IsNullOrEmpty(key) || key.Length != 32)
            {
                // Display an error message if the length is not equal to 32
                MessageBox.Show("Select The Key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                key_is_valid = true;
            }

            return key_is_valid;
        }

        private string GenerateRandomAscii(int length)
        {
            Random random = new Random();
            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                char randomChar = (char)random.Next(33, 127); // ASCII range excluding space ' '
                result.Append(randomChar);
            }

            return result.ToString();
        }

        static byte[] EncryptSerpentCBC(byte[] inputBytes, byte[] iv)
        {
            IBufferedCipher cipher = CipherUtilities.GetCipher("Serpent/CBC/PKCS7Padding");

            // Set the key and IV
            cipher.Init(true, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("Serpent", Encoding.UTF8.GetBytes(key)), iv));

            // Encrypt the data
            byte[] encryptedData = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int length = cipher.ProcessBytes(inputBytes, 0, inputBytes.Length, encryptedData, 0);
            cipher.DoFinal(encryptedData, length);

            return encryptedData;
        }

        static byte[] GenerateRandomIV()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] iv = new byte[16]; // 16 bytes for Serpent
                rng.GetBytes(iv);
                return iv;
            }
        }

        static byte[] DecryptSerpentCBC(byte[] encryptedData, byte[] iv)
        {
            IBufferedCipher cipher = CipherUtilities.GetCipher("Serpent/CBC/PKCS7Padding");

            // Set the key and IV
            cipher.Init(false, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("Serpent", Encoding.UTF8.GetBytes(key)), iv));

            // Decrypt the data
            byte[] decryptedData = new byte[cipher.GetOutputSize(encryptedData.Length)];
            int length = cipher.ProcessBytes(encryptedData, 0, encryptedData.Length, decryptedData, 0);
            cipher.DoFinal(decryptedData, length);

            return decryptedData;
        }

        static byte[] EncryptSerpent(byte[] inputBytes)
        {
            String key1 = key;
            String key2 = ModifyFirstCharacter(key1);

            SerpentEngine serpentEngine = new SerpentEngine();
            serpentEngine.Init(true, new KeyParameter(Encoding.UTF8.GetBytes(key2)));

            byte[] encryptedData = new byte[inputBytes.Length];

            serpentEngine.ProcessBlock(inputBytes, 0, encryptedData, 0);

            return encryptedData;
        }

        static byte[] DecryptSerpent(byte[] encryptedBytes)
        {
            String key1 = key;
            String key2 = ModifyFirstCharacter(key1);

            SerpentEngine serpentEngine = new SerpentEngine();
            serpentEngine.Init(false, new KeyParameter(Encoding.UTF8.GetBytes(key2)));

            byte[] decryptedData = new byte[encryptedBytes.Length];

            serpentEngine.ProcessBlock(encryptedBytes, 0, decryptedData, 0);

            return decryptedData;
        }

        static string ModifyFirstCharacter(string input)
        {
            if (!string.IsNullOrEmpty(input) && input.Length > 0)
            {
                char firstChar = input[0];

                if (firstChar < 90)
                {
                    // Increment by one
                    firstChar++;
                }
                else
                {
                    // Decrement by ten
                    firstChar = (char)(firstChar - 10);
                }

                // Update the string with the modified character
                return firstChar + input.Substring(1);
            }
            else
            {
                // Handle the case when the input string is empty or null
                return input;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}