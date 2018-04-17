namespace WebApp.Models.MaintenanceViewModels
{
    public class ColumnViewModel
    {
        public int Id { get; set; }
        public string ColumnName { get; set; }
        public bool IsSelectable { get; set; }
        public bool IsSelected { get; set; }
    }
}
