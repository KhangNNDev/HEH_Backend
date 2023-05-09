namespace Data.Model
{
    public class MedicalRecordCreateModel
    {
        public Guid? subProfileID { get; set; }
        public string problem { get; set; }
        public string difficult { get; set; }
        public string injury { get; set; }
        public string curing { get; set; }
        public string medicine { get; set; }
        public bool isDeleted { get; set; }

    }
    public class MedicalRecordUpdateModel
    {
        public Guid medicalRecordID { get; set; }
        public Guid? subProfileID { get; set; }
        public string problem { get; set; }
        public string difficult { get; set; }
        public string injury { get; set; }
        public string curing { get; set; }
        public string medicine { get; set; }
        public bool isDeleted { get; set; }

    }
    public class MedicalRecordModel : MedicalRecordUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public SubProfileModel? SubProfile { get; set; }
    }
}