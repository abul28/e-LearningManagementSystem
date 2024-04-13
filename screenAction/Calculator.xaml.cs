using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {

        List<double> gradesList = new List<double>();
        List<int> creditsList = new List<int>();
        int totalCredits = 0;
        double totalGradePoints = 0.0;
        public Calculator()
        {
            InitializeComponent();
        }

        void AddCourse_Clicked(System.Object sender, System.EventArgs e)
        {
            int credits = int.Parse(CreditsEntry.Text);
            double grade = double.Parse(GradeEntry.Text);

            creditsList.Add(credits);
            gradesList.Add(grade);

            totalCredits += credits;
            totalGradePoints += grade * credits;

            CreditsEntry.Text = "";
            GradeEntry.Text = "";
        }

        void CalculateCGPA_Clicked(System.Object sender, System.EventArgs e)
        {
            if (totalCredits > 0)
            {
                double cgpa = totalGradePoints / totalCredits;
                DisplayAlert("CGPA", "Your CGPA is: " + cgpa.ToString("F"), "OK");
            }
            else
            {
                DisplayAlert("Error", "You have not added any courses yet.", "OK");
            }
        }

        void Reset_Clicked(System.Object sender, System.EventArgs e)
        {
            gradesList.Clear();
            creditsList.Clear();
            totalCredits = 0;
            totalGradePoints = 0;

            CreditsEntry.Text = "";
            GradeEntry.Text = "";
        }

    }
}