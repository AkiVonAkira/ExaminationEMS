namespace Client.ApplicationStates
{
    public class DepartmentState
    {
        
        public Action? GeneralDepartmentAction { get; set; }

        public bool ShowGeneralDepartment { get; set; }

        // En metod som hanterar klickhändelsen för General Department.
        // Återställer alla avdelningar, visar General Departmentn och 
        // kör den tilldelade åtgärden för General Department om det finns någon.
        public void GeneralDepartmentClicked()
        {
            ResetAllDepartments(); // Återställer alla avdelningar
            ShowGeneralDepartment = true; // Visar General Department
            GeneralDepartmentAction?.Invoke(); // Kör den tilldelade åtgärden för General Department om det finns någon.
        }

        // En metod som återställer alla avdelningar genom att dölja General Department.
        public void ResetAllDepartments()
        {
            ShowGeneralDepartment = false; // vilket återställer General Department.
        }

    }
}
