using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var currentDate = DateTimeOffset.Now;

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "Personal",     "Personal tasks including daily activities and self-care.",                   currentDate, null },
                    { Guid.NewGuid(), "Work",         "Work-related tasks such as meetings, projects, or deadlines.",               currentDate, null },
                    { Guid.NewGuid(), "Shopping",     "Tasks related to buying items or groceries.",                                currentDate, null },
                    { Guid.NewGuid(), "Health",       "Tasks related to personal health, fitness, and well-being.",                 currentDate, null },
                    { Guid.NewGuid(), "Study",        "Tasks related to studying, learning new skills, or preparing for exams.",    currentDate, null },
                    { Guid.NewGuid(), "Hobbies",      "Tasks related to personal interests, leisure activities, or hobbies.",       currentDate, null },
                    { Guid.NewGuid(), "Errands",      "Tasks that require going outside the house or running local errands.",       currentDate, null },
                    { Guid.NewGuid(), "Appointments", "Scheduled events such as meetings, doctor appointments, etc.",               currentDate, null },
                    { Guid.NewGuid(), "Finance",      "Tasks related to managing finances, budgeting, and paying bills.",           currentDate, null },
                    { Guid.NewGuid(), "Travel",       "Tasks related to travel planning, bookings, and packing.",                   currentDate, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Categories\";", true);
        }
    }
}
