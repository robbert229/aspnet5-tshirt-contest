using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TShirtVoter.Models;

namespace aspnet5tshirtcontest.Migrations
{
    [DbContext(typeof(ContestDbContext))]
    partial class ContestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("TShirtVoter.Models.ContestEntry", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Photo")
                        .IsRequired();

                    b.Property<string>("StudentId")
                        .IsRequired();

                    b.HasKey("EntryId");
                });

            modelBuilder.Entity("TShirtVoter.Models.ContestVote", b =>
                {
                    b.Property<string>("StudentId");

                    b.Property<int>("EntryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("StudentId");
                });
        }
    }
}
