using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "varchar(350)", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstName = table.Column<string>(type: "varchar(1000)", nullable: true),
                    lastName = table.Column<string>(type: "varchar(1000)", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    gender = table.Column<bool>(type: "boolean", nullable: false),
                    bookingStatus = table.Column<bool>(type: "boolean", nullable: false),
                    banStatus = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryID = table.Column<Guid>(type: "uuid", nullable: false),
                    categoryName = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfSlot",
                columns: table => new
                {
                    typeOfSlotID = table.Column<Guid>(type: "uuid", nullable: false),
                    slotName = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfSlot", x => x.typeOfSlotID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Physiotherapist",
                columns: table => new
                {
                    physiotherapistID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    specialize = table.Column<string>(type: "text", nullable: false),
                    skill = table.Column<string>(type: "text", nullable: false),
                    schedulingStatus = table.Column<int>(type: "integer", nullable: false),
                    scheduleStatus = table.Column<int>(type: "integer", nullable: false),
                    workingStatus = table.Column<int>(type: "integer", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physiotherapist", x => x.physiotherapistID);
                    table.ForeignKey(
                        name: "FK_Physiotherapist_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubProfile",
                columns: table => new
                {
                    profileID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    profileName = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProfile", x => x.profileID);
                    table.ForeignKey(
                        name: "FK_SubProfile_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    exerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseName = table.Column<string>(type: "text", nullable: false),
                    categoryID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseTimePerWeek = table.Column<int>(type: "integer", nullable: false),
                    flag = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.exerciseID);
                    table.ForeignKey(
                        name: "FK_Exercise_Category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Category",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    medicalRecordID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    categoryID = table.Column<Guid>(type: "uuid", nullable: false),
                    subProfileID = table.Column<Guid>(type: "uuid", nullable: false),
                    problem = table.Column<string>(type: "text", nullable: false),
                    difficult = table.Column<string>(type: "text", nullable: false),
                    injury = table.Column<string>(type: "text", nullable: false),
                    curing = table.Column<string>(type: "text", nullable: false),
                    medicine = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.medicalRecordID);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_Category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Category",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_SubProfile_subProfileID",
                        column: x => x.subProfileID,
                        principalTable: "SubProfile",
                        principalColumn: "profileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDetail",
                columns: table => new
                {
                    exerciseDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    detailName = table.Column<string>(type: "text", nullable: false),
                    set = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDetail", x => x.exerciseDetailID);
                    table.ForeignKey(
                        name: "FK_ExerciseDetail_Exercise_exerciseID",
                        column: x => x.exerciseID,
                        principalTable: "Exercise",
                        principalColumn: "exerciseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseResource",
                columns: table => new
                {
                    exerciseResourceID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    resourceName = table.Column<string>(type: "text", nullable: false),
                    videoURL = table.Column<string>(type: "text", nullable: false),
                    imageURL = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseResource", x => x.exerciseResourceID);
                    table.ForeignKey(
                        name: "FK_ExerciseResource_ExerciseDetail_exerciseDetailID",
                        column: x => x.exerciseDetailID,
                        principalTable: "ExerciseDetail",
                        principalColumn: "exerciseDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    slotID = table.Column<Guid>(type: "uuid", nullable: false),
                    typeOfSlotID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    timeStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    timeEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duaration = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    available = table.Column<bool>(type: "boolean", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.slotID);
                    table.ForeignKey(
                        name: "FK_Slot_ExerciseDetail_exerciseDetailID",
                        column: x => x.exerciseDetailID,
                        principalTable: "ExerciseDetail",
                        principalColumn: "exerciseDetailID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slot_TypeOfSlot_typeOfSlotID",
                        column: x => x.typeOfSlotID,
                        principalTable: "TypeOfSlot",
                        principalColumn: "typeOfSlotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExercise",
                columns: table => new
                {
                    userExerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    duarationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercise", x => x.userExerciseID);
                    table.ForeignKey(
                        name: "FK_UserExercise_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExercise_ExerciseDetail_exerciseDetailID",
                        column: x => x.exerciseDetailID,
                        principalTable: "ExerciseDetail",
                        principalColumn: "exerciseDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetail",
                columns: table => new
                {
                    bookingDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    profileID = table.Column<Guid>(type: "uuid", nullable: true),
                    slotID = table.Column<Guid>(type: "uuid", nullable: false),
                    timeBooking = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetail", x => x.bookingDetailID);
                    table.ForeignKey(
                        name: "FK_BookingDetail_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetail_Slot_slotID",
                        column: x => x.slotID,
                        principalTable: "Slot",
                        principalColumn: "slotID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetail_SubProfile_profileID",
                        column: x => x.profileID,
                        principalTable: "SubProfile",
                        principalColumn: "profileID");
                });

            migrationBuilder.CreateTable(
                name: "BookingSchedule",
                columns: table => new
                {
                    bookingScheduleID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    profileID = table.Column<Guid>(type: "uuid", nullable: true),
                    physiotherapistID = table.Column<Guid>(type: "uuid", nullable: false),
                    slotID = table.Column<Guid>(type: "uuid", nullable: false),
                    medicalRecordID = table.Column<Guid>(type: "uuid", nullable: false),
                    timeBooking = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSchedule", x => x.bookingScheduleID);
                    table.ForeignKey(
                        name: "FK_BookingSchedule_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSchedule_MedicalRecord_medicalRecordID",
                        column: x => x.medicalRecordID,
                        principalTable: "MedicalRecord",
                        principalColumn: "medicalRecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSchedule_Physiotherapist_physiotherapistID",
                        column: x => x.physiotherapistID,
                        principalTable: "Physiotherapist",
                        principalColumn: "physiotherapistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSchedule_Slot_slotID",
                        column: x => x.slotID,
                        principalTable: "Slot",
                        principalColumn: "slotID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSchedule_SubProfile_profileID",
                        column: x => x.profileID,
                        principalTable: "SubProfile",
                        principalColumn: "profileID");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    scheduleID = table.Column<Guid>(type: "uuid", nullable: false),
                    slotID = table.Column<Guid>(type: "uuid", nullable: false),
                    physiotherapistID = table.Column<Guid>(type: "uuid", nullable: false),
                    day = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.scheduleID);
                    table.ForeignKey(
                        name: "FK_Schedule_Physiotherapist_physiotherapistID",
                        column: x => x.physiotherapistID,
                        principalTable: "Physiotherapist",
                        principalColumn: "physiotherapistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_Slot_slotID",
                        column: x => x.slotID,
                        principalTable: "Slot",
                        principalColumn: "slotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    feedbackID = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    bookingDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    ratingStar = table.Column<int>(type: "integer", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.feedbackID);
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_BookingDetail_bookingDetailID",
                        column: x => x.bookingDetailID,
                        principalTable: "BookingDetail",
                        principalColumn: "bookingDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_profileID",
                table: "BookingDetail",
                column: "profileID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_slotID",
                table: "BookingDetail",
                column: "slotID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_userID",
                table: "BookingDetail",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_medicalRecordID",
                table: "BookingSchedule",
                column: "medicalRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_physiotherapistID",
                table: "BookingSchedule",
                column: "physiotherapistID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_profileID",
                table: "BookingSchedule",
                column: "profileID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_slotID",
                table: "BookingSchedule",
                column: "slotID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_userID",
                table: "BookingSchedule",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_categoryID",
                table: "Exercise",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDetail_exerciseID",
                table: "ExerciseDetail",
                column: "exerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseResource_exerciseDetailID",
                table: "ExerciseResource",
                column: "exerciseDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_bookingDetailID",
                table: "Feedback",
                column: "bookingDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_Id",
                table: "Feedback",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_categoryID",
                table: "MedicalRecord",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_subProfileID",
                table: "MedicalRecord",
                column: "subProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_userID",
                table: "MedicalRecord",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Physiotherapist_userID",
                table: "Physiotherapist",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_physiotherapistID",
                table: "Schedule",
                column: "physiotherapistID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_slotID",
                table: "Schedule",
                column: "slotID");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_exerciseDetailID",
                table: "Slot",
                column: "exerciseDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_typeOfSlotID",
                table: "Slot",
                column: "typeOfSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProfile_userID",
                table: "SubProfile",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_exerciseDetailID",
                table: "UserExercise",
                column: "exerciseDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_userID",
                table: "UserExercise",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookingSchedule");

            migrationBuilder.DropTable(
                name: "ExerciseResource");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "UserExercise");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MedicalRecord");

            migrationBuilder.DropTable(
                name: "BookingDetail");

            migrationBuilder.DropTable(
                name: "Physiotherapist");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "SubProfile");

            migrationBuilder.DropTable(
                name: "ExerciseDetail");

            migrationBuilder.DropTable(
                name: "TypeOfSlot");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
