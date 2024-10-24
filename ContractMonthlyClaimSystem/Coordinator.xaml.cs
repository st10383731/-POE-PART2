using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    /// <summary>
    /// Interaction logic for Coordinator.xaml
    /// </summary>
    public partial class Coordinator : Page
    {
        public class Claim
        {
            public int ClaimID { get; set; }
            public string LecturerName { get; set; }
            public decimal Amount { get; set; }
            public string Status { get; set; }
        }
        public List<Claim> Claims { get; set; }

        public Coordinator ()
            {
                InitializeComponent();

                // Simulate some claims for display
                Claims = new List<Claim>
            {
                new Claim { ClaimID = 1, LecturerName = "John Doe", Amount = 500.00m, Status = "Pending" },
                new Claim { ClaimID = 2, LecturerName = "Jane Smith", Amount = 300.00m, Status = "Pending" }
            };

                ClaimsDataGrid.ItemsSource = Claims;
            }

            // Approve claim
            private void ApproveClaim_Click(object sender, RoutedEventArgs e)
            {
                var selectedClaim = (Claim)ClaimsDataGrid.SelectedItem;
                if (selectedClaim != null)
                {
                    selectedClaim.Status = "Approved";
                    ClaimsDataGrid.Items.Refresh();  // Refresh grid to show updated status
                }
            }

            // Reject claim
            private void RejectClaim_Click(object sender, RoutedEventArgs e)
            {
                var selectedClaim = (Claim)ClaimsDataGrid.SelectedItem;
                if (selectedClaim != null)
                {
                    selectedClaim.Status = "Rejected";
                    ClaimsDataGrid.Items.Refresh();  // Refresh grid to show updated status
                }
            }
        }
    }







