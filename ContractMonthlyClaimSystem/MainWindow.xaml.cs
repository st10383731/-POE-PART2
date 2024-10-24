using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ContractMonthlyClaimSystem
{
    public partial class MainWindow : Window
    {

        private string uploadedFilePath;

            public MainWindow()
            {
                InitializeComponent();
            }

            // Handle file upload
            private void UploadFile_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    // Use OpenFileDialog to choose a file
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Filter = "PDF files (*.pdf)|*.pdf|Word files (*.docx)|*.docx|Excel files (*.xlsx)|*.xlsx",
                        Title = "Select a file"
                    };

                    if (openFileDialog.ShowDialog() == true)
                    {
                        uploadedFilePath = openFileDialog.FileName;
                        UploadedFileName.Text = uploadedFilePath; // Display the full file path in the UI
                    }
                    else
                    {
                        UploadedFileName.Text = "No file uploaded";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            // Handle claim submission
            private void SubmitClaim_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    // Validate form input
                    if (string.IsNullOrWhiteSpace(HoursWorked.Text) || string.IsNullOrWhiteSpace(HourlyRate.Text))
                    {
                        throw new Exception("Please fill in both the 'Hours Worked' and 'Hourly Rate'.");
                    }

                    // Ensure file is uploaded
                    if (string.IsNullOrEmpty(uploadedFilePath))
                    {
                        throw new Exception("Please upload a supporting document.");
                    }

                    // Parse inputs
                    if (!int.TryParse(HoursWorked.Text, out int hours))
                    {
                        throw new Exception("Invalid input for Hours Worked.");
                    }

                    if (!decimal.TryParse(HourlyRate.Text, out decimal hourlyRate))
                    {
                        throw new Exception("Invalid input for Hourly Rate.");
                    }

                    // Calculate claim amount
                    decimal claimAmount = hours * hourlyRate;

                    // Display success message
                    MessageBox.Show($"Claim submitted successfully! Total amount: {claimAmount:C}");

                    // Update status
                    ClaimStatus.Text = "Status: Submitted";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }



            
          
        

    }
}









