namespace Core.Helpers
{
    public class EntityNameTranslateHelper
    {
        public static string Translate(string entityName)
        {
            return entityName switch
            {
                "Employee" => "Çalışan",
                "Project" => "Proje",
                "Issue" => "İş",
                "Company" => "Şirket",
                _ => entityName
            };
        }
    }
}
