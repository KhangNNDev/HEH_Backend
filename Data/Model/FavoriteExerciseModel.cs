namespace Data.Model
{
    public class FavoriteExerciseCreateModel
    {
        public Guid userID { get; set; }
        public Guid exerciseDetailID { get; set; }

        public bool isDeleted
        {
            get; set;
        }

    }
    public class FavoriteExerciseUpdateModel
    {
        public Guid favoriteExerciseID { get; set; }
        public Guid exerciseDetailID { get; set; }
        public Guid userID { get; set; }
        public bool isDeleted { get; set; }

    }
    public class FavoriteExerciseModel : FavoriteExerciseUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public UserModel? User { get; set; }
        public ExerciseDetailModel? ExerciseDetail { get; set; }
    }
}
