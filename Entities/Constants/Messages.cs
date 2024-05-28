using Core.Helpers;
using Entities.Enums;
using System;

namespace Entities.Constants
{
    public class Messages
    {
        private static readonly Dictionary<(EntityType entityType, ActionType action, bool isSuccess, Language language), string> messageDictionary =
            new()
        {
            // Company messages
            { (EntityType.Company, ActionType.Add, true, Language.Turkish), "Şirket başarıyla eklendi." },
            { (EntityType.Company, ActionType.Add, false, Language.Turkish), "Şirket eklenemedi." },
            { (EntityType.Company, ActionType.Delete, true, Language.Turkish), "Şirket başarıyla silindi." },
            { (EntityType.Company, ActionType.Delete, false, Language.Turkish), "Şirket silinemedi." },
            { (EntityType.Company, ActionType.Update, true, Language.Turkish), "Şirket başarıyla güncellendi." },
            { (EntityType.Company, ActionType.Update, false, Language.Turkish), "Şirket güncellenemedi." },
            { (EntityType.Company, ActionType.Assign, true, Language.Turkish), "Şirket başarıyla atandı." },
            { (EntityType.Company, ActionType.Assign, false, Language.Turkish), "Şirket atanamadı." },
            { (EntityType.Company, ActionType.Get, true, Language.Turkish), "Şirket başarıyla getirildi." },
            { (EntityType.Company, ActionType.Get, false, Language.Turkish), "Şirket bulunamadı." },

            { (EntityType.Company, ActionType.Add, true, Language.English), "Company added successfully." },
            { (EntityType.Company, ActionType.Add, false, Language.English), "Company could not be added." },
            { (EntityType.Company, ActionType.Delete, true, Language.English), "Company deleted successfully." },
            { (EntityType.Company, ActionType.Delete, false, Language.English), "Company could not be deleted." },
            { (EntityType.Company, ActionType.Update, true, Language.English), "Company updated successfully." },
            { (EntityType.Company, ActionType.Update, false, Language.English), "Company could not be updated." },
            { (EntityType.Company, ActionType.Assign, true, Language.English), "Company assigned successfully." },
            { (EntityType.Company, ActionType.Assign, false, Language.English), "Company could not be assigned." },
            { (EntityType.Company, ActionType.Get, true, Language.English), "Company retrieved successfully." },
            { (EntityType.Company, ActionType.Get, false, Language.English), "Company not found." },

            // Employee messages
            { (EntityType.Employee, ActionType.Add, true, Language.Turkish), "Çalışan başarıyla eklendi." },
            { (EntityType.Employee, ActionType.Add, false, Language.Turkish), "Çalışan eklenemedi." },
            { (EntityType.Employee, ActionType.Delete, true, Language.Turkish), "Çalışan başarıyla silindi." },
            { (EntityType.Employee, ActionType.Delete, false, Language.Turkish), "Çalışan silinemedi." },
            { (EntityType.Employee, ActionType.Update, true, Language.Turkish), "Çalışan başarıyla güncellendi." },
            { (EntityType.Employee, ActionType.Update, false, Language.Turkish), "Çalışan güncellenemedi." },
            { (EntityType.Employee, ActionType.Assign, true, Language.Turkish), "Çalışan başarıyla atandı." },
            { (EntityType.Employee, ActionType.Assign, false, Language.Turkish), "Çalışan zaten atandı." },
            { (EntityType.Employee, ActionType.Get, true, Language.Turkish), "Çalışan başarıyla getirildi." },
            { (EntityType.Employee, ActionType.Get, false, Language.Turkish), "Çalışan bulunamadı." },

            { (EntityType.Employee, ActionType.Add, true, Language.English), "Employee added successfully." },
            { (EntityType.Employee, ActionType.Add, false, Language.English), "Employee could not be added." },
            { (EntityType.Employee, ActionType.Delete, true, Language.English), "Employee deleted successfully." },
            { (EntityType.Employee, ActionType.Delete, false, Language.English), "Employee could not be deleted." },
            { (EntityType.Employee, ActionType.Update, true, Language.English), "Employee updated successfully." },
            { (EntityType.Employee, ActionType.Update, false, Language.English), "Employee could not be updated." },
            { (EntityType.Employee, ActionType.Assign, true, Language.English), "Employee assigned successfully." },
            { (EntityType.Employee, ActionType.Assign, false, Language.English), "Employee already assigned." },
            { (EntityType.Employee, ActionType.Get, true, Language.English), "Employee retrieved successfully." },
            { (EntityType.Employee, ActionType.Get, false, Language.English), "Employee not found." },

            // Issue messages
            { (EntityType.Issue, ActionType.Add, true, Language.Turkish), "Görev başarıyla eklendi." },
            { (EntityType.Issue, ActionType.Add, false, Language.Turkish), "Görev eklenemedi." },
            { (EntityType.Issue, ActionType.Delete, true, Language.Turkish), "Görev başarıyla silindi." },
            { (EntityType.Issue, ActionType.Delete, false, Language.Turkish), "Görev silinemedi." },
            { (EntityType.Issue, ActionType.Update, true, Language.Turkish), "Görev başarıyla güncellendi." },
            { (EntityType.Issue, ActionType.Update, false, Language.Turkish), "Görev güncellenemedi." },
            { (EntityType.Issue, ActionType.Assign, true, Language.Turkish), "Görev başarıyla atandı." },
            { (EntityType.Issue, ActionType.Assign, false, Language.Turkish), "Görev atanamadı." },
            { (EntityType.Issue, ActionType.Get, true, Language.Turkish), "Görev başarıyla getirildi." },
            { (EntityType.Issue, ActionType.Get, false, Language.Turkish), "Görev bulunamadı." },

            { (EntityType.Issue, ActionType.Add, true, Language.English), "Issue added successfully." },
            { (EntityType.Issue, ActionType.Add, false, Language.English), "Issue could not be added." },
            { (EntityType.Issue, ActionType.Delete, true, Language.English), "Issue deleted successfully." },
            { (EntityType.Issue, ActionType.Delete, false, Language.English), "Issue could not be deleted." },
            { (EntityType.Issue, ActionType.Update, true, Language.English), "Issue updated successfully." },
            { (EntityType.Issue, ActionType.Update, false, Language.English), "Issue could not be updated." },
            { (EntityType.Issue, ActionType.Assign, true, Language.English), "Issue assigned successfully." },
            { (EntityType.Issue, ActionType.Assign, false, Language.English), "Issue could not be assigned." },
            { (EntityType.Issue, ActionType.Get, true, Language.English), "Issue retrieved successfully." },
            { (EntityType.Issue, ActionType.Get, false, Language.English), "Issue not found." },

            // Project messages
            { (EntityType.Project, ActionType.Add, true, Language.Turkish), "Proje başarıyla eklendi." },
            { (EntityType.Project, ActionType.Add, false, Language.Turkish), "Proje eklenemedi." },
            { (EntityType.Project, ActionType.Delete, true, Language.Turkish), "Proje başarıyla silindi." },
            { (EntityType.Project, ActionType.Delete, false, Language.Turkish), "Proje silinemedi." },
            { (EntityType.Project, ActionType.Update, true, Language.Turkish), "Proje başarıyla güncellendi." },
            { (EntityType.Project, ActionType.Update, false, Language.Turkish), "Proje güncellenemedi." },
            { (EntityType.Project, ActionType.Assign, true, Language.Turkish), "Proje başarıyla atandı." },
            { (EntityType.Project, ActionType.Assign, false, Language.Turkish), "Proje atanamadı. Girdiğiniz bilgileri kontrol ediniz." },
            { (EntityType.Project, ActionType.Get, true, Language.Turkish), "Proje başarıyla getirildi." },
            { (EntityType.Project, ActionType.Get, false, Language.Turkish), "Proje bulunamadı." },

            { (EntityType.Project, ActionType.Add, true, Language.English), "Project added successfully." },
            { (EntityType.Project, ActionType.Add, false, Language.English), "Project could not be added." },
            { (EntityType.Project, ActionType.Delete, true, Language.English), "Project deleted successfully." },
            { (EntityType.Project, ActionType.Delete, false, Language.English), "Project could not be deleted." },
            { (EntityType.Project, ActionType.Update, true, Language.English), "Project updated successfully." },
            { (EntityType.Project, ActionType.Update, false, Language.English), "Project could not be updated." },
            { (EntityType.Project, ActionType.Assign, true, Language.English), "Project assigned successfully." },
            { (EntityType.Project, ActionType.Assign, false, Language.English), "Project could not be assigned. Please check your input." },
            { (EntityType.Project, ActionType.Get, true, Language.English), "Project retrieved successfully." },
            { (EntityType.Project, ActionType.Get, false, Language.English), "Project not found." }
        };

        public static readonly string InvalidIdentityNumber = "Geçersiz kimlik numarası.";
        public static readonly string GetProjectEmployeeCountReport = "Şirket bazında proje çalışan raporu sayısı getirildi.";

        public static string CreateMessage(EntityType entityType, ActionType action, bool isSuccess, Language language = Language.Turkish)
        {
            return messageDictionary.TryGetValue((entityType, action, isSuccess, language), out var message)
                  ? message
                  : $"{EntityNameTranslateHelper.Translate(entityType.ToString())} için mesaj bulunamadı.";
        }

        public static string CreateNotFoundMessage(EntityType entityType, int id)
        {
            return $"{id} ID'li {EntityNameTranslateHelper.Translate(entityType.ToString())} bulunamadı.";
        }
    }
}
