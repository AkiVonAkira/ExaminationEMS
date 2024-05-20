namespace Client.ApplicationStates
{
    public class AllState
    {
        // scope action
        public Action? Action { get; set; }

        // General Department
        public bool ShowGeneralDepartment { get; set; }

        // En metod som hanterar klickhändelsen för General Department.
        // Återställer alla avdelningar, visar General Departmentn och
        // kör den tilldelade åtgärden för General Department om det finns någon.
        public void GeneralDepartmentClicked(bool enabled)
        {
            ResetAllDepartments(); // Återställer alla avdelningar
            ShowGeneralDepartment = enabled; // Visar General Department
            Action?.Invoke(); // Kör den tilldelade åtgärden för General Department om det finns någon.
        }

        // Department
        public bool ShowDepartment { get; set; }

        public void DepartmentClicked(bool enabled)
        {
            ResetAllDepartments();
            ShowDepartment = enabled;
            Action?.Invoke();
        }

        // Section
        public bool ShowSection { get; set; }

        public void SectionClicked(bool enabled)
        {
            ResetAllDepartments();
            ShowSection = enabled;
            Action?.Invoke();
        }

        // Country
        public bool ShowCountry { get; set; }

        public void CountryClicked(bool enabled)
        {
            ResetAllDepartments();
            ShowCountry = enabled;
            Action?.Invoke();
        }

        // City
        public bool ShowCity { get; set; }

        public void CityClicked(bool enabled)
        {
            ResetAllDepartments();
            ShowCity = enabled;
            Action?.Invoke();
        }

        // Town
        public bool ShowTown { get; set; }

        public void TownClicked(bool enabled)
        {
            ResetAllDepartments();
            ShowTown = enabled;
            Action?.Invoke();
        }

        // User
        public bool ShowUser { get; set; }

        public void UserClicked(bool enabled)
        {
            ResetAllDepartments();
            ShowUser = enabled;
            Action?.Invoke();
        }

        // Employee
        public bool ShowEmployee { get; set; } = true;

        public void EmployeeClicked(bool enabled)
        {
            ResetAllDepartments();
            ShowEmployee = enabled;
            Action?.Invoke();
        }

        // En metod som återställer alla avdelningar.
        public void ResetAllDepartments()
        {
            ShowGeneralDepartment = false;
            ShowDepartment = false;
            ShowSection = false;
            ShowCountry = false;
            ShowCity = false;
            ShowTown = false;
            ShowUser = false;
            ShowEmployee = false;
        }
    }
}