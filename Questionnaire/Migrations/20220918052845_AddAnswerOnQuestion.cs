using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questionnaire.Migrations
{
    public partial class AddAnswerOnQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_AnswerOnQuestion_AnswerOnQuestionId",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_AnswerOnQuestionId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "AnswerOnQuestionId",
                table: "Answer");

            migrationBuilder.CreateTable(
                name: "AnswerAnswerOnQuestion",
                columns: table => new
                {
                    SelectedAnswersId = table.Column<Guid>(type: "uuid", nullable: false),
                    SelectedAnswersId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerAnswerOnQuestion", x => new { x.SelectedAnswersId, x.SelectedAnswersId1 });
                    table.ForeignKey(
                        name: "FK_AnswerAnswerOnQuestion_Answer_SelectedAnswersId",
                        column: x => x.SelectedAnswersId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerAnswerOnQuestion_AnswerOnQuestion_SelectedAnswersId1",
                        column: x => x.SelectedAnswersId1,
                        principalTable: "AnswerOnQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAnswerOnQuestion_SelectedAnswersId1",
                table: "AnswerAnswerOnQuestion",
                column: "SelectedAnswersId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerAnswerOnQuestion");

            migrationBuilder.AddColumn<Guid>(
                name: "AnswerOnQuestionId",
                table: "Answer",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answer_AnswerOnQuestionId",
                table: "Answer",
                column: "AnswerOnQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_AnswerOnQuestion_AnswerOnQuestionId",
                table: "Answer",
                column: "AnswerOnQuestionId",
                principalTable: "AnswerOnQuestion",
                principalColumn: "Id");
        }
    }
}
