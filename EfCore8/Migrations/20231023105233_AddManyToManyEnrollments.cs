using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCore8.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyEnrollments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Courses_CourseId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Instructors_InstructorId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionSchedule_Schedule_ScheduleId",
                table: "SectionSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionSchedule_Section_SectionId",
                table: "SectionSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionSchedule",
                table: "SectionSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Section",
                table: "Section");

            migrationBuilder.RenameTable(
                name: "SectionSchedule",
                newName: "SectionSchedules");

            migrationBuilder.RenameTable(
                name: "Section",
                newName: "Sections");

            migrationBuilder.RenameIndex(
                name: "IX_SectionSchedule_SectionId",
                table: "SectionSchedules",
                newName: "IX_SectionSchedules_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionSchedule_ScheduleId",
                table: "SectionSchedules",
                newName: "IX_SectionSchedules_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_InstructorId",
                table: "Sections",
                newName: "IX_Sections_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_CourseId",
                table: "Sections",
                newName: "IX_Sections_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionSchedules",
                table: "SectionSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnrollMents",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollMents", x => new { x.StudentId, x.SectionId });
                    table.ForeignKey(
                        name: "FK_EnrollMents_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollMents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fatima Ali" },
                    { 2, "Noor Salah" },
                    { 3, "Omar Yousef" },
                    { 4, "Huda Ahmed" },
                    { 5, "Amira Tareq" },
                    { 6, "Zinab Ismaeal" },
                    { 7, "Yousef Farid" },
                    { 8, "Layla Mostafa" },
                    { 9, "Mohamed Adel" },
                    { 10, "Samira Nabil" }
                });

            migrationBuilder.InsertData(
                table: "EnrollMents",
                columns: new[] { "SectionId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 5, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrollMents_SectionId",
                table: "EnrollMents",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Instructors_InstructorId",
                table: "Sections",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionSchedules_Schedule_ScheduleId",
                table: "SectionSchedules",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionSchedules_Sections_SectionId",
                table: "SectionSchedules",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Instructors_InstructorId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionSchedules_Schedule_ScheduleId",
                table: "SectionSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionSchedules_Sections_SectionId",
                table: "SectionSchedules");

            migrationBuilder.DropTable(
                name: "EnrollMents");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionSchedules",
                table: "SectionSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.RenameTable(
                name: "SectionSchedules",
                newName: "SectionSchedule");

            migrationBuilder.RenameTable(
                name: "Sections",
                newName: "Section");

            migrationBuilder.RenameIndex(
                name: "IX_SectionSchedules_SectionId",
                table: "SectionSchedule",
                newName: "IX_SectionSchedule_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionSchedules_ScheduleId",
                table: "SectionSchedule",
                newName: "IX_SectionSchedule_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_InstructorId",
                table: "Section",
                newName: "IX_Section_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_CourseId",
                table: "Section",
                newName: "IX_Section_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionSchedule",
                table: "SectionSchedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section",
                table: "Section",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Courses_CourseId",
                table: "Section",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Instructors_InstructorId",
                table: "Section",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionSchedule_Schedule_ScheduleId",
                table: "SectionSchedule",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionSchedule_Section_SectionId",
                table: "SectionSchedule",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
