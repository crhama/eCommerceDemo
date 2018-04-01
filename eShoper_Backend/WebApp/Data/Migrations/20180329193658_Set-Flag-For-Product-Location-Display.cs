using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApp.Data.Migrations
{
    public partial class SetFlagForProductLocationDisplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatureItem",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecommendedItem",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSliderItem",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatureItem",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsRecommendedItem",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsSliderItem",
                table: "Products");
        }
    }
}
