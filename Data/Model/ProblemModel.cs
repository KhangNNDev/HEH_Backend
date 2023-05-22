namespace Data.Model
{

    public class ProblemCreateModel
    {

        public Guid? categoryID { get; set; }
        public Guid? medicalRecordID { get; set; }
        public bool isDeleted { get; set; }
    }
    public class ProblemUpdateModel
    {
        public Guid problemID { get; set; }


        public Guid? categoryID { get; set; }
        public Guid? medicalRecordID { get; set; }
        public bool isDeleted { get; set; }

    }
    public class ProblemModel : ProblemUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public CategoryModel? Category { get; set; }
        public MedicalRecordModel? MedicalRecord { get; set; }
    }

}
