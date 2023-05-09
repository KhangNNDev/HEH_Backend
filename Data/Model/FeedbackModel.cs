namespace Data.Model
{
    public class FeedbackCreateModel
    {



        public Guid scheduleID { get; set; }
        public string? comment { get; set; }
        public int ratingStar { get; set; }
        public bool isDeleted { get; set; }

    }
    public class FeedbackUpdateModel
    {
        public Guid feedbackID { get; set; }

        public Guid scheduleID { get; set; }
        public string? comment { get; set; }
        public int ratingStar { get; set; }
        public bool isDeleted { get; set; }
    }
    public class FeedbackModel : FeedbackUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public ScheduleModel? Schedule { get; set; }
    }
}
