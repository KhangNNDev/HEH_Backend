using AutoMapper;
using Data.Entities;
using Data.Model;

namespace Services.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ExerciseCreateModel, Exercise>();
            CreateMap<Exercise, ExerciseModel>();
            CreateMap<ExerciseDetailCreateModel, ExerciseDetail>();
            CreateMap<ExerciseDetail, ExerciseDetailModel>();
            CreateMap<CategoryCreateModel, Category>();
            CreateMap<Category, CategoryModel>();
            CreateMap<PhysiotherapistCreateModel, Physiotherapist>();
            CreateMap<Physiotherapist, PhysiotherapistModel>();
            CreateMap<ScheduleCreateModel, Schedule>();
            CreateMap<Schedule, ScheduleModel>();
            CreateMap<FeedbackCreateModel, Feedback>();
            CreateMap<Feedback, FeedbackModel>();
            CreateMap<BookingDetailCreateModel, BookingDetail>();
            CreateMap<BookingDetail, BookingDetailModel>();
            CreateMap<BookingScheduleCreateModel, BookingSchedule>();
            CreateMap<BookingSchedule, BookingScheduleModel>();
            CreateMap<TypeOfSlotCreateModel, TypeOfSlot>();
            CreateMap<TypeOfSlot, TypeOfSlotModel>();
            CreateMap<SlotCreateModel, Slot>();
            CreateMap<Slot, SlotModel>();
            CreateMap<ExerciseResourceCreateModel, ExerciseResource>();
            CreateMap<ExerciseResource, ExerciseResourceModel>();
            CreateMap<SubProfileCreateModel, SubProfile>();
            CreateMap<SubProfile, SubProfileModel>();
            CreateMap<FavoriteExerciseCreateModel, FavoriteExercise>();
            CreateMap<FavoriteExercise, FavoriteExerciseModel>();
            CreateMap<MedicalRecordCreateModel, MedicalRecord>();
            CreateMap<MedicalRecord, MedicalRecordModel>();
            CreateMap<UserCreateModel, User>();
            CreateMap<User, UserModel>();
            CreateMap<MemberCreateModel, User>();
            CreateMap<User, UserModel>();
            CreateMap<RelationshipCreateModel, Relationship>();
            CreateMap<Relationship, RelationshipModel>();
            CreateMap<ProblemCreateModel, Problem>();
            CreateMap<Problem, ProblemModel>();


            CreateMap<NotificationAddModel, Notification>();
            CreateMap<Notification, NotificationModel>().ReverseMap();
        }
    }
}
