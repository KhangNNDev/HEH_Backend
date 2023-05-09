using AutoMapper;
using Data.Entities;
using Data.Model;

namespace Services.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ExerciseCreateModel, Data.Entities.Exercise>();
            CreateMap<Data.Entities.Exercise, ExerciseModel>();
            CreateMap<ExerciseDetailCreateModel, Data.Entities.ExerciseDetail>();
            CreateMap<Data.Entities.ExerciseDetail, ExerciseDetailModel>();
            CreateMap<CategoryCreateModel, Data.Entities.Category>();
            CreateMap<Data.Entities.Category, CategoryModel>();
            CreateMap<PhysiotherapistCreateModel, Data.Entities.Physiotherapist>();
            CreateMap<Data.Entities.Physiotherapist, PhysiotherapistModel>();
            CreateMap<ScheduleCreateModel, Data.Entities.Schedule>();
            CreateMap<Data.Entities.Schedule, ScheduleModel>();
            CreateMap<FeedbackCreateModel, Data.Entities.Feedback>();
            CreateMap<Data.Entities.Feedback, FeedbackModel>();
            CreateMap<BookingDetailCreateModel, Data.Entities.BookingDetail>();
            CreateMap<Data.Entities.BookingDetail, BookingDetailModel>();
            CreateMap<BookingScheduleCreateModel, Data.Entities.BookingSchedule>();
            CreateMap<Data.Entities.BookingSchedule, BookingScheduleModel>();
            CreateMap<TypeOfSlotCreateModel, Data.Entities.TypeOfSlot>();
            CreateMap<Data.Entities.TypeOfSlot, TypeOfSlotModel>();
            CreateMap<SlotCreateModel, Data.Entities.Slot>();
            CreateMap<Data.Entities.Slot, SlotModel>();
            CreateMap<ExerciseResourceCreateModel, Data.Entities.ExerciseResource>();
            CreateMap<Data.Entities.ExerciseResource, ExerciseResourceModel>();
            CreateMap<SubProfileCreateModel, Data.Entities.SubProfile>();
            CreateMap<Data.Entities.SubProfile, SubProfileModel>();
            CreateMap<UserExerciseCreateModel, Data.Entities.UserExercise>();
            CreateMap<Data.Entities.UserExercise, UserExerciseModel>();
            CreateMap<MedicalRecordCreateModel, Data.Entities.MedicalRecord>();
            CreateMap<Data.Entities.MedicalRecord, MedicalRecordModel>();
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
