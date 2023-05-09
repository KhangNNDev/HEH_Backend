﻿// <auto-generated />
using System;
using Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230407085430_hehv3")]
    partial class hehv3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.BookingDetail", b =>
                {
                    b.Property<Guid>("bookingDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<Guid?>("profileID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("slotID")
                        .HasColumnType("uuid");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("timeBooking")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("userID")
                        .HasColumnType("uuid");

                    b.HasKey("bookingDetailID");

                    b.HasIndex("profileID");

                    b.HasIndex("slotID");

                    b.HasIndex("userID");

                    b.ToTable("BookingDetail");
                });

            modelBuilder.Entity("Data.Entities.BookingSchedule", b =>
                {
                    b.Property<Guid>("bookingScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("medicalRecordID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("physiotherapistID")
                        .HasColumnType("uuid");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<Guid?>("profileID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("slotID")
                        .HasColumnType("uuid");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("timeBooking")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("userID")
                        .HasColumnType("uuid");

                    b.HasKey("bookingScheduleID");

                    b.HasIndex("medicalRecordID");

                    b.HasIndex("physiotherapistID");

                    b.HasIndex("profileID");

                    b.HasIndex("slotID");

                    b.HasIndex("userID");

                    b.ToTable("BookingSchedule");
                });

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Property<Guid>("categoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("categoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Data.Entities.Exercise", b =>
                {
                    b.Property<Guid>("exerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("categoryID")
                        .HasColumnType("uuid");

                    b.Property<string>("exerciseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("exerciseTimePerWeek")
                        .HasColumnType("integer");

                    b.Property<bool>("flag")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.HasKey("exerciseID");

                    b.HasIndex("categoryID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("Data.Entities.ExerciseDetail", b =>
                {
                    b.Property<Guid>("exerciseDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("detailName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("exerciseID")
                        .HasColumnType("uuid");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("set")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("exerciseDetailID");

                    b.HasIndex("exerciseID");

                    b.ToTable("ExerciseDetail");
                });

            modelBuilder.Entity("Data.Entities.ExerciseResource", b =>
                {
                    b.Property<Guid>("exerciseResourceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("exerciseDetailID")
                        .HasColumnType("uuid");

                    b.Property<string>("imageURL")
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("resourceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("videoURL")
                        .HasColumnType("text");

                    b.HasKey("exerciseResourceID");

                    b.HasIndex("exerciseDetailID");

                    b.ToTable("ExerciseResource");
                });

            modelBuilder.Entity("Data.Entities.Feedback", b =>
                {
                    b.Property<Guid>("feedbackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("bookingDetailID")
                        .HasColumnType("uuid");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ratingStar")
                        .HasColumnType("integer");

                    b.HasKey("feedbackID");

                    b.HasIndex("Id");

                    b.HasIndex("bookingDetailID");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("Data.Entities.MedicalRecord", b =>
                {
                    b.Property<Guid>("medicalRecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("categoryID")
                        .HasColumnType("uuid");

                    b.Property<string>("curing")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("difficult")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("injury")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("medicine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("problem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("subProfileID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("userID")
                        .HasColumnType("uuid");

                    b.HasKey("medicalRecordID");

                    b.HasIndex("categoryID");

                    b.HasIndex("subProfileID");

                    b.HasIndex("userID");

                    b.ToTable("MedicalRecord");
                });

            modelBuilder.Entity("Data.Entities.Physiotherapist", b =>
                {
                    b.Property<Guid>("physiotherapistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("scheduleStatus")
                        .HasColumnType("integer");

                    b.Property<int>("schedulingStatus")
                        .HasColumnType("integer");

                    b.Property<string>("skill")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("specialize")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("userID")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<int>("workingStatus")
                        .HasColumnType("integer");

                    b.HasKey("physiotherapistID");

                    b.HasIndex("userID");

                    b.ToTable("Physiotherapist");
                });

            modelBuilder.Entity("Data.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(350)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Schedule", b =>
                {
                    b.Property<Guid>("scheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("day")
                        .HasColumnType("date");

                    b.Property<Guid>("physiotherapistID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("slotID")
                        .HasColumnType("uuid");

                    b.HasKey("scheduleID");

                    b.HasIndex("physiotherapistID");

                    b.HasIndex("slotID");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("Data.Entities.Slot", b =>
                {
                    b.Property<Guid>("slotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("available")
                        .HasColumnType("boolean");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly>("duaration")
                        .HasColumnType("time without time zone");

                    b.Property<Guid?>("exerciseDetailID")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<DateTime>("timeEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("timeStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("typeOfSlotID")
                        .HasColumnType("uuid");

                    b.HasKey("slotID");

                    b.HasIndex("exerciseDetailID");

                    b.HasIndex("typeOfSlotID");

                    b.ToTable("Slot");
                });

            modelBuilder.Entity("Data.Entities.SubProfile", b =>
                {
                    b.Property<Guid>("profileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("profileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("userID")
                        .HasColumnType("uuid");

                    b.HasKey("profileID");

                    b.HasIndex("userID");

                    b.ToTable("SubProfile");
                });

            modelBuilder.Entity("Data.Entities.TypeOfSlot", b =>
                {
                    b.Property<Guid>("typeOfSlotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("slotName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("typeOfSlotID");

                    b.ToTable("TypeOfSlot");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<bool>("banStatus")
                        .HasColumnType("boolean");

                    b.Property<bool>("bookingStatus")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("dob")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("firstName")
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("gender")
                        .HasColumnType("boolean");

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Data.Entities.UserExercise", b =>
                {
                    b.Property<Guid>("userExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("duarationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("exerciseDetailID")
                        .HasColumnType("uuid");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("userID")
                        .HasColumnType("uuid");

                    b.HasKey("userExerciseID");

                    b.HasIndex("exerciseDetailID");

                    b.HasIndex("userID");

                    b.ToTable("UserExercise");
                });

            modelBuilder.Entity("Data.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Data.Entities.BookingDetail", b =>
                {
                    b.HasOne("Data.Entities.SubProfile", "SubProfile")
                        .WithMany()
                        .HasForeignKey("profileID");

                    b.HasOne("Data.Entities.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("slotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slot");

                    b.Navigation("SubProfile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.BookingSchedule", b =>
                {
                    b.HasOne("Data.Entities.MedicalRecord", "MedicalRecord")
                        .WithMany()
                        .HasForeignKey("medicalRecordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Physiotherapist", "Physiotherapist")
                        .WithMany()
                        .HasForeignKey("physiotherapistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.SubProfile", "SubProfile")
                        .WithMany()
                        .HasForeignKey("profileID");

                    b.HasOne("Data.Entities.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("slotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalRecord");

                    b.Navigation("Physiotherapist");

                    b.Navigation("Slot");

                    b.Navigation("SubProfile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Exercise", b =>
                {
                    b.HasOne("Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Data.Entities.ExerciseDetail", b =>
                {
                    b.HasOne("Data.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("exerciseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Data.Entities.ExerciseResource", b =>
                {
                    b.HasOne("Data.Entities.ExerciseDetail", "ExerciseDetail")
                        .WithMany()
                        .HasForeignKey("exerciseDetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseDetail");
                });

            modelBuilder.Entity("Data.Entities.Feedback", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.BookingDetail", "BookingDetail")
                        .WithMany()
                        .HasForeignKey("bookingDetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingDetail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.MedicalRecord", b =>
                {
                    b.HasOne("Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.SubProfile", "SubProfile")
                        .WithMany()
                        .HasForeignKey("subProfileID");

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SubProfile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Physiotherapist", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Schedule", b =>
                {
                    b.HasOne("Data.Entities.Physiotherapist", "PhysiotherapistDetail")
                        .WithMany()
                        .HasForeignKey("physiotherapistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("slotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhysiotherapistDetail");

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("Data.Entities.Slot", b =>
                {
                    b.HasOne("Data.Entities.ExerciseDetail", "ExerciseDetail")
                        .WithMany()
                        .HasForeignKey("exerciseDetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.TypeOfSlot", "TypeOfSlot")
                        .WithMany()
                        .HasForeignKey("typeOfSlotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseDetail");

                    b.Navigation("TypeOfSlot");
                });

            modelBuilder.Entity("Data.Entities.SubProfile", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.UserExercise", b =>
                {
                    b.HasOne("Data.Entities.ExerciseDetail", "ExerciseDetail")
                        .WithMany()
                        .HasForeignKey("exerciseDetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseDetail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.UserRole", b =>
                {
                    b.HasOne("Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
