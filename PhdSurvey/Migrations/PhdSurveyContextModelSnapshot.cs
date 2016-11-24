using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PhdSurvey.Models;

namespace PhdSurvey.Migrations
{
    [DbContext(typeof(PhdSurveyContext))]
    partial class PhdSurveyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhdSurvey.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answers");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Type");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("PhdSurvey.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PhdSurvey.Models.Survey", b =>
                {
                    b.HasOne("PhdSurvey.Models.User", "User")
                        .WithMany("Surveys")
                        .HasForeignKey("UserId");
                });
        }
    }
}
